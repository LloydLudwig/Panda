using System;

namespace Panda {

    public static class token{

        /// <summary>
        /// store the current language keywords
        /// </summary>
        public struct kw {

            /// <summary>
            /// take string from array and store according
            /// </summary>
            ///<param name="lang_kw"> contains the langauge key words in the right order</param>
            public kw(string[] lang_kw) {
                //make sure the language file is complete
                //this is currently hardcoded
                //this may be cause of problems as new key words are added
                if (lang_kw.Length != 0) {
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
                    //IO
                    OUTPUT = lang_kw[21];
                }
                //failsafe incase the default langauge file is not found, this will be used
                //the default language file has been left in to give users a template to work with
                else {
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
                    //IO
                    OUTPUT = "print";


                    Console.WriteLine("[Warning]: in-build english language keys have been loaded");
                }

            }
            // will store the current language tokens as appropriate
            // they only have getters as they should not be rewritten
            public string IF { get; }
            public string ELSE_IF { get; }
            public string ELSE { get; }
            public string END_IF { get; }
            public string WHILE { get; }
            public string END_WHILE { get; }
            public string FOR { get; }
            public string END_FOR { get; }
            public string INC { get; }
            public string DEC { get; }
            public string ADD { get; }
            public string SUB { get; }
            public string MULT { get; }
            public string DIV { get; }
            public string SQRT { get; }
            public string VAR { get; }
            public string INT { get; }
            public string STR { get; }
            public string FLOAT { get; }
            public string BOOL { get; }
            public string COMMENT { get; }
            public string OUTPUT { get; }
        }

        //enumeration of the key words
        //it only exits as a bridge between the actual tokens and the switch statement
        /// <summary>
        /// enum to reference to language
        /// </summary>
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
            COMMENT, //comments

            OUTPUT
        };

        //match which language tokens with the kw_index enum
        public static kw_index match_kw(string kw, kw lang_kw){
            if (kw== lang_kw.COMMENT){
                return kw_index.COMMENT;
            }
            //there is no switch case because it requires constant values
            //constat data is initialised at compile time
            if (kw == lang_kw.IF)             { return kw_index.IF; }
            else if (kw == lang_kw.ELSE_IF)   { return kw_index.ELSE_IF; }
            else if (kw == lang_kw.ELSE)      { return kw_index.ELSE; }
            else if (kw == lang_kw.END_IF)    { return kw_index.END_IF; }
            else if (kw == lang_kw.WHILE)     { return kw_index.WHILE; }
            else if (kw == lang_kw.END_WHILE) { return kw_index.END_WHILE; }
            else if (kw == lang_kw.FOR)       { return kw_index.FOR; }
            else if (kw == lang_kw.END_FOR)   { return kw_index.END_FOR; }
            else if (kw == lang_kw.INC)       { return kw_index.INC; }
            else if (kw == lang_kw.DEC)       { return kw_index.ADD; }
            else if (kw == lang_kw.ADD)       { return kw_index.ADD; }
            else if (kw == lang_kw.SUB)       { return kw_index.SUB; }
            else if (kw == lang_kw.MULT)      { return kw_index.MULT; }
            else if (kw == lang_kw.DIV)       { return kw_index.DIV; }
            else if (kw == lang_kw.SQRT)      { return kw_index.SQRT; }
            else if (kw == lang_kw.VAR)       { return kw_index.VAR; }
            else if (kw == lang_kw.INT)       { return kw_index.INT; }
            else if (kw == lang_kw.STR)       { return kw_index.STR; }
            else if (kw == lang_kw.FLOAT)     { return kw_index.FLOAT; }
            else if (kw == lang_kw.BOOL)      { return kw_index.BOOL; }
            else if (kw == lang_kw.OUTPUT)    { return kw_index.OUTPUT; }
            return kw_index.NULL;

        }
    }

}