using System;

namespace Panda {
    class lexer {

        public lexer(){

        }

        /// <summary>
        /// store the current language keywords
        /// </summary>
        public struct kw {

            /// <summary>
            /// take string from array and store according
            /// </summary>
            ///<param name="lang_kw"> contains the langauge key words in the right order</param>
            public kw(string[] lang_kw){
                //make sure the language file is complete
                //this is currently hardcoded
                //this may be cause of problems as new key words are added
                if(lang_kw.Length != 0){
                    //selection
                    IF = lang_kw[0];
                    ELSE_IF = lang_kw[1];
                    ELSE = lang_kw[2];
                    END_IF = lang_kw[3];
                    //iteration
                    WHILE = lang_kw[4];
                    END_WHILE = lang_kw[5];
                    FOR = lang_kw[6];
                    END_FOR = lang_kw[7];
                    //operation
                    INC = lang_kw[8];
                    DEC = lang_kw[9];
                    ADD = lang_kw[10];
                    SUB = lang_kw[11];
                    MULT = lang_kw[12];
                    DIV = lang_kw[13];
                    SQRT = lang_kw[14];
                    //delcaration
                    VAR = lang_kw[15];
                    //data types
                    INT = lang_kw[16];
                    STR = lang_kw[17];
                    FLOAT = lang_kw[18];
                    BOOL = lang_kw[19];
                    COMMENT = lang_kw[20];
                }
                //failsafe incase the default langauge file is not found, this will be used
                //the default language file has been left in to give users a template to work with
                else{
                    IF = "if";
                    ELSE_IF = "else_if";
                    ELSE = "else";
                    END_IF = "end_if";
                    //iteration
                    WHILE = "while";
                    END_WHILE = "end_while";
                    FOR = "for";
                    END_FOR = "end_for";
                    //operation
                    INC = "++";
                    DEC = "--";
                    ADD = "+";
                    SUB = "-";
                    MULT = "*";
                    DIV = "/";
                    SQRT = "**";
                    //delcaration
                    VAR = "var";
                    //data types
                    INT = "int";
                    STR = "str";
                    FLOAT = "float";
                    BOOL = "bool";
                    COMMENT = "//";

                    Console.WriteLine("[Warning]: in-build english language keys have been loaded");
                }

            }
            // will store the current language tokens as appropriate
            // they only have getters as they should not be rewritten
            public string IF {get;}
            public string ELSE_IF {get;}
            public string ELSE {get;}
            public string END_IF {get;}
            public string WHILE {get;}
            public string END_WHILE {get;}
            public string FOR {get;}
            public string END_FOR {get;}
            public string INC {get;}
            public string DEC {get;}
            public string ADD {get;}
            public string SUB {get;}
            public string MULT {get;}
            public string DIV {get;}
            public string SQRT {get;}
            public string VAR {get;}
            public string INT {get;}
            public string STR {get;}
            public string FLOAT {get;}
            public string BOOL {get;}
            public string COMMENT {get;}
        }

        //enumeration of the key words
        //it only exits as a bridge between the actual tokens and the switch statement
        public enum kw_index {
            //selection
            IF, ELSE_IF, ELSE, END_IF,

            //iteration
            WHILE, END_WHILE, FOR, END_FOR,

            //operation
            INC, DEC,
            ADD, SUB, MULT , DIV, SQRT,

            //store
            VAR, INT, STR, FLOAT, BOOL,

            NULL, //whitespace or unrecognised
            COMMENT //comments
        };

        //match which laguage
        private static kw_index match_kw(string kw, kw lang_kw){
            if (kw[0].ToString() == lang_kw.COMMENT){
                return lexer.kw_index.COMMENT;
            }
            //there is no switch case because it requires constant values
            //constat data is initialised at compile time
            if (kw == lang_kw.IF)       { return lexer.kw_index.IF; }
            if (kw == lang_kw.ELSE_IF)  { return lexer.kw_index.ELSE_IF; }
            if (kw == lang_kw.ELSE)     { return lexer.kw_index.ELSE; }
            if (kw == lang_kw.END_IF)   { return lexer.kw_index.END_IF; }
            if (kw == lang_kw.WHILE)    { return lexer.kw_index.WHILE; }
            if (kw == lang_kw.END_WHILE){ return lexer.kw_index.END_WHILE; }
            if (kw == lang_kw.FOR)      { return lexer.kw_index.FOR; }
            if (kw == lang_kw.END_FOR)  { return lexer.kw_index.END_FOR; }
            if (kw == lang_kw.INC)      { return lexer.kw_index.INC; }
            if (kw == lang_kw.DEC)      { return lexer.kw_index.ADD; }
            if (kw == lang_kw.ADD)      { return lexer.kw_index.ADD; }
            if (kw == lang_kw.SUB)      { return lexer.kw_index.SUB; }
            if (kw == lang_kw.MULT)     { return lexer.kw_index.MULT; }
            if (kw == lang_kw.DIV)      { return lexer.kw_index.DIV; }
            if (kw == lang_kw.SQRT)     { return lexer.kw_index.SQRT; }
            if (kw == lang_kw.VAR)      { return lexer.kw_index.VAR; }
            if (kw == lang_kw.INT)      { return lexer.kw_index.INT; }
            if (kw == lang_kw.STR)      { return lexer.kw_index.STR; }
            if (kw == lang_kw.FLOAT)    { return lexer.kw_index.FLOAT; }
            if (kw == lang_kw.BOOL)     { return lexer.kw_index.BOOL; }
            return lexer.kw_index.NULL;

        }

        /// <summary>
        /// loop through each line and the the key words which will be sorted by the switch case and executed appropriately
        /// </summary>
        /// <param name="panda_source"> Panda code, each index is a line</param>
        /// <param name="lang_kw"> the language tokens </param>
        /// <param name="var_Register"> main varible register </param>
        public static void run(string[] panda_source, kw lang_kw, var_register var_Register) {
            Console.WriteLine("[info]: initialising panda code");
            //looping through each line in the file
            for (int program_counter = 0; program_counter < panda_source.Length; program_counter++) {
                string[] temp_line = panda_source[program_counter].Split(' ');
                Console.WriteLine("[info]: processing line " + program_counter);

                //looping through each token in the line
                for(int j = 0; j < temp_line.Length; j++){

                    //process current token
                    switch (match_kw(temp_line[j], lang_kw)) {
                        case kw_index.VAR:
                            var_Register.set_variable(temp_line[1], temp_line[3]);
                            Console.WriteLine("[info]: variable " + temp_line[1] + " stores " + var_Register.getVariable(temp_line[1]));
                            break;
                        case kw_index.INT:
                            break;
                        case kw_index.STR:
                            break;
                        case kw_index.FLOAT:
                            break;
                        case kw_index.BOOL:
                            break;
                        case kw_index.NULL:
                            break;
                        case kw_index.COMMENT:
                            break;
                    }
                }
            }
        }

        [Obsolete("this function's pourpose has been replaced by Utils.parseFileToArray()")]
        //load the keywords from the .lang file
        private static string[] load_kw(string[] list_code) {

            return null;
        }

        /// <summary>
        /// create generic variable
        /// </summary>
        /// <param name="temp_line"> the line containing the variable declartion </param>
        /// <param name="var_Register"> the main variable storage </param>
        private void var(string[] temp_line, var_register var_Register){
            var_Register.set_variable(temp_line[1], temp_line[3]);
        }
    }
}