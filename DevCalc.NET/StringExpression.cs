using System;
using System.Collections.Generic;
using System.Text;

namespace DevCalcNET
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

        public override string ToMathML()
        {
            return "<ci>" + val + "</ci>";
        }
    }
}
