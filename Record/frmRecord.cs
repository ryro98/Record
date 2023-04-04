using Record;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Records
{
    public partial class frmRecord : Form
    {
        private Connection connection = new Connection();
        private RecordModel record;
        Boolean isRecordNew = false;
        public frmRecord(RecordModel record)
        {
            InitializeComponent();
            if (record == null) {
                RecordModel newRecord = new RecordModel();
                this.record = newRecord;
                isRecordNew = true;
            } else
            {
                this.record = record;
                tbName.Text = this.record.Name;
                tbSurname.Text = this.record.Surname;
                nudAge.Value = this.record.Age;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "")
            {
                MessageBox.Show("Name cannot be empty");
            } else if (tbSurname.Text == "")
            {
                MessageBox.Show("Surname cannot be empty");
            } else if (nudAge.Value < 1)
            {
                MessageBox.Show("Age cannot be lesser than 0");
            } else
            {
                this.record.Name = tbName.Text;
                this.record.Surname = tbSurname.Text;
                this.record.Age = (int)nudAge.Value;

                string query;
                if (isRecordNew)
                {
                    query = String.Format("INSERT INTO record (name, surname, age) VALUES ('{0}', '{1}', {2});",
                    this.record.Name, this.record.Surname, this.record.Age);
                }
                else
                {
                    query = String.Format("UPDATE record SET name = '{0}', surname = '{1}', age = {2} WHERE id = {3};",
                    this.record.Name, this.record.Surname, this.record.Age, this.record.Id);
                }
                connection.openConnection();
                connection.sendQuery(query);
                connection.closeConnection();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
