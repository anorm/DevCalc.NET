using System;
using System.Collections.Generic;
using System.Text;

namespace DevCalcNET
{
    [AttributeUsage(AttributeTargets.All)]
    public class OperandCountAttribute : Attribute
    {
        private int operandCount;
        public OperandCountAttribute(int count)
        {
            operandCount = count;
        }
        public int Count
        {
            get
            {
                return operandCount;
            }
        }
    }
}
