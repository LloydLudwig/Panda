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
            string[] temp_line_array = temp_line.Split(' ');
            var_Register.setVariable(temp_line_array[1], temp_line_array[3]);
            Console.WriteLine("[info]: variable " + temp_line_array[1] + " stores " + var_Register.getVariable(temp_line_array[1]));
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