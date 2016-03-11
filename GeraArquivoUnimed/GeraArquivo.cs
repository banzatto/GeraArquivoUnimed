using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GeraArquivoUnimed
{
    public class GeraArquivo
    {
        public enum TipoColuna
        {
            PadRightOrTrunc=0,
            PadLeftOrTrunc,
            PadRightNumber,
            PadLeftNumber,
            Fill,
            FillNumber
        }


        public DataTable mDt { get; private set; }
        public string mNomeArquivo { get; private set; }

        public int mLinha = 0;

        public GeraArquivo(String NomeArquivo, DataTable dt)
        {
            mNomeArquivo = NomeArquivo;
            mDt = dt;
        }

        public bool Gerar()
        {
            bool ret = false;
            mLinha = 1;
            using (StreamWriter sw = new StreamWriter(mNomeArquivo))
            {
                try
                {
                    Cabecalho(sw);

                    StringBuilder sb = new StringBuilder();
                    foreach (DataRow dr in mDt.Rows)
                    {
                        sb.Append(getLinha(true));   //Numero da linha
                        sb.Append("3");    //Tipo de registro beneficiario


                        for (int col = 0; col < mDt.Columns.Count; col++)
                        {
                            DataColumn dc = mDt.Columns[col];
                            String valor = dr[col].ToString();
                            if (dc.ExtendedProperties.Contains("TipoColuna"))
                            {
                                TipoColuna tipo = (TipoColuna)dc.ExtendedProperties["TipoColuna"];
                                switch (tipo)
                                {
                                    case TipoColuna.PadLeftOrTrunc:
                                        sb.Append(valor.PadLeftOrTrunc(dc.MaxLength));
                                        break;
                                    case TipoColuna.PadRightOrTrunc:
                                        sb.Append(valor.PadRightOrTrunc(dc.MaxLength));
                                        break;
                                    case TipoColuna.PadLeftNumber:
                                        sb.Append(valor.PadLeftNumber(dc.MaxLength));
                                        break;
                                    case TipoColuna.PadRightNumber:
                                        sb.Append(valor.PadRightNumber(dc.MaxLength));
                                        break;
                                    case TipoColuna.Fill:
                                        sb.Append(StringExtensions.Fill(dc.MaxLength));
                                        break;
                                    case TipoColuna.FillNumber:
                                        sb.Append(StringExtensions.FillNumber(dc.MaxLength));
                                        break;
                                    default:
                                        sb.Append(valor.PadRightOrTrunc(dc.MaxLength));
                                        break;
                                }
                            }
                            else
                            {
                                sb.Append(valor.PadRightOrTrunc(dc.MaxLength));
                            }
                        }
                        sw.WriteLine(sb.ToString());

                        sb.Clear();
                    }

                    Rodape(sw,mDt.Rows.Count);
                    ret = true;
                    if (sw != null)
                    {
                        sw.Close();
                    }
                }
                catch (Exception ex)
                {
                    ret = false;
                    throw ex;
                }
            }


            return ret;
        }

        private void Cabecalho(StreamWriter sw)
        {
              StringBuilder sb = new StringBuilder();
            sb.Append(getLinha(true));
            sb.Append("1");   //Header
            sb.Append("010");  //Tipo de arquivo
            sb.Append("".PadLeftNumber(9));   //Codigo da empresa
            sb.Append("".PadLeftNumber(4));   //Unidade destino
            sb.Append(DateTime.Today.ToString("yyyyMMdd"));    //Data da geração
            sb.Append("E"); //Tipo remetente
            sb.Append("M"); //Tipo de carga
            sb.Append("0007");  //Versão do layout   *** necessário confirmar

            sw.WriteLine(sb.ToString());
        }
        private void Rodape(StreamWriter sw, int total)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(getLinha(true));  //Linha
            sb.Append("6"); // Tipo de registro Trailer
            sb.Append(total.ToString().PadLeftNumber(8));   //Total de beneficiarios
            sw.WriteLine(sb.ToString());
        }

        public String getLinha(bool soma)
        {
            String l = mLinha.ToString().PadLeftNumber(8);
            if (soma)
                mLinha++;
            return l;
        }
        
    }

    

}
