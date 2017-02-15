#!/usr/bin/ruby
require 'code_generator/generator'

class InterfaceGenerator < GeneratorBase
  def generate
    @name = prompt 'Enter interface name'
    @iface_name = 'I' + @name.gsub(/^I/,'')
    @class_name = @name.gsub(/^I/,'')

    @with_impl = prompt 'Generate Implmentation [Y/n]'
    @with_impl = !(@with_impl =~ /\s*n/i)
    
    file :in => "Interface.cs", :out => "#{@iface_name}.cs", 
      :sub_type => 'Code', :build_action => 'Compile'

    if @with_impl 
      file :in => "Class.cs", :out => "#{@class_name}.cs", 
        :sub_type => 'Code', :build_action => 'Compile'

      file :in => "Test.cs", :out => "Tests/Test#{@class_name}.cs", 
        :sub_type => 'Code', :build_action => 'Compile'
    end
  end

  def desc
    <<-EOS
    Generates an interface (with option implementation):

      IFoo => IFoo.cs, (Foo.cs, TestFoo.cs)
      Foo => IFoo.cs, (Foo.cs, TestFoo.cs)

    EOS
  end
end

