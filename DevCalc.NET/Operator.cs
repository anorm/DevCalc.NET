using System;

namespace DevCalcNET
{
    public abstract class Operator : MathNode
	{
        public int OperandCount
        {
            get
            {
                object[] attrs = this.GetType().GetCustomAttributes(typeof(OperandCountAttribute), false);
                if(attrs.Length == 0)
                {
                    throw new Exception(string.Format("Operator {0} does not specify OperandCount", this.GetType().Name));
                }
                return ((OperandCountAttribute)attrs[0]).Count;
            }
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
