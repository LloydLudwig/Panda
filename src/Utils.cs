using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Panda {
    class Utils{

        /// <summary>
        /// read file_name and store in string list
        /// and return in string array
        /// </summary>
        /// <param name="file_name">name of code file</param>
        public static string[] parse_file_to_array(String file_name){
            List<string> code_line_list = new List<string>();
            try { // try open file
                var code_file = new FileStream( @file_name, FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(code_file, Encoding.UTF8)){
                    string line; // temporary store of the line
                    // check if the end of the file has been reached
                    while ((line = streamReader.ReadLine()) != null){
                        code_line_list.Add(line);
                    }
                }
                return code_line_list.ToArray();
            } catch(FileNotFoundException){
                // if error accours while opening file
                Console.WriteLine("Could not open file");
                return null;
            }
        }
    }
}