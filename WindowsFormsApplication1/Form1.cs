using Core.Interfaces;
using Core.Models;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Presenters;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form, IMainFormView
    {

        private Form1Presenter presenter;
        public Form1(IPersonRepository personManager)
        {
            InitializeComponent();
            presenter = new Form1Presenter(this, personManager);
        }

        public event DataGridViewBindingCompleteEventHandler dataGridView_DataBindingComplete
        {
            add { dataGridView1.DataBindingComplete += value; }
            remove { dataGridView1.DataBindingComplete -= value; }
        }

        public event DataGridViewCellEventHandler dataGridView_CellLeave
        {
            add { dataGridView1.CellLeave += value; }
            remove { dataGridView1.CellLeave -= value; }
        }

        public void SetDataGridViewBackColor()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.DefaultCellStyle.BackColor = (Color)row.Cells[4].Value;
            }
        }

        public void SetDataGridViewRowBackColor(Int32 rowIndex)
        {
            dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red;
        }

        public void SetDataSource(IEnumerable<Person> people)
        {
            personBindingSource.DataSource = people;
        }
    }
}
