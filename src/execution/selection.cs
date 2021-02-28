using System;
using System.Text;
using System.Collections.Generic;

namespace Panda{
    class selection{
        public static int IF(string line, int_register int_Register, int currentProgramCounter){
            string bracket = extractBracketContent(line);
            Console.WriteLine(bracket);
            StringBuilder numBuffer = new StringBuilder().Append(integer.repaceIntReference(extractBracketContent(bracket), int_Register));
            Console.WriteLine(numBuffer);
            string[] expression = numBuffer.ToString().Split(' ');

            // evalBracket(numBuffer.ToString());

            Console.WriteLine(evalBracket(expression));
            return currentProgramCounter;
        }

        private static string extractBracketContent(string bracketWrappedExpression){
            //check if it contains brackets
            //if so extract the content of the brackets without the brackets
            if (bracketWrappedExpression.Contains('(')){
                    return bracketWrappedExpression.Substring(bracketWrappedExpression.IndexOf('('));
                }else if (bracketWrappedExpression.Contains('[')){
                    return bracketWrappedExpression.Substring(bracketWrappedExpression.IndexOf('['));
                }else if (bracketWrappedExpression.Contains('{')){
                    return bracketWrappedExpression.Substring(bracketWrappedExpression.IndexOf('{'));
                }else {
                    return bracketWrappedExpression;
                }
        }

        private static bool evalBracket(string bracket){
            // Stack for numbers: 'values'
            Stack<int> values = new Stack<int>();

            // Stack for Operators: 'ops'
            Stack<string> ops = new Stack<string>();
            //store booelan operators
            StringBuilder opsBuffer = new StringBuilder();
            for (int i = 0; i < bracket.Length; i++){
                //check for the boolean operators
                if (bracket[i] == '>' ||
                    bracket[i] == '<' ||
                    bracket[i] == '=' ||
                    bracket[i] == '!'){
                        if (opsBuffer.Length < 2){
                        opsBuffer.Append(bracket[i]);
                        continue;
                        }else{
                            ops.Push(opsBuffer.ToString());
                            opsBuffer.Clear();
                        }
                }

                if (bracket[i] >= '0' && bracket[i] <= '9'){

                }
            }
            return true;
        }

        private static bool evalBracket(string[] bracket){
            switch (bracket[1]){
                case "==":
                    if (int.Parse(bracket[0]) == int.Parse(bracket[2])){
                        return true;
                    }else{
                        return false;
                    }
                case ">=":
                    if (int.Parse(bracket[0]) >= int.Parse(bracket[2])){
                        return true;
                    }else{
                        return false;
                    }
                case "<=":
                    if (int.Parse(bracket[0]) <= int.Parse(bracket[2])){
                        return true;
                    }else{
                        return false;
                    }
                case "!=":
                    if (int.Parse(bracket[0]) != int.Parse(bracket[2])){
                        return true;
                    }else{
                        return false;
                    }
                case "<":
                    if (int.Parse(bracket[0]) < int.Parse(bracket[2])){
                        return true;
                    }else{
                        return false;
                    }
                case ">":
                    if (int.Parse(bracket[0]) > int.Parse(bracket[2])){
                        return true;
                    }else{
                        return false;
                    }
                default:
                    Console.WriteLine("[warning]: symbole " + bracket[1] + " is not defined");
                    return false;
            }
        }
    }
}