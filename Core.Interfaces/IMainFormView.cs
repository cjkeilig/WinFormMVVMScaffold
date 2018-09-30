using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Core.Interfaces
{
    public interface IMainFormView
    {
        event DataGridViewBindingCompleteEventHandler dataGridView_DataBindingComplete;

        event DataGridViewCellEventHandler dataGridView_CellLeave;

        void SetDataGridViewBackColor();

        void SetDataGridViewRowBackColor(Int32 rowIndex);

        void SetDataSource(IEnumerable<Person> people);
    }
}
