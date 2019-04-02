using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using Excel;
using System.IO;

namespace AnbarProgrami
{
    public partial class logForm : Form
    {
        SQLiteConnection baqlanti = new SQLiteConnection();
        public logForm()
        {
            InitializeComponent();
        }

        string connectionString = ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString;
        SQLiteCommand kommand = new SQLiteCommand();
        DataTable table = new DataTable();
        public void selectlistele()
        {
            try
            {
                baqlanti.ConnectionString = (connectionString);
                SQLiteDataAdapter adtr = new SQLiteDataAdapter("Select Ad, OperationDate,CAST(CASE WHEN OperationType = 0 THEN 'Əlavə etmək' WHEN OperationType = 1 THEN 'Redaktə etmək' ELSE 'Silmək' END AS nvarchar(55))as OperationType,CommentInfo,ID,IsciTable.IsciID From LogTable Left join IsciTable on LogTable.IsciID=IsciTable.IsciID ", baqlanti);
                table.Clear();
                adtr.Fill(table);
                DGV.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void LogForm_Load(object sender, EventArgs e)
        {
            if (User.ruletype == "Admin")
            {
                adminToolStripMenu.Visible = true;
            }
            else
            {
                adminToolStripMenu.Visible = false;
            }
            WindowState = FormWindowState.Maximized;
            selectlistele();
            DGW.Columns[0].Caption = "İşçinin adı";
            DGW.Columns[1].Caption = "Qeyd tarixi";
            DGW.Columns[2].Caption = "Dəyişikliyin növü";
            DGW.Columns[3].Caption = "Şərh";
            DGW.Columns[4].Caption = "ID";
            DGW.Columns[5].Caption = "IsciID";
            DGW.Columns[4].Visible = false;
            DGW.Columns[5].Visible = false;

        }
        

        private void logForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            Application.Exit();
        }

        private void homePageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            homeForm homeform = new homeForm();
            homeform.ShowDialog();
            this.Close();
        }
        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            productForm productform = new productForm();
            productform.ShowDialog();
            this.Close();
        }

        private void factoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            factoryForm factoryform = new factoryForm();
            factoryform.ShowDialog();
            this.Close();
        }

        private void marketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            marketForm marketform = new marketForm();
            marketform.ShowDialog();
            this.Close();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            purchaseForm purchaseform = new purchaseForm();
            purchaseform.ShowDialog();
            this.Close();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            salesForm salesform = new salesForm();
            salesform.ShowDialog();
            this.Close();
        }

        private void userChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginForm userChange = new loginForm();
            userChange.ShowDialog();
            this.Close();
        }

        private void exitprogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void workerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            workerForm workerform = new workerForm();
            workerform.ShowDialog();
            this.Close();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            userForm userform = new userForm();
            userform.ShowDialog();
            this.Close();
        }

        private void logsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            logForm logform = new logForm();
            logform.ShowDialog();
            this.Close();
        }



        private void satışMarketSəhifəsiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SatisMarketForm satismarketform = new SatisMarketForm();
            satismarketform.ShowDialog();
            this.Close();
        }

        private void ödənişlərToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            OdenisForm odenisform = new OdenisForm();
            odenisform.ShowDialog();
            this.Close();
        }

        private void alisSatisOdenisHesabatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hesabatForm hesabatform = new hesabatForm();
            hesabatform.ShowDialog();
            this.Close();
        }

        private void kateqoriyaSəhifəsiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            KategoriyaForm kategoriyaform = new KategoriyaForm();
            kategoriyaform.ShowDialog();
            this.Close();
        }

        private void backupÇıxarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                string yersecimi = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
                string fileName = "AnbarProgram.db";
                string sourcePath = @"C:\Anbar Programi\db";
                string targetPath = yersecimi;
                string deyisilmisAd = DateTime.Now.ToString("yyyyMMddHHmmss_") + fileName;
                string sourceFile = Path.Combine(sourcePath, fileName);
                string destFile = Path.Combine(targetPath, deyisilmisAd);
                if (!Directory.Exists(targetPath))
                {
                    Directory.CreateDirectory(targetPath);
                }
                File.Copy(sourceFile, destFile, true);
                if (Directory.Exists(sourcePath))
                {
                    string[] files = Directory.GetFiles(sourcePath);

                    foreach (string s in files)
                    {
                        fileName = Path.GetFileName(s);
                        destFile = Path.Combine(targetPath, deyisilmisAd);
                        File.Copy(s, destFile, true);
                    }
                }
                else
                {
                    MessageBox.Show("Qovluq yoxdur!");
                }
            }

        }

        private void alisZavodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AlisZavodForm aliszavodform = new AlisZavodForm();
            aliszavodform.ShowDialog();
            this.Close();
        }

        private void mailləGöndərToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var smtpServerName = ConfigurationSettings.AppSettings["SmtpServer"];
            var port = ConfigurationSettings.AppSettings["Port"];
            var senderEmailId = ConfigurationSettings.AppSettings["SenderEmailId"];
            var senderPassword = ConfigurationSettings.AppSettings["SenderPassword"];
            var senderBody = ConfigurationSettings.AppSettings["SenderBody"];
            var senderSubject = ConfigurationSettings.AppSettings["SenderSubject"];
            var sendToEmailId = ConfigurationSettings.AppSettings["SendToEmailId"];
            MailMessage mail = new MailMessage(senderEmailId, sendToEmailId, senderSubject, senderBody);
            //mail.Attachments.Add(new Attachment(@"C:\Anbar Programi\AnbarProgram.db"));
            mail.Attachments.Add(new Attachment(@"D:\backp\Program\16.05.2018\AnbarProgrami\AnbarProgrami\bin\Release\db\AnbarProgram.db"));
            SmtpClient client = new SmtpClient(smtpServerName);
            client.Port = Convert.ToInt32(port);
            client.Credentials = new System.Net.NetworkCredential(senderEmailId, senderPassword);
            client.EnableSsl = true;
            client.Send(mail);
            MessageBox.Show("Message Sent Successfully");
        }
    }
}
