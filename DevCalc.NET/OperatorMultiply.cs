using System;

namespace DevCalcNET
{
    [SymbolAttribute("*")]
    [OperandCountAttribute(2)]
    class OperatorMultiply : Operator
	{
		public override double Evaluate()
		{
			return Children[0].Evaluate() * Children[1].Evaluate();
		}

		public override string ToString()
		{
			return "(" + Children[0].ToString() + " * " + Children[1].ToString() + ")";
		}

        public override string ToMathML()
        {
            return "<mrow>" + Children[0].ToMathML() + "<mo>&times;</mo>" + Children[1].ToMathML() + "</mrow>";
        }
    }
}
