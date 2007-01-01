using System;

namespace DevCalcNET
{
	class Constant : MathNode
	{
		private double val;

		public Constant(double value)
		{
			val = value;
		}

		public override double Evaluate()
		{
			return val;
		}

		public override string ToString()
		{
			return string.Format("{0}", val);
		}

        public override string ToMathML()
        {
            return "<mn>" + ToString() + "</mn>";
        }
	}
}
