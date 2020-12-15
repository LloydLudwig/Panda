using System.Collections.Generic;

namespace Panda {
    class func_register {
        /// <summary>
        /// store function name and line number as key and value pair in a Dictionary
        /// </summary>
        private Dictionary<string, int> P_func = new Dictionary<string, int>();

        /// <summary>
        /// function register object
        /// </summary>
        public func_register() {

        }

        /// <summary>
        /// create new function
        /// </summary>
        /// <param name="func_name">function name</param>
        /// <param name="func_line">function value</param>
        public void set_func(string func_name, int func_line) {
            P_func.Add(func_name, func_line);
        }

        /// <summary>
        /// get function line number
        /// </summary>
        /// <param name="func_name">function name</param>
        /// <returns>line number of function</returns>
        public int get_func(string func_name) {
            int func_line;
            P_func.TryGetValue(func_name, out func_line);
            return func_line;
        }
    }
}
