using System;
using System.Collections.Generic;

namespace Panda {

    public class integer : variable{
        public static void create(string temp_line){
            string bracketContent = extractBracketContent(temp_line);
            string[] temp_line_array = temp_line.Split(' ');
            //this will replace all the variable tokens with the values of the variables
            if (bracketContent != null){
                bracketContent = repaceIntReference(bracketContent);
            Panda.lexer.int_Register.setVariable(temp_line_array[1], math.evaluate(bracketContent));
            } else{ /*if the variable stores no*/
                Panda.lexer.int_Register.setVariable(temp_line_array[1], math.evaluate(temp_line_array[temp_line_array.Length - 1]));
            }
            if (temp_line_array[0] == "int"){
                Console.WriteLine("[info]: integer variable " + temp_line_array[1] + " stores " + Panda.lexer.int_Register.getVariable(temp_line_array[1]));
            }else {
                Console.WriteLine("[info]: integer variable " + temp_line_array[0] + " stores " + Panda.lexer.int_Register.getVariable(temp_line_array[1]));
            }
        }

        ///<summary> replace all the references of variabels in the string with the actual values</summary>
        ///<param name="bracket"> the bracket containing all the references to integers </param>
        ///<param name="Panda.lexer.int_Register"> the current instance of the integer register </param>
        public static string repaceIntReference(string bracket){
            //store variable name references to be replaced after the search
            //this is because if the variables are replaced with their value it changes the length of the string
            //thus offsetting the loop
            List<string> otherVairableReferences = new List<string>();
            string tempVariable = "";
            int startOfVariable = 0;
            for (int index = 0; index < bracket.Length; index++){
                if (char.IsLetter(bracket[index])){
                    //check if current char it's part of a varible name
                    tempVariable = tempVariable + bracket[index];
                    startOfVariable = index;

                } else if (!(char.IsLetter(bracket[index])) && tempVariable.Length > 0) {
                    //check if current char is not a letter and it there is any variable names in the tempVariable
                    //if true then the variable name has ended and can be added to the (otherVairableReferences)
                    //to be replaced after
                    //also check that the variable has been registered
                    if (Panda.lexer.int_Register.isIntegerRegistered(tempVariable)) {
                        otherVairableReferences.Add(tempVariable);
                    }
                    tempVariable = "";
                }
            }
            //takes each string (variableName) in the list (otherVariableRefrences)
            //and runs the replace function for each one of them
            foreach (string variableName in otherVairableReferences) {
                bracket = bracket.Replace(variableName, Panda.lexer.int_Register.getVariable(variableName).ToString());
            }
            return bracket;
        }
    }

}