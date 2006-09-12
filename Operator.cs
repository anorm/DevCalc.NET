using System;

namespace DevCalc.NET
{
	public abstract class Operator : MathNode
	{
		public abstract int OperandCount
		{
			get;
		}

		private MathNodeCollection children;
		public MathNodeCollection Children
		{
			get{return children;}
		}

		public Operator()
		{
			children = new MathNodeCollection();
		}
	}
}
