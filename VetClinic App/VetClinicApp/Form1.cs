using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace VetClinicApp
{
    public partial class Form1 : Form
    {
        string connStr = @"Data Source=DESKTOP-1F5N1VG\SQLEXPRESS;Initial Catalog = VetClinic; Integrated Security = True";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Populate table comboBox
            string[] tables = {
                "CLINIC", "VACCINE", "VETERINARIAN", "OWNER", "PET",
                "INVENTORY", "MEDICAL_VISIT", "CLINICAL_NOTE", "VACCINATION_RECORD"
            };
            cmbTable.Items.AddRange(tables);
            cmbTable.SelectedIndex = 0;

            // Populate join comboBox
            cmbJoin.Items.Add("Pets and Their Owners");
            cmbJoin.Items.Add("Visit Details");
            cmbJoin.Items.Add("Vaccination History");
            cmbJoin.SelectedIndex = 0;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (cmbTable.SelectedItem == null) { 
                MessageBox.Show("Please select a table."); 
                return; 
            }

            string table = cmbTable.SelectedItem.ToString();
            string columns = txtColumns.Text.Trim();
            string values = txtValues.Text.Trim();

            if (columns == "" || values == "") { 
                MessageBox.Show("Please enter columns and values."); 
                return; 
            }

            // Put each value in quotes
            string[] valArray = values.Split(',');
            string wrappedVals = "";
            foreach (string v in valArray)
                wrappedVals += "'" + v.Trim() + "',";
            wrappedVals = wrappedVals.TrimEnd(',');

            string query = "INSERT INTO " + table +
                           " (" + columns + ") VALUES (" + wrappedVals + ")";
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record inserted into " + table + " successfully!");
                txtColumns.Clear(); 
                txtValues.Clear();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cmbTable.SelectedItem == null) { 
                MessageBox.Show("Please select a table."); 
                return; 
            }

            string table = cmbTable.SelectedItem.ToString();
            string whereCol = txtWhereColumn.Text.Trim();
            string whereVal = txtWhereValue.Text.Trim();

            if (whereCol == "" || whereVal == "") { 
                MessageBox.Show("Please enter the condition column and value."); 
                return; 
            }

            DialogResult confirm = MessageBox.Show(
                "DELETE FROM " + table + " WHERE " + whereCol + " = '" + whereVal + "'\n\nAre you sure?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.No) return;

            string query = "DELETE FROM " + table +
                           " WHERE " + whereCol + " = '" + whereVal + "'";
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                int rows = cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(rows + " record(s) deleted from " + table);
                txtWhereColumn.Clear(); 
                txtWhereValue.Clear();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cmbTable.SelectedItem == null) { 
                MessageBox.Show("Please select a table."); 
                return; 
            }

            string table = cmbTable.SelectedItem.ToString();
            string setCol = txtSetColumn.Text.Trim();
            string setVal = txtSetValue.Text.Trim();
            string whereCol = txtWhereColumn.Text.Trim();
            string whereVal = txtWhereValue.Text.Trim();

            if (setCol == "" || setVal == "" || whereCol == "" || whereVal == "") { 
                MessageBox.Show("Please fill in all fields."); 
                return; 
            }

            string query = "UPDATE " + table +
                           " SET " + setCol + " = '" + setVal + "'" +
                           " WHERE " + whereCol + " = '" + whereVal + "'";
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                int rows = cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(rows + " record(s) updated in " + table);
                txtSetColumn.Clear(); 
                txtSetValue.Clear();
                txtWhereColumn.Clear(); 
                txtWhereValue.Clear();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnShowData_Click(object sender, EventArgs e)
        {
            if (cmbTable.SelectedItem == null) { 
                MessageBox.Show("Please select a table."); 
                return; 
            }

            string table = cmbTable.SelectedItem.ToString();
            string query = "SELECT * FROM " + table;

            try
            {
                SqlConnection con = new SqlConnection(connStr);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                dataGridView1.DataSource = dt;
                MessageBox.Show(dt.Rows.Count + " records loaded from " + table);
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnShowJoin_Click(object sender, EventArgs e)
        {
            if (cmbJoin.SelectedItem == null) { 
                MessageBox.Show("Please select a join view."); 
                return; 
            }

            string query = "";
            switch (cmbJoin.SelectedIndex)
            {
                case 0: // Pets and their owners details
                    query = @"SELECT p.petID, p.pet_name, p.species, p.breed, p.age,
                                     o.owner_name, o.emergency_contact, o.billing_address
                              FROM   PET p
                              JOIN   OWNER o ON p.ownerID = o.ownerID
                              ORDER BY o.owner_name";
                    break;

                case 1: // Visit details
                    query = @"SELECT mv.visitID, p.pet_name, p.species,
                                     v.vet_name, v.specialized_in,
                                     c.clinic_name, mv.visit_date, mv.visit_time
                              FROM   MEDICAL_VISIT mv
                              JOIN   PET p ON mv.petID = p.petID
                              JOIN   VETERINARIAN v ON mv.vetID = v.vetID
                              JOIN   CLINIC c ON v.clinicID = c.clinicID
                              ORDER BY mv.visit_date DESC";
                    break;

                case 2: // Vaccination history
                    query = @"SELECT p.pet_name, p.species, o.owner_name,
                                     vc.vacc_name, vc.type,
                                     vr.batch_no, vr.date_given, vr.next_booster_date
                              FROM   VACCINATION_RECORD vr
                              JOIN   PET p ON vr.petID = p.petID
                              JOIN   VACCINE vc ON vr.vaccID = vc.vaccID
                              JOIN   OWNER o ON p.ownerID = o.ownerID
                              ORDER BY vr.date_given DESC";
                    break;    
            }

            try
            {
                SqlConnection con = new SqlConnection(connStr);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                dataGridView1.DataSource = dt;
                MessageBox.Show(dt.Rows.Count + " records loaded.");
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Form2 reportsForm = new Form2();
            reportsForm.Show();
        }
    }
}