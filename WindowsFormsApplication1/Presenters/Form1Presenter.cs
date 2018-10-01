using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Presenters
{
    public class Form1Presenter
    {
        
        private readonly IMainFormView mainFormView;
        private readonly IPersonRepository personManager;

        public Form1Presenter(IMainFormView mainFormView, 
                              IPersonRepository personManager)
        {
            this.mainFormView = mainFormView;
            this.personManager = personManager;

            mainFormView.dataGridView_DataBindingComplete += dataGridView_DataBindingComplete;
            mainFormView.dataGridView_CellLeave += dataGridView_CellLeave;

            mainFormView.SetDataSource(personManager.GetPeople());

        }

        private void dataGridView_DataBindingComplete(object sender, EventArgs e)
        {
            mainFormView.SetDataGridViewBackColor();
        }

        private void dataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            mainFormView.SetDataGridViewRowBackColor(e.RowIndex);
        }
    }
}
