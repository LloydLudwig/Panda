using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Panda {
    class Utils{
        // take in file_name and string list to store line in
        // the file must be in the same folder
        // this could be changed but that's for later
        public static void parse(String file_name, List<String> code_line){
            // open file and store in code
            var code_file = new FileStream(/*Directory.GetCurrentDirectory()*/ @file_name, FileMode.Open, FileAccess.Read);
            try {
                using (var streamReader = new StreamReader(code_file, Encoding.UTF8)){
                    string line; // temporary store of te
                    // check if the end of the file has been reached
                    while ((line = streamReader.ReadLine()) != null){
                        code_line.Add(line);
                    }
                }
            } catch(Exception ex){
                Console.WriteLine("could not open file");
                Console.WriteLine(ex);
            }
        }
    }
}