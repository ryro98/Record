using Record;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Records
{
    public partial class Record_Form : Form
    {
        private RecordModel clickedRecord;
        private Connection connection = new Connection();
        public Record_Form()
        {
            InitializeComponent();
            RefreshRecords();
        }

        private void RefreshRecords()
        {
            connection.openConnection();
            string query = "select * from record order by id;";
            SqlDataReader reader = connection.sendQuery(query);

            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;

            connection.closeConnection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmRecord form = new frmRecord(null);
            if (form.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Record added.");
                RefreshRecords();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmRecord form = new frmRecord(clickedRecord);
            if (form.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Record updated.");
                RefreshRecords();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteRecord form = new DeleteRecord(clickedRecord);
            if (form.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Record deleted.");
                RefreshRecords();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RecordModel clickedRecord = new RecordModel();
            clickedRecord.Id = (int)dataGridView1.CurrentRow.Cells[0].Value;
            clickedRecord.Name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            clickedRecord.Surname = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            clickedRecord.Age = (int)dataGridView1.CurrentRow.Cells[3].Value;
            this.clickedRecord = clickedRecord;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
        }
    }
}