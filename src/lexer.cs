using System;
using System.Text.RegularExpressions;

namespace Panda {
    class lexer {


        /// <summary>
        /// store the current language keywords
        /// </summary>
        public struct kw {

            public kw(string[] lang_kw){
                //make sure the language file is complete
                //this is currently hardcoded
                //this may be cause of problems as new key words are added
                if(lang_kw.Length != 0 || lang_kw.Length != 21){
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

        //to be used as reference
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

        public static kw_index match_kw(string kw, kw lang_kw){
            if (kw[0].ToString() == lang_kw.COMMENT){
                return lexer.kw_index.COMMENT;
            }
            if (kw == lang_kw.IF)      { return lexer.kw_index.IF; }
            if (kw == lang_kw.ELSE_IF) { return lexer.kw_index.ELSE_IF; }
            if (kw == lang_kw.ELSE)    { return lexer.kw_index.ELSE; }
            if (kw == lang_kw.WHILE)   { return lexer.kw_index.WHILE; }
            if (kw == lang_kw.FOR)     { return lexer.kw_index.FOR; }
            if (kw == lang_kw.INC)     { return lexer.kw_index.INC; }
            if (kw == lang_kw.DEC)     { return lexer.kw_index.ADD; }
            if (kw == lang_kw.ADD)     { return lexer.kw_index.ADD; }
            if (kw == lang_kw.SUB)     { return lexer.kw_index.SUB; }
            if (kw == lang_kw.MULT)    { return lexer.kw_index.MULT; }
            if (kw == lang_kw.DIV)     { return lexer.kw_index.DIV; }
            if (kw == lang_kw.SQRT)    { return lexer.kw_index.SQRT; }
            if (kw == lang_kw.VAR)     { return lexer.kw_index.VAR; }
            if (kw == lang_kw.INT)     { return lexer.kw_index.INT; }
            if (kw == lang_kw.STR)     { return lexer.kw_index.STR; }
            if (kw == lang_kw.FLOAT)   { return lexer.kw_index.FLOAT; }
            if (kw == lang_kw.BOOL)    { return lexer.kw_index.BOOL; }

            return lexer.kw_index.NULL;

        }

        public static void _lexer(string[] panda_source, kw lang_kw) {
            for (int i = 0; i > panda_source.Length; i++) {
                string[] temp_line = panda_source[i].Split(' ');
                for(int j = 0; j > temp_line.Length; j++){
                    switch (match_kw(temp_line[j], lang_kw)) {
                        case kw_index.VAR:
                            Console.WriteLine(temp_line[2]);
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

        //load the keywords from the .lang file
        private static string[] load_kw(string[] list_code) {

            return null;
        }
    }
}