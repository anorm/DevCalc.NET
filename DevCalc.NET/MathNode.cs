using System;

namespace DevCalcNET
{
	public abstract class MathNode
	{
		private MathNodeCollection children;

		public MathNode()
		{
			children = new MathNodeCollection();
		}

		public abstract double Evaluate();

        public virtual string ToMathML()
        {
            return "<ci>" + ToString() + "</ci>";
        }
	}
}
