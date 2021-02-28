using System;
using System.Collections.Generic;

namespace Panda {

    public class integer : variable{
        public static void create(string temp_line, int_register int_Register){
            string bracketContent = extractBracketContent(temp_line);
            string[] temp_line_array = temp_line.Split(' ');
            //this will replace all the variable tokens with the values of the variables
            if (bracketContent != null){
                bracketContent = repaceIntReference(bracketContent, int_Register);
            int_Register.setVariable(temp_line_array[1], EvaluateString.evaluate(bracketContent));
            } else{ /*if the variable stores no*/
                int_Register.setVariable(temp_line_array[1], EvaluateString.evaluate(temp_line_array[temp_line_array.Length - 1]));
            }
            if (temp_line_array[0] == "int"){
                Console.WriteLine("[info]: integer variable " + temp_line_array[1] + " stores " + int_Register.getVariable(temp_line_array[1]));
            }else {
                Console.WriteLine("[info]: integer variable " + temp_line_array[0] + " stores " + int_Register.getVariable(temp_line_array[1]));
            }
        }

        public static string repaceIntReference(string bracket, int_register int_Register){
            List<string> otherVairableReferences = new List<string>();
                string tempVariable = "";
                int startOfVariable = 0;
                for (int index = 0; index < bracket.Length; index++){
                    if (char.IsLetter(bracket[index])){
                        tempVariable = tempVariable + bracket[index];
                        startOfVariable = index;
                    } else if (!(char.IsLetter(bracket[index])) && tempVariable.Length > 0) {
                        bracket = bracket.Replace(tempVariable, int_Register.getVariable(tempVariable).ToString());
                        tempVariable = "";
                    }
                }
            return bracket;
        }
    }

}