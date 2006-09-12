using System;
using System.Collections;
using System.Collections.Specialized;

namespace DevCalc.NET
{
    /// <summary>
    /// Summary description for MathParser.
    /// </summary>
    public class MathParser
    {
        private ArrayList operators;

        public MathParser()
        {
            operators = new ArrayList();
            operators.Add(new DictionaryEntry("pi", typeof(OperatorPI)));
            operators.Add(new DictionaryEntry("sin", typeof(OperatorSinus)));
            operators.Add(new DictionaryEntry("tverrsum", typeof(OperatorTverrsum)));
            operators.Add(new DictionaryEntry("sqrt", typeof(OperatorSqrt)));
            operators.Add(new DictionaryEntry("^", typeof(OperatorPower)));
            operators.Add(new DictionaryEntry("*", typeof(OperatorMultiply)));
            operators.Add(new DictionaryEntry("/", typeof(OperatorDivide)));
            operators.Add(new DictionaryEntry("-", typeof(OperatorMinus)));
            operators.Add(new DictionaryEntry("+", typeof(OperatorPlus)));
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

            foreach (DictionaryEntry op in operators)
            {
                string s = (string)op.Key;
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
            foreach (DictionaryEntry op in operators)
            {
                bool found;
                do
                {
                    found = false;
                    for (int i = 0; i < nodes.Count; i++)
                    {
                        if (nodes[i].GetType() == op.Value)
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
            foreach (DictionaryEntry op in operators)
            {
                string s = (string)op.Key;
                if (s.ToUpper() == val.ToUpper())
                {
                    Type t = op.Value as Type;
                    Operator o = (Operator)(t.InvokeMember("", System.Reflection.BindingFlags.CreateInstance, null, null, null));
                    return o;
                }
            }
            if (val.StartsWith("0x"))
            {
                return new Constant(int.Parse(val.Remove(0, 2), System.Globalization.NumberStyles.HexNumber));
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
                return new Constant(double.Parse(val));
            }
        }
    }
}
