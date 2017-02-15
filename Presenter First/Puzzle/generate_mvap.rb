#!/usr/bin/ruby
require 'code_generator/generator'

class MvpGenerator < GeneratorBase
  def generate
    @name = prompt 'Enter mvap name'

    file :in => "IModel.cs", :out => "I#{@name}Model.cs", 
      :sub_type => 'Code', :build_action => 'Compile'
      
    file :in => "IView.cs", :out => "I#{@name}View.cs", 
      :sub_type => 'Code', :build_action => 'Compile'
      
    file :in => "IAdapter.cs", :out => "I#{@name}Adapter.cs", 
      :sub_type => 'Code', :build_action => 'Compile'
      
    file :in => "Model.cs", :out => "#{@name}Model.cs", 
      :sub_type => 'Code', :build_action => 'Compile'
      
    file :in => "Adapter.cs", :out => "#{@name}Adapter.cs", 
      :sub_type => 'Code', :build_action => 'Compile'

file :in => "PresenterWithAdapter.cs", :out => "#{@name}Presenter.cs", 
      :sub_type => 'Code', :build_action => 'Compile'
      
    file :in => "TestModel.cs", :out => "Tests/Test#{@name}Model.cs", 
      :sub_type => 'Code', :build_action => 'Compile'
      
    file :in => "TestPresenterWithAdapter.cs", :out => "Tests/Test#{@name}Presenter.cs", 
      :sub_type => 'Code', :build_action => 'Compile'
  
    file :in => "TestAdapter.cs", :out => "Tests/Test#{@name}Adapter.cs", 
    :sub_type => 'Code', :build_action => 'Compile'
end

  def desc
    <<-EOS
    Generates files for an mvap quadlet.  These include
    a model, adapter, presenter, and tests for each, as well
    as interfaces for the model and view and adapter:

      Foo => FooPresenter.cs, FooModel.cs, TestFooPresenter.cs,
             TestFooModel.cs, IFooView.cs, IFooModel.cs
             IFooAdapter.cs, FooAdapter.cs, TestFooAdapter.cs

    EOS
  end
end

