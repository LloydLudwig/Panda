using System;
using System.Text.RegularExpressions;

namespace Panda {
    class lexer {


        public static void token_collection(string line_input, var_register var_Register) {
            string token_catch = "";
            for (int i = 0; i > line_input.Length; i++) {
                if (char.IsWhiteSpace(line_input[i])) {
                    //tokenizer(token_catch, var_Register);
                    recognizer(line_input, var_Register);
                    token_catch = "";
                } else if (char.IsLetterOrDigit(line_input[i])) {
                    token_catch += line_input[i];
                }

            }
        }

        private static void tokenizer(string word, var_register var_Register) {
            switch (word) {
                case var num when new Regex(@"^[0-9]").IsMatch(num):
                    var_Register.set_variable(word, null);
                    break;
                default:
                    Console.WriteLine(word + " not recognised");
                    break;
            }
        }

        private static void recognizer(string line_input, var_register var_Register /*func_register func_Register*/) {
            string[] words = line_input.Split(' ');
            switch (words[0]) {
                case "if":
                    //if_statement()
                    break;
                case "while":
                    //while_loop()
                    break;
                case "for":
                    break;
                case var temp_regex when new Regex(@"^[a-zA-Z0-9/_]+").IsMatch(temp_regex):
                    if (words[1] == "=") {
                        //check for interger
                        if (new Regex(@"^[0-9]+").IsMatch(words[2])) {
                            int temp_int = 0;
                            getIntFromString(words[2], temp_int);
                            var_Register.set_variable(words[0], temp_int);
                            Console.WriteLine(words[0] + " " + temp_int);
                        }
                        //check for bool
                        else if (words[2] == "true") {
                            var_Register.set_variable(words[0], true);
                        }
                        else if (words[2] == "false") {
                            var_Register.set_variable(words[0], false);
                        }
                        //check for string
                        //else if (check first and last char are quotes) {
                        //}

                    }
                    //check if next item is equal
                    //if not check if function exists
                    break;
                default:
                    Console.WriteLine("Symbole " + words[0] + " not defined");
                    break;
            }

        }
        //extract interger value from string
        private static void getIntFromString(string string_input, int temp_int) {
            try {
                temp_int = int.Parse(string_input);
            } catch (FormatException) {
                Console.WriteLine("Unable to parse " +string_input);
            }
        }


        public void token(string panda_line) {
            //slice off items by white spaces
            string[] tokens = panda_line.Split(' ');
            string cache = "";
            for (int i = 0; i < tokens.Length; i++) {
                if (tokens[i].is)
            }
        }



        enum kw {
            //selection
            IF,
            ELSE_IF,
            ELSE,
            //iteration
            WHILE,
            FOR,
            //opertion
            INC,
            DEC,
            ADD,
            SUM,
            MULT,
            DIV,
            SQRT,
            //delcaration
            VAR,
            //data types
            INT,
            STR,
            FLOAT,
            BOOL
        }

        public static void _lexer(string[] panda_source) {
            
        }
    }
}