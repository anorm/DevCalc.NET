using System;

namespace DevCalc.NET
{
	/// <summary>
	/// Summary description for OperatorPower.
	/// </summary>
	public class OperatorPower : Operator
	{
		public override int OperandCount
		{
			get
			{
				return 2;
			}
		}

		public OperatorPower() : base()
		{
		}

		public override double Evaluate()
		{
			return Math.Pow(Children[0].Evaluate(), Children[1].Evaluate());
		}

		public override string ToString()
		{
			return "(" + Children[0].ToString() + " ^ " + Children[1].ToString() + ")";
		}
	}
}
