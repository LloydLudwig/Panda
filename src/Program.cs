using System;
namespace Panda {
    class Program {

        static void Main(string[] args) {
            //getting panda source filename
            string source_filename;
            if (args.Length == 0 || args == null) {
                Console.Write("[inpur]: enter Panda source file: ");
                source_filename = Console.ReadLine();
            } else { source_filename = args[0]; }

            //check langauge option
            string lang_mode;
            if (args.Length <= 1 || args == null){
                Console.Write("[input]: please enter language file name or ignore for default english mode ");
                lang_mode = Utils.getWorkingDir()
                    + "\\lang\\"
                    + Console.ReadLine()
                    + ".lang";
            }else{
                lang_mode = Utils.getWorkingDir()
                    + "\\lang\\"
                    + "en.lang";
            }


            //initialise list of panda source code
            //store the content of the panda script file
            string[] code_list = Utils.parseFileToArray(source_filename);
            //initialise langauge dependant keywords
            string[] lang_list = Utils.parseFileToArray(lang_mode);
            lexer.kw lang_kw = new lexer.kw(lang_list);

            //initialise variable class
            var_register var_Register = new var_register();
            //initialise function class
            func_register func_Register = new func_register();

            for (int i = 0; i < code_list.Length; i++) {
                lexer.run(code_list, lang_kw, var_Register);
            }
        }
    }
}
