using System;

namespace DevCalc.NET
{
	public abstract class MathNode
	{
		private MathNodeCollection children;

		public MathNode()
		{
			children = new MathNodeCollection();
		}

		public abstract double Evaluate();
	}
}
