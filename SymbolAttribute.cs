using System;
using System.Collections.Generic;
using System.Text;

namespace DevCalcNET
{
    [AttributeUsage(AttributeTargets.All)]
    public class SymbolAttribute : Attribute
    {
        private string myName;
        public SymbolAttribute(string name)
        {
            myName = name;
        }
        public string Name
        {
            get
            {
                return myName;
            }
        }
    }

}
