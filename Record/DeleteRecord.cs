using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Record
{
    public partial class DeleteRecord : Form
    {
        private Connection connection = new Connection();
        private RecordModel record;
        public DeleteRecord(RecordModel record)
        {
            InitializeComponent();
            this.record = record;
            labelId.Text = record.Id.ToString();
            labelName.Text = record.Name.ToString();
            labelSurname.Text = record.Surname.ToString();
            labelAge.Text = record.Age.ToString();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            string query = String.Format("DELETE FROM record WHERE id = {0}", record.Id);

            connection.openConnection();
            connection.sendQuery(query);
            connection.closeConnection();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
