using System;

namespace DevCalcNET
{
    [SymbolAttribute("dsum")]
    [OperandCountAttribute(1)]
    class OperatorDigitSum : Operator
	{
		public override double Evaluate()
		{
            Int64 i = (Int64)Math.Round(Children[0].Evaluate());
			return (double)Tverrsum(i);
		}

        private Int64 Tverrsum(Int64 value)
		{
            Int64 i = value;
            Int64 ret = 0;
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
			return "dsum(" + Children[0].ToString() + ")";
		}

        public override string ToMathML()
        {
            return "<mrow><mo>dsum</mo><mo>(</mo>" + Children[0].ToMathML() + "<mo>)</mo></mrow>";
        }
    }
}
