using System;

namespace DevCalc.NET
{
	public class OperatorE : Operator
	{
		public override int OperandCount
		{
			get
			{
				return 0;
			}
		}

        public OperatorE()
		{
		}

		public override double Evaluate()
		{
			return Math.E;
		}

		public override string ToString()
		{
			return "E";
		}
	}
}
