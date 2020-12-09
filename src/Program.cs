using System;
using System.Collections.Generic;


namespace Panda {

    class Program {

        static void Main(string[] args) {
            List<string> code_line = new List<string>();
            Utils.parse(args[0], code_line);
            Console.Write(code_line[0]);
        }
    }
}
