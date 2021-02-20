using System;
using System.Collections.Generic;

namespace Panda {

    class var_register{

        /// <summary>
        /// variable name is the key and variable value is the value
        /// </summary>
        private Dictionary<string, dynamic> panda_var = new Dictionary<string, dynamic>();

        /// <summary>
        /// variable register object
        /// </summary>
        public var_register() {
        }

        /// <summary>
        /// create variable
        /// </summary>
        /// <param name="var_name">name of new variable</param>
        /// <param name="var_value">value of new variable</param>
        public void setVariable(string var_name, dynamic var_value) {
            panda_var.Add(var_name, var_value);
        }

        /// <summary>
        /// get variable value
        /// </summary>
        /// <param name="var_name"> the name of the variable </param>
        /// <returns>dynamic variable value</returns>
        public dynamic getVariable(string var_name) {
            if (isVariableRegistered(var_name)){
                dynamic var_value;
                panda_var.TryGetValue(var_name, out var_value);
                return var_value;
            } else {
                Console.WriteLine("[warning]: variable " + var_name + " does not exist in the current context");
                return null;
            }
        }

        //returns whether a given variable name is in the dictionary
        public bool isVariableRegistered(string var_name){
            return panda_var.ContainsKey(var_name);
        }
    }

}