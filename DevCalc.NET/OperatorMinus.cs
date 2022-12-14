[DevCalcNET.SymbolAttribute("-")]
[DevCalcNET.OperandCountAttribute(2)]
class OperatorMinus : DevCalcNET.Operator
{
	public override double Evaluate()
	{
		return Children[0].Evaluate() - Children[1].Evaluate();
	}

	public override string ToString()
	{
		return "(" + Children[0].ToString() + " - " + Children[1].ToString() + ")";
	}

    public override string ToMathML()
    {
        return "<mrow>" + Children[0].ToMathML() + "<mo>&minus;</mo>" + Children[1].ToMathML() + "</mrow>";
    }
}
