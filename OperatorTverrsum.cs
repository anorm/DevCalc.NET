using System;

namespace DevCalc.NET
{
	public class OperatorTverrsum : Operator
	{
		public override int OperandCount
		{
			get
			{
				return 1;
			}
		}

		public OperatorTverrsum()
		{
		}

		public override double Evaluate()
		{
			int i = (int)Children[0].Evaluate();
			return (double)Tverrsum(i);
		}

		private int Tverrsum(int value)
		{
			int i = value;
			int ret = 0;
			while(i > 0)
			{
				ret += (i % 10);
				i /= 10;
			}
			if(ret >= 10)
			{
				ret = Tverrsum(ret);
			}
			return ret;
		}

		public override string ToString()
		{
			return "tverrsum(" + Children[0].ToString() + ")";
		}


	}
}
