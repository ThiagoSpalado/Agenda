using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Model;
using DAL.Persistence;

namespace Agenda_1._0
{
    public partial class Agenda : Form
    {
        private enum options
        {
            Insert = 1,
            Update,
            Delete,
            Search
        }

        public Agenda()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            txtBusca.Text = monthCalendar1.SelectionRange.Start.ToString("dd/MM/yyyy");
        }

        private void btnCalendario_Click(object sender, EventArgs e)
        {
            lblRetorno.Text = "";
            monthCalendar1.Visible = !(monthCalendar1.Visible);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            opcao(options.Insert);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            opcao(options.Search);
        }

        private void opcao(options enmOptions)
        {
            Diario d = new Diario();
            DiarioDAL dd = new DiarioDAL();

            d.Diary = txtDiario.Text;
            d.Data = txtBusca.Text;

            switch (enmOptions)
            {
                case options.Insert:
                    if (!dd.Editar(d))
                    {
                        dd.Salvar(d);
                        lblRetorno.Text = "Salvo com sucesso";
                    }
                    else
                    {
                        dd.Editar(d);
                        lblRetorno.Text = "Alterado com sucesso";
                    }
                    break;
                case options.Search:
                    txtDiario.Text = dd.Buscar(d);
                    break;
                default:
                    lblRetorno.Text = "Ocorreu um erro no sistema!!!";
                    break;
            }
        }
    }
}
