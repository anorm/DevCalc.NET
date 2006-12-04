using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Xml;
using System.Xml.XPath;
using System.Windows.Forms;
using System.Data;

namespace DevCalc.NET
{
	class OperatorKurs : Operator
    {
        static ValutaDataSet data = null;

        public override int OperandCount
        {
            get { return 1; }
        }

        public OperatorKurs()
        {
            if(data == null)
            {
                string url = "https://www.dnbnor.no/portalfront/datafiles/miscellaneous/csv/kursliste_ws.xml";

                XmlTextReader reader = new XmlTextReader(url);

                data = new ValutaDataSet();
                data.ReadXml(reader);
            }
        }

        public override double Evaluate()
        {
            string symbol = Children[0].ToString();
            foreach(ValutaDataSet.valutakursRow valuta in data.valutakurs)
            {
                if(valuta.kode.ToLower() == symbol.ToLower())
                {
                    ValutaDataSet.overforselRow[] o = valuta.GetoverforselRows();
                    return double.Parse(o[0].salg.Replace('.', System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0]));
                }
            }
            throw new Exception("Unable to find symbol");
        }
    }
}
