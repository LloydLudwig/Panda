using System;
using System.Collections.Generic;

namespace Panda {

    public class integer : variable{
        public static void create(string temp_line, int_register int_Register){
            string bracketContent = extractBracketContent(temp_line);
            string[] temp_line_array = temp_line.Split(' ');
            //this will replace all the variable tokens with the values of the variables
            if (bracketContent != null){
                List<string> otherVairableReferences = new List<string>();
                string tempVariable = "";
                int startOfVariable = 0;
                for (int index = 0; index < bracketContent.Length; index++){
                    if (char.IsLetter(bracketContent[index])){
                        tempVariable = tempVariable + bracketContent[index];
                        startOfVariable = index;
                    } else if (!(char.IsLetter(bracketContent[index])) && tempVariable.Length > 0) {
                        bracketContent = bracketContent.Replace(tempVariable, int_Register.getVariable(tempVariable).ToString());
                        tempVariable = "";
                    }
                }
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
    }

}