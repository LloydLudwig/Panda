using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Panda {
    class Utils{
        
        /// <summary>
        /// read file_name and store in code_line
        /// </summary>
        /// <param name="file_name">name of code file</param>
        /// <param name="code_line">List to store code lines</param>
        public static void parse(String file_name, List<String> code_line){
            try { // try open file
                var code_file = new FileStream( @file_name, FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(code_file, Encoding.UTF8)){
                    string line; // temporary store of te
                    // check if the end of the file has been reached
                    while ((line = streamReader.ReadLine()) != null){
                        code_line.Add(line);
                    }
                }
            } catch(FileNotFoundException){ // if error accours while opening file
                Console.WriteLine("Could not open file");
            }
        }
    }
}