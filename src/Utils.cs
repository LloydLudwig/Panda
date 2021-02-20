using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace Panda {
    class Utils{

        /// <summary>
        /// read file_name and store in string list
        /// and return in string array
        /// </summary>
        /// <param name="file_name">name of code file</param>
        public static string[] parseFileToArray(String file_name){
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
                Console.WriteLine("[info]: " + file_name + " has been loaded in memory");
                return code_line_list.ToArray();
            } catch(FileNotFoundException){
                // if error accours while opening file
                Console.WriteLine("[Warning]: file " + file_name + " could not be found");
                return new string[0];
            } catch(System.IO.DirectoryNotFoundException){
                Console.WriteLine("[Warning]: Dictionary " + file_name + " could not be found");
                return new string[0];
            }
        }

        //return the working directory of the executable of panda, it's purpose it to abstract the long concatenation
        public static string getWorkingDir(){
            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }

        [Obsolete("crashes when there are brackets in the expression")]
        /// <sumary>
        /// evaluate a mathematical expression from a string and return the integer value
        /// </summary>
        /// <param name="expression"> mathematical expression </param>
        public static int EvaluateInteger(string expression) {
            DataTable table = new DataTable();
            table.Columns.Add("expression", string.Empty.GetType(), expression);
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            return int.Parse((string)row["expression"]);
        }

        [Obsolete("crashes when there are brackets in the expression")]
        /// <sumary>
        /// evaluate a mathematical expression from a string and return the integer value
        /// </summary>
        /// <param name="expression"> mathematical expression </param>
        public static float EvaluateFloat(string expression) {
            DataTable table = new DataTable();
            table.Columns.Add("expression", string.Empty.GetType(), expression);
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            return float.Parse((string)row["expression"]);
        }

    }
}