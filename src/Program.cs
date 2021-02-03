using System;
namespace Panda {
    class Program {

        static void Main(string[] args) {
            //getting panda source filename
            string source_filename;
            if (args.Length == 0 || args == null) {
                Console.WriteLine("enter Panda source file: ");
                source_filename = Console.ReadLine();
            }else { source_filename = args[0]; }

            //check langauge option
            string lang_mode = "en";
            if (args.Length < 2 || args == null){
                Console.WriteLine("[Info]: Executing Panda in english mode");
                lang_mode = @".\lang\" + lang_mode + ".lang";
            } else if (args.Length >= 2) {
                lang_mode = @".\lang\" + args[1] + ".lang";
                Console.WriteLine("[Info]: Executing Panda in " + args[1] + " mode");
            }


            //initialise list of panda source code
            //store the content of the panda script file
            string[] code_list = Utils.parse_file_to_array(source_filename);

            //initialise langauge dependant keywords
            string[] lang_list = Utils.parse_file_to_array(lang_mode);
            lexer.kw lang_kw = new lexer.kw(lang_list);

            //initialise variable class
            var_register var_Register = new var_register();
            //initialise function class
            func_register func_Register = new func_register();


            

            for (int i = 0; i < code_list.Length; i++) {

            }
        }
    }
}
