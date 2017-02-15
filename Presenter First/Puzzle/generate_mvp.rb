#!/usr/bin/ruby
require 'code_generator/generator'

class MvpGenerator < GeneratorBase
  def generate
    @name = prompt 'Enter mvp name'

    file :in => "IModel.cs", :out => "I#{@name}Model.cs", 
      :sub_type => 'Code', :build_action => 'Compile'
    file :in => "IView.cs", :out => "I#{@name}View.cs", 
      :sub_type => 'Code', :build_action => 'Compile'
    file :in => "Model.cs", :out => "#{@name}Model.cs", 
      :sub_type => 'Code', :build_action => 'Compile'
    file :in => "Presenter.cs", :out => "#{@name}Presenter.cs", 
      :sub_type => 'Code', :build_action => 'Compile'
    file :in => "TestModel.cs", :out => "Tests/Test#{@name}Model.cs", 
      :sub_type => 'Code', :build_action => 'Compile'
    file :in => "TestPresenter.cs", :out => "Tests/Test#{@name}Presenter.cs", 
      :sub_type => 'Code', :build_action => 'Compile'
  end

  def desc
    <<-EOS
    Generates files for an mvp triplet.  These include
    a model, presenter, and tests for each, as well
    as interfaces for the model and view:

      Foo => FooPresenter.cs, FooModel.cs, TestFooPresenter.cs,
             TestFooModel.cs, IFooView.cs, IFooModel.cs

    EOS
  end
end

