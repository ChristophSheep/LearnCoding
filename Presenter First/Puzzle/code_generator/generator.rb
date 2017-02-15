#!/usr/bin/ruby
require File.dirname(__FILE__) + '/config/environment.rb'
require 'erb'
require 'prompt'
require 'rexml/document'
require 'visual_studio_proj_file_writer'
require 'ostruct'
include REXML

#$proj_dir = '/../'
$proj_filename = 'Puzzle.csproj'
$proj_dir = '/../'

class String
  def camelize
    self.to_s.gsub(/\/(.?)/) { 
      "::" + $1.upcase 
    }.gsub(/(^|_)(.)/) { 
      $2.upcase 
    }
  end

  def underscore
    self.to_s.gsub(/::/, '/').gsub(
    /([A-Z]+)([A-Z])/,'\1_\2').gsub(
    /([a-z])([A-Z])/,'\1_\2').downcase
  end
end

class GeneratorBase
  attr_reader :files

  @@user_class = nil

  def self.inherited(c)
    @@user_class = c
  end

  def self.create_instance
    @@user_class.new
  end

  def file(args)
    @files ||= []
    @files << args
  end
end

at_exit do 
  gen = GeneratorBase.create_instance
  puts
  puts gen.desc
  puts
  gen.generate
  files = gen.files

  bag = {}
  gen.instance_variables.each do |var|
    bag[var.gsub('@','')] = gen.instance_eval(var)
  end
  bag = OpenStruct.new(bag)

  basedir = File.dirname(__FILE__)
  out_dir = basedir + $proj_dir
  proj_filename = $proj_filename
  in_dir =  basedir + "/templates/#{gen.class.to_s.underscore.gsub('_generator','')}/"

  files.each do |file|
    puts "generating #{out_dir + file[:out]}"
    File.open(in_dir + file[:in], 'r') do |inf|
      template = ERB.new(inf.read)
      File.open(out_dir + file[:out], 'w') do |outf|
        outf.write(template.result(bag.send(:binding)))
      end
    end
  end

  doc = nil
  File.open(out_dir + proj_filename, 'r') do |proj_file|
    doc = Document.new(proj_file)
  end

  include_el = XPath.first(doc.root, '//VisualStudioProject/CSHARP/Files/Include')
  if include_el.nil?
    puts 'Include element not found in project file'
    exit 2
  end

  files.each do |file|
    puts "adding #{out_dir + file[:out]} to #{proj_filename}"
    opts = file.reject { |k,v| [:in,:out].include?(k) }
    opts[:rel_path] = file[:out].gsub("/","\\")
    attributes = Hash.new
    opts.each do |k,v|
      attributes[k.to_s.camelize] = v
    end
    include_el.add_element('File', attributes)
  end

  puts 'storing project file'
  File.open(out_dir + proj_filename, 'wb') do |proj_file|
    VisualStudioProjFileWriter.new(:doc => doc).write(proj_file)
  end

  puts "Hit ENTER to exit"
  gets
end

