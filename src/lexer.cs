using System;
using System.Collections.Generic;

namespace Panda {
    class lexer {
        //program counter is the current line in the panda script
        private int program_counter = 0;
        private string[] panda_source;

        //initialise variable class
        // var_register var_Register = new var_register();
        int_register int_Register = new int_register();

        //initialise function class
        func_register func_Register = new func_register();

        //keyword struct to store the langauge tokens
        token.kw lang_kw;

        public lexer(string[] lang_kw){
            this.lang_kw = new token.kw(lang_kw);
        }

        /// <summary>
        /// loop through each line and the the key words which will be sorted by the switch case and executed appropriately
        /// </summary>
        /// <param name="panda_source"> Panda code, each index is a line</param>
        /// <param name="lang_kw"> the language token </param>
        /// <param name="var_Register"> main varible register </param>
        public void run(string[] panda_source) {
            this.panda_source = panda_source;
            Console.WriteLine("[info]: initialising panda code");

            //looping through each line in the file
            for (program_counter = 0; program_counter < panda_source.Length; program_counter++) {
                Console.WriteLine("[info]: processing line " + (program_counter + 1));

                //process current token
                switch (token.match_kw(new string(panda_source[program_counter]).Split(' ')[0], lang_kw)) {

                    case token.kw_index.INT:
                        integer.create(new string(panda_source[program_counter]), int_Register);
                        break;
                    case token.kw_index.IF:
                        if (!(selection.IF(new string(panda_source[program_counter]), int_Register, program_counter))){
                            //jump to the end of the if statement
                            lookLineOfToken(lang_kw.IF, lang_kw.END_IF);
                        }
                        break;
                    case token.kw_index.COMMENT:
                        break;
                    case token.kw_index.NULL:
                        //check if it's an empty line
                        if(new string(panda_source[program_counter]) == null || new string(panda_source[program_counter]) == string.Empty){
                            //if it is an empty line discard and continue
                            break;
                        }
                        //the user is editing a variable that has already been created
                        if(int_Register.isIntegerRegistered(new string(panda_source[program_counter]).Split(' ')[0])){
                            integer.create(new string(panda_source[program_counter]), int_Register);

                        }else{
                        Console.WriteLine("[warning]: symbol " + new string(panda_source[program_counter]).Split(' ')[0] + " is defined");
                        }
                        break;
                }
            }
        }

        public void lookLineOfToken(string initial_kw, string search_kw){
            //start with one counter
            //loop through panda code
            //increment <c>tokenCounter<c> when <c>initial_kw<c> is found
            //decrement <c>tokenCounter<c> when <c>search_kw<c> is found
            //if <c>tokenCounter<c> is 0 found new program counter
            int tokenCounter = 0;
            for (int localProgramCounter = program_counter; localProgramCounter < panda_source.Length; localProgramCounter++){
                if (new string(panda_source[localProgramCounter].Split(' ')[0]) == initial_kw){
                    tokenCounter++;
                }else if (new string(panda_source[localProgramCounter].Split(' ')[0]) == search_kw){
                    tokenCounter--;
                }
                if (tokenCounter == 0){
                    program_counter = localProgramCounter;
                }
            }
        }
    }
}
