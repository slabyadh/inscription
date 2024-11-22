using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace DashboardInscription
{
    public partial class Form1 : Form
    {
        string connectionString = "Server=localhost;Database=TP5;Trusted_Connection=True;";
        private Timer refreshTimer;
        private Timer addTimer;

        public Form1()
        {
            InitializeComponent();

            refreshTimer = new Timer();
            refreshTimer.Interval = 5000; 
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();

            addTimer = new Timer();
            addTimer.Interval = 10000; 
            addTimer.Tick += AddTimer_Tick;
            addTimer.Start();

            LoadDashboardData();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

        private void AddTimer_Tick(object sender, EventArgs e)
        {
            AddRandomInscription();
        }

        private void LoadDashboardData()
        {
            try
            {
                using (SqlConnection connexion = new SqlConnection(connectionString))
                {
                    connexion.Open();

                    string totalInscriptionsQuery = "SELECT COUNT(*) FROM Inscriptions";
                    string recentInscriptionsQuery = "SELECT COUNT(*) FROM Inscriptions WHERE DateInscription >= DATEADD(SECOND, -5, GETDATE())";
                    string revenueQuery = "SELECT SUM(Montant) FROM Inscriptions";

                    using (SqlCommand cmd = new SqlCommand(totalInscriptionsQuery, connexion))
                    {
                        lblTotalInscrits.Text = cmd.ExecuteScalar()?.ToString() ?? "0";
                    }

                    using (SqlCommand cmd = new SqlCommand(recentInscriptionsQuery, connexion))
                    {
                        lblRecentInscrits.Text = cmd.ExecuteScalar()?.ToString() ?? "0";
                    }

                    using (SqlCommand cmd = new SqlCommand(revenueQuery, connexion))
                    {
                        lblRevenuTotal.Text = $"{cmd.ExecuteScalar() ?? 0:C}";
                    }

                    string inscriptionsDetailsQuery = "SELECT Nom, Email, Categorie, DateInscription, Montant FROM Inscriptions ORDER BY DateInscription DESC";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(inscriptionsDetailsQuery, connexion))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dgvInscriptions.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des données : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddRandomInscription()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string[] noms = { "Alice", "Bob", "Carla", "David", "Eve", "Frank", "Grace", "Hugo", "Isabelle", "Jack" };
                    string[] emails = { "example1@example.com", "example2@example.com", "example3@example.com", "example4@example.com", "example5@example.com" };
                    string[] categories = { "Étudiant", "Professionnel", "VIP" };
                    Random random = new Random();

                    string nom = noms[random.Next(noms.Length)];
                    string email = emails[random.Next(emails.Length)];
                    string categorie = categories[random.Next(categories.Length)];
                    decimal montant = categorie == "Étudiant" ? 50.00M : categorie == "Professionnel" ? 100.00M : 200.00M;

                    string insertQuery = "INSERT INTO Inscriptions (Nom, Email, Categorie, DateInscription, Montant) " +
                                         "VALUES (@Nom, @Email, @Categorie, GETDATE(), @Montant)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nom", nom);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Categorie", categorie);
                        cmd.Parameters.AddWithValue("@Montant", montant);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout d'une inscription : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
