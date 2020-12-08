using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Panda {
    class Parser{
        public static List<string> parse(String file_name){
            List<string> code = new List<string>();
            //open file and store in code
            var code_file = new FileStream(@file_name, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(code_file, Encoding.UTF8)){
                string line;
                while ((line = streamReader.ReadLine()) != null){
                    code.Add(line);
                }
            }
            return code;
        }
    }
}