using System;
using System.Collections.Generic;
using System.Text;

namespace DevCalc.NET
{
    class StringExpression : MathNode
    {
        private string val;

        public string Value
        {
            get { return val; }
            set { val = value; }
        }

        public StringExpression(string val)
        {
            this.val = val;
        }

        public override double Evaluate()
        {
            throw new Exception("StringExpressions can't be evaluated");
        }

        public override string ToString()
        {
            return val;
        }
    }
}
