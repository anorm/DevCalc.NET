using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace DevCalcNET
{
    class MathParser
    {
        private struct OperatorData
        {
            public Type   operatorType;
            public string symbol;
        }

        private List<OperatorData> operators;

        public MathParser()
        {
            operators = new List<OperatorData>();

            ResetOperators();
        }

        public void ResetOperators()
        {
            operators.Clear();

            AddOperator(typeof(OperatorKurs));
            AddOperator(typeof(OperatorPI));
            AddOperator(typeof(OperatorE));
            AddOperator(typeof(OperatorSinus));
            AddOperator(typeof(OperatorCosinus));
            AddOperator(typeof(OperatorTangens));
            AddOperator(typeof(OperatorLn));
            AddOperator(typeof(OperatorLog2));
            AddOperator(typeof(OperatorLog));
            AddOperator(typeof(OperatorTverrsum));
            AddOperator(typeof(OperatorSqrt));
            AddOperator(typeof(OperatorPower));
            AddOperator(typeof(OperatorDivide));
            AddOperator(typeof(OperatorMultiply));
            AddOperator(typeof(OperatorMinus));
            AddOperator(typeof(OperatorPlus));
        }

        public void AddOperator(Type operatorType)
        {
            OperatorData data = new OperatorData();
            data.operatorType = operatorType;
            object[] attrs = operatorType.GetCustomAttributes(typeof(SymbolAttribute), false);
            if(attrs.Length == 0)
            {
                throw new Exception(string.Format("Operator {0} does not specify SymbolAttribute", operatorType.Name));
            }

            data.symbol = ((SymbolAttribute)attrs[0]).Name;
            operators.Add(data);
        }

        public double Parse(string expression)
        {
            MathNode node = ParseIntoTree(expression);

            System.Diagnostics.Debug.WriteLine(node.ToString());

            return node.Evaluate();
        }

        private MathNode ParseIntoTree(string expression)
        {
            MathNodeCollection nodes = new MathNodeCollection();

            string exp = expression;

            foreach (OperatorData op in operators)
            {
                string s = op.symbol;
                exp = exp.Replace(s, " " + s + " ");
            }
            exp = exp.Replace("(", " ( ");
            exp = exp.Replace(")", " ) ");

            string[] parts = exp.Split(' ');
            for (int i = 0; i < parts.Length; i++)
            {
                string part = parts[i];
                if (part.Trim() == "")
                {
                    continue;
                }
                if (part == "(")
                {
                    int depth = 1;
                    string str = "";
                    i++;
                    for (; i < parts.Length; i++)
                    {
                        part = parts[i];
                        if (part == "(")
                        {
                            depth++;
                        }
                        else if (part == ")")
                        {
                            depth--;
                            if (depth == 0)
                            {
                                str = str.Trim();
                                nodes.Add(ParseIntoTree(str));
                                break;
                            }
                        }
                        str += part + " ";
                    }
                    continue;
                }
                MathNode node = MakeNode(part);
                nodes.Add(node);
            }
            foreach (OperatorData op in operators)
            {
                bool found;
                do
                {
                    found = false;
                    for (int i = 0; i < nodes.Count; i++)
                    {
                        if (nodes[i].GetType() == op.operatorType)
                        {
                            Operator oper = (Operator)nodes[i];
                            if (oper.OperandCount == oper.Children.Count)
                            {
                                continue;
                            }
                            found = true;
                            if (oper.OperandCount == 2)
                            {
                                oper.Children.Add(nodes[i - 1]);
                                oper.Children.Add(nodes[i + 1]);
                                nodes.RemoveAt(i + 1);
                                nodes.RemoveAt(i - 1);
                            }
                            else if (oper.OperandCount == 1)
                            {
                                oper.Children.Add(nodes[i + 1]);
                                nodes.RemoveAt(i + 1);
                            }
                            break;
                        }
                    }
                } while (found);
            }

            return nodes[0];
        }

        private MathNode MakeNode(string val)
        {
            val = val.Trim();
            foreach (OperatorData op in operators)
            {
                string s = op.symbol;
                if (s.ToUpper() == val.ToUpper())
                {
                    Type t = op.operatorType;
                    Operator o = (Operator)(t.InvokeMember("", System.Reflection.BindingFlags.CreateInstance, null, null, null));
                    return o;
                }
            }
            if (val.StartsWith("0x"))
            {
                return new Constant(Int64.Parse(val.Remove(0, 2), System.Globalization.NumberStyles.HexNumber));
            }
            else if (val.StartsWith("0b"))
            {
                int binary = 0;
                val = val.Remove(0, 2);
                while (val != "")
                {
                    binary <<= 1;
                    if (val[0] == '1')
                    {
                        binary |= 1;
                    }
                    else if (val[0] != '0')
                    {
                        throw new ApplicationException("Syntax error in binary number");
                    }
                    val = val.Remove(0, 1);
                }
                return new Constant(binary);
            }
            else
            {
                try
                {
                    return new Constant(double.Parse(val));
                }
                catch
                {
                    return new StringExpression(val);
                }
            }
        }
    }
}
