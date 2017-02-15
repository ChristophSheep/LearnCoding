
module Kernel
  def prompt(msg)
    sync = STDOUT.sync
    begin
      STDOUT.sync = true
      print "#{msg}: " 
      return gets.chomp
    ensure
      STDOUT.sync = sync
    end
  end
end

