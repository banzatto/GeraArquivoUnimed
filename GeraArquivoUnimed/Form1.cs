using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeraArquivoUnimed
{
    public partial class Form1 : Form
    {
        DataTable dt = null;
        public Form1()
        {
            InitializeComponent();
        }


        private void CriaDT()
        {
            dt = new DataTable("tabela");            
            dt.Columns.Add(AddColuna("campo1", 10));
            dt.Columns.Add(AddColuna("campo2", 50));
            dt.Columns.Add(AddColuna("reservado", 10,GeraArquivo.TipoColuna.FillNumber));
            dt.Columns.Add(AddColuna("reservado2", 30, GeraArquivo.TipoColuna.FillNumber));
            dt.Columns.Add(AddColuna("reservado3", 10, GeraArquivo.TipoColuna.Fill));
            dt.Columns.Add(AddColuna("numero", 10, GeraArquivo.TipoColuna.PadLeftNumber));
        }


        public DataColumn AddColuna(String nome, int tamanho)
        {
            return AddColuna(nome, tamanho, GeraArquivo.TipoColuna.PadRightOrTrunc);
        }
        public DataColumn AddColuna(String nome,int tamanho, GeraArquivo.TipoColuna tc)
        {
            DataColumn dc = new DataColumn(nome, typeof(String));
            dc.MaxLength = tamanho;
            dc.ExtendedProperties.Add("TipoColuna", tc);
            return dc;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CriaDT();
        }

        private void btnGerarArquivo_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Cursor ucursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;

                GeraArquivo ga = new GeraArquivo(sfd.FileName, dt);
                try
                {
                    bool ret = ga.Gerar();
                    if (ret)
                    {
                        MessageBox.Show("Arquivo gerado com sucesso");
                    }
                    else
                    {
                        MessageBox.Show("Erro na geração do arquivo");
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show("Erro na geração do arquivo. \n"+ex.Message);
                }

                 finally
                {
                    Cursor.Current = ucursor;
                }

            }
        }

        private void btnDadosCordilheira_Click(object sender, EventArgs e)
        {
            dtg.DataSource = null;
            dtg.AutoGenerateColumns = true;
            dtg.DataSource = dt;

        }
    }
}
