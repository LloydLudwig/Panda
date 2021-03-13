using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.execution {
    class ouput {
        
        public static void _output(string rawOutputData) {
            string processed = integer.repaceIntReference(extractBracketContent(rawOutputData));
            processed.Replace("(", "");
            processed.Replace(")", "");
            Console.WriteLine(processed);
        }

        private static string extractBracketContent(string bracketWrappedExpression) {
            //check if it contains brackets
            //if so extract the content of the brackets without the brackets
            if (bracketWrappedExpression.Contains('(')) {
                return bracketWrappedExpression.Substring(bracketWrappedExpression.IndexOf('('));
            }
            else if (bracketWrappedExpression.Contains('[')) {
                return bracketWrappedExpression.Substring(bracketWrappedExpression.IndexOf('['));
            }
            else if (bracketWrappedExpression.Contains('{')) {
                return bracketWrappedExpression.Substring(bracketWrappedExpression.IndexOf('{'));
            }
            else {
                return bracketWrappedExpression;
            }
        }
    }
}
