using System;
using System.Collections.Generic;

namespace Panda{

    public class variable{

        /// <summary>
        /// create generic variable
        /// </summary>
        /// <param name="temp_line"> the line containing the variable declartion </param>
        /// <param name="var_Register"> the main variable storage </param>
        public static void create(string temp_line, var_register var_Register){
            string bracketContent = extractBracketContent(temp_line);
            // temp_line = temp_line.Replace("var", "");
            string[] temp_line_array = temp_line.Split(' ');
            // if (bracketContent != null){
            //     List<string> otherVairableReferences = new List<string>();
            //     string tempVariable = "";
            //     int startOfVariable = 0;
            //     for (int index = 0; index < bracketContent.Length; index++){
            //         if (char.IsLetter(bracketContent[index])){
            //             tempVariable = tempVariable + bracketContent[index];
            //             startOfVariable = index;
            //         } else if (!(char.IsLetter(bracketContent[index])) && tempVariable.Length > 0) {
            //             bracketContent = bracketContent.Replace(tempVariable, var_Register.getVariable(tempVariable).ToString());
            //             tempVariable = "";
            //         }
            //     }
            //     var_Register.setVariable(temp_line_array[0], bracketContent);

            // }else {
            //     var_Register.setVariable(temp_line_array[1], temp_line_array[3]);
            // }
            var_Register.setVariable(temp_line_array[1], temp_line_array[3]);
            if (temp_line_array[0] == "var"){
                Console.WriteLine("[info]: variable " + temp_line_array[1] + " stores " + var_Register.getVariable(temp_line_array[1]));
            }else{
                Console.WriteLine("[info]: variable " + temp_line_array[0] + " stores " + var_Register.getVariable(temp_line_array[0]));
            }
        }

        public static string extractBracketContent(string variableDeclaration){
            if (variableDeclaration.Contains('(')){
                    return variableDeclaration.Substring(variableDeclaration.IndexOf('('));
                }else if (variableDeclaration.Contains('[')){
                    return variableDeclaration.Substring(variableDeclaration.IndexOf('['));
                }else if (variableDeclaration.Contains('{')){
                    return variableDeclaration.Substring(variableDeclaration.IndexOf('{'));
                }else {
                    return null;
                }
        }
    }
}