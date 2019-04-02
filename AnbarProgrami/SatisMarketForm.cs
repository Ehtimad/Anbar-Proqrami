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
using System.Diagnostics;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using System.Globalization;

namespace AnbarProgrami
{
    public partial class SatisMarketForm : Form
    {
        SQLiteConnection baqlanti = new SQLiteConnection();
        public string selectTable;
        public bool silinen = false;
        public string silinensql;
        public string editinsozu;
        public bool edited = false;
        public string editedsql;
        public string searchdate1;
        public string searchdate2;
        public SatisMarketForm()
        {
            InitializeComponent();
        }
        string connectionString = ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString;
        SQLiteCommand kommand = new SQLiteCommand();
        DataTable table = new DataTable();
        
        
        public void listelecomboboxworker()
        {
            try
            {
                workerNameComboBox.Items.Clear();
                baqlanti.Open();
                string query = "select * from IsciTable Where DeleteInfo is Null";
                SQLiteCommand kommand = new SQLiteCommand(query, baqlanti);
                DataTable dt = new DataTable();
                SQLiteDataAdapter da = new SQLiteDataAdapter(kommand);
                da.Fill(dt);
                SQLiteDataReader reader;
                reader = kommand.ExecuteReader();
                while (reader.Read())
                {
                    ComboboxItem cbitem = new ComboboxItem()
                    {
                        Value = Convert.ToInt32(reader["IsciID"]),
                        Text = reader["Ad"].ToString()
                    };
                    workerNameComboBox.Items.Add(cbitem);
                }
                baqlanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void selectlistele()
        {

            try
            {
                baqlanti.ConnectionString = (connectionString);

                if (silinen.Equals(true))
                {
                    silinensql = " is 2 ";
                }
                else {
                    silinensql = " is not 2 ";
                }
                if (edited.Equals(true))
                {
                    editedsql = editinsozu;
                }
                else {
                    editedsql = editinsozu;
                }

                searchdate1 = search1DTPicker.Text;
                searchdate2 = search2DTPicker.Text;
                SQLiteCommand kommand = new SQLiteCommand("Select Qaime, IsciTable.Ad,  NeqliyyatNomresi, AlisSatisTable.Tarix, AlisSatisTable.OperationDate, AlisSatisTable.Qeyd, CAST ( CASE WHEN AlisSatisTable.EditInfo = 1 THEN 'Redaktə olundu' END AS nvarchar(55)) as EditInfo, CAST ( CASE WHEN AlisSatisTable.DeleteInfo = 2 THEN 'Silindi' END AS nvarchar(55)) as DeleteInfo, AlisSatisTable.AlisSatisID, IsciTable.IsciID From IsciTable join AlisSatisTable on IsciTable.IsciID = AlisSatisTable.IsciID Where " + editedsql + " AlisSatisTable.DeleteInfo " + silinensql + " And AlisSatisTable.Tarix >=  @Date1 And AlisSatisTable.Tarix <= @Date2 order by AlisSatisID desc", baqlanti);
                kommand.Parameters.AddWithValue("@Date1", searchdate1);
                kommand.Parameters.AddWithValue("@Date2", searchdate2);

                SQLiteDataAdapter adtr = new SQLiteDataAdapter(kommand);
                table.Clear();
                adtr.Fill(table);
                DGV.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void SatisMarketForm_Load(object sender, EventArgs e)
        {
            search1DTPicker.Text = "";
            search2DTPicker.Text = "";
            WindowState = FormWindowState.Maximized;
            selectlistele();
            silinen = false;
            if (User.ruletype == "Admin")
            {
                adminToolStripMenu.Visible = true;
                DGW.Columns[6].Visible = true;
                showDeleteBtn.Visible = true;
                showEditBtn.Visible = true;
            }
            else
            {
                adminToolStripMenu.Visible = false;
                DGW.Columns[6].Visible = false;
                showDeleteBtn.Visible = false;
                showEditBtn.Visible = false;
            }
            DGW.Columns[0].Caption = "Qaimə nömrəsi";
            DGW.Columns[1].Caption = "İşcinin adı";
            DGW.Columns[2].Caption = "Nəqliyyat nömrəsi";
            DGW.Columns[3].Caption = "Əməliyyat tarixi";
            DGW.Columns[4].Caption = "Qeyd tarixi";
            DGW.Columns[5].Caption = "Qeyd";
            DGW.Columns[6].Caption = "Redaktə olunan";
            DGW.Columns[7].Caption = "Silinən";
            DGW.Columns[8].Caption = "AlisSatisID";
            DGW.Columns[9].Caption = "IsciID";

            DGW.Columns[7].Visible = false;
            DGW.Columns[8].Visible = false;
            DGW.Columns[9].Visible = false;
        }
        private void showDateBtn_Click(object sender, EventArgs e)
        {
            searchdate1 = search1DTPicker.Text;
            searchdate2 = search2DTPicker.Text;
            selectlistele();
        }

        private void addBtn_Click(object sender, EventArgs e)
        
            {
                listelecomboboxworker();
                qaimeNumberTxt.Text = "";
                workerNameComboBox.Text = "";
                productDateTimePicker.Text = "";
                neqliyyatNumberTxt.Text = "";
                noteTxt.Text = "";
                addEditGFLPanel.Visible = true;
                editGBtn.Visible = false;
                addEditFLPanel.Visible = false;
                addEditGroupBox.Visible = true;
            }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(DGW.RowCount) == 0)
            {
                MessageBox.Show("Redaktə olunacaq məlumat yoxdur!", "DİQQƏT!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                listelecomboboxworker();

                addEditFLPanel.Visible = false;
                addEditGroupBox.Visible = true;
                addEditGFLPanel.Visible = true;
                addGBtn.Visible = false;



                qaimeNumberTxt.Text = DGW.GetDataRow(DGW.FocusedRowHandle)[0].ToString();
                workerNameComboBox.Text = DGW.GetDataRow(DGW.FocusedRowHandle)[1].ToString();
                neqliyyatNumberTxt.Text = DGW.GetDataRow(DGW.FocusedRowHandle)[2].ToString();
                productDateTimePicker.Text = DGW.GetDataRow(DGW.FocusedRowHandle)[3].ToString();
                noteTxt.Text = DGW.GetDataRow(DGW.FocusedRowHandle)[5].ToString();

                selectTable = User.name + " " + '"' + this.Text + '"' + " Səhifəsində" + " Köhnə məlumatı: ( Qaimə nömrəsi: " + qaimeNumberTxt.Text + " ,İşçi adı:" + workerNameComboBox.Text + " ,Alış tarixi:" + productDateTimePicker.Text + " , Qeyd: " + noteTxt.Text + " ) -->  Yeni məlumata: ( ";
            }
        }
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(DGW.RowCount) == 0)
            {
                MessageBox.Show("Silinəcək məlumat yoxdur!", "DİQQƏT!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult cavab;
                cavab = MessageBox.Show("Silmək istədiyinizə əminsiniz?", "Ehtiyatlı olun!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cavab == DialogResult.Yes)
                {
                    int AlisSatisid = Convert.ToInt32(DGW.GetDataRow(DGW.FocusedRowHandle)[8].ToString());
                    string qaimen = DGW.GetDataRow(DGW.FocusedRowHandle)[0].ToString();
                    string silmevaxdi = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

                    SQLiteCommand kommand = new SQLiteCommand();
                    kommand.Connection = baqlanti;
                    kommand.CommandText = "Update AlisSatisTable Set DeleteInfo=@DeleteInfo Where AlisSatisID=@AlisSatisID";
                    kommand.Parameters.AddWithValue("@AlisSatisID", AlisSatisid);
                    kommand.Parameters.AddWithValue("@DeleteInfo", 2);
                    baqlanti.Open();
                    kommand.ExecuteNonQuery();
                    baqlanti.Close();
                    string DeleteRowLog = User.name + " Sildi: " + '"' + this.Text + '"' + " Səhifəsində" + "( Qaimə nömrəsi: " + qaimen + ")";

                    kommand.Connection = baqlanti;
                    kommand.CommandText = "Insert Into LogTable (IsciID,OperationDate,OperationType,CommentInfo) Values (@IsciID,@OperationDate,@OperationType,@CommentInfo)";
                    kommand.Parameters.AddWithValue("@IsciID", Convert.ToInt32(User.isciid));
                    kommand.Parameters.AddWithValue("@OperationDate", silmevaxdi);
                    kommand.Parameters.AddWithValue("@OperationType", 2);
                    kommand.Parameters.AddWithValue("@CommentInfo", DeleteRowLog);
                    baqlanti.Open();
                    kommand.ExecuteNonQuery();
                    baqlanti.Close();
                    MessageBox.Show("Məlumat silindi", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    silinen = false;
                    selectlistele();
                }
            }
        }

        private void addGBtn_Click(object sender, EventArgs e)
        {
            if (qaimeNumberTxt.Text.Trim() == "" || productDateTimePicker.Text.Trim() == "" || workerNameComboBox.Text.Trim() == "" || neqliyyatNumberTxt.Text.Trim() == "" || productDateTimePicker.Text.Trim() == "")
            {
                MessageBox.Show("Boş xana buraxmayın!");
            }
            else
            {
                string qeydt = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                var isciid = (workerNameComboBox.SelectedItem as ComboboxItem).Value;
                SQLiteCommand kommand = new SQLiteCommand();
                kommand.Connection = baqlanti;
                baqlanti.Open();
                kommand.CommandText = "Insert Into AlisSatisTable (Qaime, IsciID, NeqliyyatNomresi, Tarix, Qeyd, OperationDate) Values (@Qaime, @IsciID, @NeqliyyatNomresi, @Tarix, @Qeyd, @OperationDate)";
                kommand.Parameters.AddWithValue("@Qaime", qaimeNumberTxt.Text);
                kommand.Parameters.AddWithValue("@IsciID", Convert.ToInt32(isciid));
                kommand.Parameters.AddWithValue("@NeqliyyatNomresi", neqliyyatNumberTxt.Text);
                kommand.Parameters.AddWithValue("@Tarix", productDateTimePicker.Text);
                kommand.Parameters.AddWithValue("@Qeyd", noteTxt.Text);
                kommand.Parameters.AddWithValue("@OperationDate", qeydt);
                kommand.ExecuteNonQuery();
                baqlanti.Close();
                kommand = new SQLiteCommand();
                kommand.Connection = baqlanti;
                baqlanti.Open();
                string addLog = User.name + " " + '"' + this.Text + '"' + " Səhifəsinə əlavə etdi: ( Qaimə nömrəsi: " + qaimeNumberTxt.Text + " ,İşçi adı:" + workerNameComboBox.Text + " ,Alış tarixi:" + productDateTimePicker.Text + " , Qeyd tarixi: " + qeydt + " , Qeyd: " + noteTxt.Text + " )";
                kommand.CommandText = "Insert Into LogTable (IsciID,OperationDate,OperationType,CommentInfo) Values (@IsciID,@OperationDate,@OperationType,@CommentInfo)";
                kommand.Parameters.AddWithValue("@IsciID", Convert.ToInt32(User.isciid));
                kommand.Parameters.AddWithValue("@OperationDate", qeydt);
                kommand.Parameters.AddWithValue("@OperationType", 0);
                kommand.Parameters.AddWithValue("@CommentInfo", addLog);
                kommand.ExecuteNonQuery();
                baqlanti.Close();
                MessageBox.Show("Əlavə olundu!");
                qaimeNumberTxt.Text = "";
                workerNameComboBox.Text = "";
                productDateTimePicker.Text = "";
                neqliyyatNumberTxt.Text = "";
                noteTxt.Text = "";
                listelecomboboxworker();
                silinen = false;
                selectlistele();
            }
        }

        private void editGBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (qaimeNumberTxt.Text.Trim() == "" || workerNameComboBox.Text.Trim() == "" || productDateTimePicker.Text.Trim() == "" || neqliyyatNumberTxt.Text.Trim() == "" || noteTxt.Text.Trim() == "")

                {
                    MessageBox.Show("Boş xana buraxmayın!");
                }
                else
                {
                    try
                    {
                        int alissatisId = Convert.ToInt32(DGW.GetDataRow(DGW.FocusedRowHandle)[8].ToString());
                        string qeydt = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                        int isciid = Convert.ToInt32((workerNameComboBox.SelectedItem as ComboboxItem).Value);
                        SQLiteCommand kommand = new SQLiteCommand();
                        kommand.Connection = baqlanti;
                        baqlanti.Open();
                        kommand.CommandText = "Update AlisSatisTable Set Qaime=@Qaime, IsciID=@IsciID, NeqliyyatNomresi=@NeqliyyatNomresi, Tarix=@Tarix, Qeyd=@Qeyd, OperationDate=@OperationDate, EditInfo=@EditInfo Where AlisSatisID=@AlisSatisID";
                        kommand.Parameters.AddWithValue("@AlisSatisID", alissatisId);
                        kommand.Parameters.AddWithValue("@Qaime", qaimeNumberTxt.Text);
                        kommand.Parameters.AddWithValue("@IsciID", isciid);
                        kommand.Parameters.AddWithValue("@NeqliyyatNomresi", neqliyyatNumberTxt.Text);
                        kommand.Parameters.AddWithValue("@Tarix", productDateTimePicker.Text);
                        kommand.Parameters.AddWithValue("@Qeyd", noteTxt.Text);
                        kommand.Parameters.AddWithValue("@OperationDate", qeydt);
                        kommand.Parameters.AddWithValue("@EditInfo", 1);
                        kommand.ExecuteNonQuery();
                        baqlanti.Close();
                        string changetable = " Qaimə nömrəsi: " + qaimeNumberTxt.Text + " ,İşçi adı:" + workerNameComboBox.Text + " ,Alış tarixi:" + productDateTimePicker.Text + " , Qeyd tarixi: " + qeydt + " , Qeyd: " + noteTxt.Text + " ) dəyişdi";
                        baqlanti.Open();
                        kommand.CommandText = "Insert Into LogTable (IsciID,OperationDate,OperationType,CommentInfo) Values (@IsciID,@OperationDate,@OperationType,@CommentInfo)";
                        kommand.Parameters.AddWithValue("@IsciID", Convert.ToInt32(User.isciid));
                        kommand.Parameters.AddWithValue("@OperationDate", DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));
                        kommand.Parameters.AddWithValue("@OperationType", 1);
                        kommand.Parameters.AddWithValue("@CommentInfo", selectTable + changetable);
                        kommand.ExecuteNonQuery();
                        baqlanti.Close();
                        MessageBox.Show("Redaktə olundu");

                        addEditFLPanel.Visible = true;
                        addEditGroupBox.Visible = false;
                        addEditGFLPanel.Visible = false;
                        addGBtn.Visible = true;
                        editGBtn.Visible = true;

                        silinen = false;
                        selectlistele();

                        qaimeNumberTxt.Text = "";
                        workerNameComboBox.Text = "";
                        productDateTimePicker.Text = "";
                        noteTxt.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    editBtn.Enabled = true;
                }
            }
            catch (Exception xeta)
            {
                baqlanti.Close();
                MessageBox.Show(xeta.Message);
            }
        }

        private void hideGBtn_Click(object sender, EventArgs e)
        {
            addEditFLPanel.Visible = true;
            addEditGroupBox.Visible = false;
            addEditGFLPanel.Visible = false;
            addGBtn.Visible = true;
            editGBtn.Visible = true;
        }

        private void showEditBtn_Click(object sender, EventArgs e)
        {
            editinsozu = " AlisSatisTable.EditInfo " + editedsql + " And ";
            edited = true;
            selectlistele();
            showEditBtn.Visible = false;
            hideEditBtn.Visible = true;
        }

        private void hideEditBtn_Click(object sender, EventArgs e)
        {
            editinsozu = " ";
            edited = false;
            selectlistele();
            showEditBtn.Visible = true;
            hideEditBtn.Visible = false;
        }

        private void showDeleteBtn_Click(object sender, EventArgs e)
        {

            try
            {
                silinen = true;
                selectlistele();
                DGW.Columns[7].Visible = true;
                hideDeleteBtn.Visible = true;
                showDeleteBtn.Visible = false;
                commonFLPanel.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void hideDeleteBtn_Click(object sender, EventArgs e)
        {
            silinen = false;
            selectlistele();
            DGW.Columns[7].Visible = false;
            hideDeleteBtn.Visible = false;
            showDeleteBtn.Visible = true;
            commonFLPanel.Visible = true;
        }

        private void excellexportBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel Files(Excel 97-2003 Workbook)|*.xlsx";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DevExpress.XtraGrid.Views.Grid.GridView View = DGV.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
                if (View != null)
                {
                    View.ExportToXlsx(saveFileDialog1.FileName);
                    Process pdfExport = new Process();
                    pdfExport.StartInfo.FileName = "Excel.exe";
                    pdfExport.StartInfo.Arguments = saveFileDialog1.FileName;
                    pdfExport.Start();
                }
            }
        }
        
        private void SatisMarketForm_FormClosed(object sender, FormClosedEventArgs e)
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
            this.Hide();
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
