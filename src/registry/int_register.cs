using System;
using System.Collections.Generic;

namespace Panda {

	class int_register {

		/// <summary>
		///	variable name is the key adn the variable value is the integer variable
		/// </summary>
		private Dictionary<string, int> panda_int = new Dictionary<string, int>();

		/// <summary>
		///	integer variable register object
		/// </summary>
		public int_register(){

		}

		/// <summary>
		///	create interger variable
		/// </summary>
		/// <param name="var_name">name of new variable</param>
        /// <param name="int_value">value of new variable</param>
        public void setVariable(string var_name, int int_value) {
            panda_int.Add(var_name, int_value);
        }

		/// <summary>
        /// get integer value
        /// </summary>
        /// <param name="var_name"> the name of the variable </param>
        /// <returns>dynamic variable value</returns>
        public int getVariable(string var_name) {
            try {
                int var_value;
                panda_int.TryGetValue(var_name, out var_value);
                return var_value;
            }catch (KeyNotFoundException) {
                Console.WriteLine("[warning]: integer variable " + var_name + " does not exist in the current context");
				return 0;
            }
        }


	}

}
