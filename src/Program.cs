using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace Panda {

    class Program {

        static void Main(string[] args) {
            //getting panda source filename
            string source_filename;
            if (args.Length == 0 || args == null) {
                Console.WriteLine("enter Panda source file: ");
                source_filename = Console.ReadLine();
            }else { source_filename = args[0]; }
            

            //initialise list of panda source code
            List<string> code_list = new List<string>();
            //initialise variable class
            Panda.var_register var_Register = new var_register();
            //initialise function calss
            Panda.func_register func_Register = new func_register();

            
            //parse the panda code into the list
            Utils.parse(source_filename, code_list);
            
            for (int i = 0; i < code_list.Count; i++) {
                lexer.token_collection(code_list[i], var_Register);
            }
            Console.Write("done");
            Console.Read();
            
        }
    }
}
