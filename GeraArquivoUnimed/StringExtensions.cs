using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeraArquivoUnimed
{
    public static class StringExtensions
    {
        public static String PadRightOrTrunc(this String str, int qtde)
        {
            return str.PadRightOrTrunc(qtde, null);
        }

        public static String PadRightOrTrunc(this String str, int qtde, String carac)
        {
            if (str.Length > qtde)
                return str.Substring(0, qtde);
            else
                if (carac == null)
                return str.PadRight(qtde);
            else
                return str.PadRight(qtde, Convert.ToChar(carac));
        }


        public static String PadLeftOrTrunc(this String str, int qtde)
        {
            return str.PadLeftOrTrunc(qtde, null);
        }

        public static String PadLeftOrTrunc(this String str, int qtde, String carac)
        {
            if (str.Length > qtde)
                return str.Substring(str.Length - qtde);
            else
                if (carac == null)
                return str.PadLeft(qtde);
            else
                return str.PadLeft(qtde, Convert.ToChar(carac));
        }

        public static String PadLeftNumber(this String str, int qtde)
        {
            return str.PadLeftOrTrunc(qtde, "0");
        }

        public static String PadRightNumber(this String str, int qtde)
        {
            return str.PadRightOrTrunc(qtde, "0");
        }

        public static String Fill(Char c, int qtde)
        {
            return new string(c, qtde);
        }

        public static String Fill(int qtde)
        {
            return Fill(' ', qtde);
        }

        public static String FillNumber(int qtde)
        {
            return Fill('0', qtde);
        }
    }
}
