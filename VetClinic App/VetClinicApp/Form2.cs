using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VetClinicApp
{
    public partial class Form2 : Form
    {
        string connStr = @"Data Source=DESKTOP-1F5N1VG\SQLEXPRESS;Initial Catalog=VetClinic;Integrated Security=True";

        // We set these values to be able to show data
        int lastMonth = 3;
        int lastMonthYear = 2025;
        int thisYear = 2025;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        // Inquiry 1 — Species with most visits last month
        private void btnInquiry1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connStr);
            con.Open();

            SqlCommand cmd = new SqlCommand($@"
                SELECT TOP 1
                      p.species, COUNT(mv.visitID) AS Total_Visits_Last_Month
                FROM  MEDICAL_VISIT mv
                JOIN  PET p ON mv.petID = p.petID
                WHERE MONTH(mv.visit_date) = {lastMonth}
                AND   YEAR(mv.visit_date)  = {lastMonthYear}
                GROUP BY p.species
                ORDER BY Total_Visits_Last_Month DESC", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            dataGridView1.DataSource = dt;
            lblStatus.Text = "Inquiry 1 — Species with most visits in March 2025";
        }

        // Inquiry 2 — Clinics with no visits last month
        private void btnInquiry2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connStr);
            con.Open();

            SqlCommand cmd = new SqlCommand($@"
                SELECT c.clinicID, c.clinic_name,c.clinic_address, c.has_emergency
                FROM   CLINIC c
                WHERE  c.clinicID NOT IN (
                    SELECT DISTINCT v.clinicID
                    FROM   MEDICAL_VISIT mv
                    JOIN   VETERINARIAN v ON mv.vetID = v.vetID
                    WHERE  MONTH(mv.visit_date) = {lastMonth}
                    AND    YEAR(mv.visit_date)  = {lastMonthYear}
                )", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            dataGridView1.DataSource = dt;
            lblStatus.Text = "Inquiry 2 — Clinics with no visits in March 2025";
        }

        // Inquiry 3 — Vet with most vaccinations last month
        private void btnInquiry3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connStr);
            con.Open();

            SqlCommand cmd = new SqlCommand($@"
                SELECT TOP 1
                       v.vetID, v.vet_name, v.specialized_in, 
                       c.clinic_name, COUNT(vr.vaccID)AS Vaccinations_Administered
                FROM   VACCINATION_RECORD vr
                JOIN   PET p ON vr.petID = p.petID
                JOIN MEDICAL_VISIT mv ON p.petID  = mv.petID
                JOIN VETERINARIAN v ON mv.vetID  = v.vetID
                JOIN CLINIC c ON v.clinicID = c.clinicID
                WHERE MONTH(vr.date_given) = {lastMonth}
                AND   YEAR(vr.date_given)  = {lastMonthYear}
                GROUP BY v.vetID, v.vet_name, v.specialized_in, c.clinic_name
                ORDER BY Vaccinations_Administered DESC", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            dataGridView1.DataSource = dt;
            lblStatus.Text = "Inquiry 3 — Vet with most vaccinations in March 2025";
        }

        // Inquiry 4 — Owners who didn't visit last month
        private void btnInquiry4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connStr);
            con.Open();

            SqlCommand cmd = new SqlCommand($@"
                SELECT o.ownerID, o.owner_name, o.emergency_contact, o.billing_address
                FROM  OWNER o
                WHERE o.ownerID NOT IN (
                    SELECT DISTINCT p.ownerID
                    FROM MEDICAL_VISIT mv
                    JOIN PET p ON mv.petID = p.petID
                    WHERE MONTH(mv.visit_date) = {lastMonth}
                    AND   YEAR(mv.visit_date)  = {lastMonthYear}
                )
                ORDER BY o.owner_name", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            dataGridView1.DataSource = dt;
            lblStatus.Text = "Inquiry 4 — Owners who did not visit in March 2025";
        }

        // Inquiry 5 — Vaccines at each clinic last month
        private void btnInquiry5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connStr);
            con.Open();

            SqlCommand cmd = new SqlCommand($@"
                SELECT c.clinic_name, vc.vacc_name, vc.type, COUNT(vr.vaccID) AS Times_Administered
                FROM VACCINATION_RECORD vr
                JOIN PET p ON vr.petID = p.petID
                JOIN MEDICAL_VISIT mv ON p.petID = mv.petID
                JOIN VETERINARIAN v ON mv.vetID = v.vetID
                JOIN CLINIC c ON v.clinicID = c.clinicID
                JOIN VACCINE vc ON vr.vaccID  = vc.vaccID
                WHERE MONTH(vr.date_given) = {lastMonth}
                AND   YEAR(vr.date_given)  = {lastMonthYear}
                GROUP BY c.clinic_name, vc.vacc_name, vc.type
                ORDER BY c.clinic_name, Times_Administered DESC", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            dataGridView1.DataSource = dt;
            lblStatus.Text = "Inquiry 5 — Vaccines per clinic in March 2025";
        }

        // Inquiry 6 — Total visits per pet this year
        private void btnInquiry6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connStr);
            con.Open();

            SqlCommand cmd = new SqlCommand($@"
                SELECT p.pet_name, p.species, COUNT(mv.visitID) AS Total_Visits_This_Year
                FROM   PET p
                LEFT   JOIN MEDICAL_VISIT mv ON p.petID = mv.petID
                AND    YEAR(mv.visit_date) = {thisYear}
                LEFT JOIN OWNER o ON p.ownerID = o.ownerID
                GROUP BY p.pet_name, p.species, o.owner_name
                ORDER BY Total_Visits_This_Year DESC", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            dataGridView1.DataSource = dt;
            lblStatus.Text = "Inquiry 6 — Total visits per pet in 2025";
        }
    }
}