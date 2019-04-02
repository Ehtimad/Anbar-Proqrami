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

namespace AnbarProgrami
{
    public partial class productForm : Form
    {
        SQLiteConnection baqlanti = new SQLiteConnection();
        public string selectTable;
        public string setHeader;
        public string setType;
        public bool silinen = false;
        public string silinensql;
        public string editinsozu;
        public bool edited = false;
        public string editedsql;
        public productForm()
        {
            InitializeComponent();
        }

        string connectionString = ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString;
        SQLiteCommand kommand = new SQLiteCommand();
        DataTable table = new DataTable();
        
        public void listelecomboboxKategoriy()
        {
            try
            {
                KategoryComboBox.Items.Clear();
                baqlanti.Open();
                string query = "Select * from KategoriyaTable where DeleteInfo is null";
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
                        Value = Convert.ToInt32(reader["KategoriyID"]),
                        Text = reader["KategoriyName"].ToString()
                    };
                    KategoryComboBox.Items.Add(cbitem);
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
                    if (silinen.Equals(true))
                    {
                        silinensql = " is not null";
                    }
                    else {
                        silinensql = " is null";
                    }
                    if (edited.Equals(true))
                    {
                        editedsql = editinsozu;
                    }
                    else {
                        editedsql = editinsozu;
                    }                   
               
                    baqlanti.ConnectionString = (connectionString);
                               
                SQLiteCommand kommand = new SQLiteCommand("Select KategoriyaTable.KategoriyName, Ad,Nov,OlcuVahidi,MehsulTable.OperationDate,MehsulTable.Qeyd,CAST ( CASE WHEN MehsulTable.EditInfo = 1 THEN 'Redaktə olundu' END AS nvarchar(55)) as EditInfo,CAST ( CASE WHEN MehsulTable.DeleteInfo = 2 THEN 'Silindi' END AS nvarchar(55)) as DeleteInfo, MehsulID ,KategoriyaTable.KategoriyID From  MehsulTable join KategoriyaTable on MehsulTable.KategoriyID=KategoriyaTable.KategoriyID  Where " + editedsql + " MehsulTable.DeleteInfo " + silinensql, baqlanti);

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

        private void ProductForm_Load(object sender, EventArgs e)
        {
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
            DGW.Columns[0].Caption = "Kateqoriyası";
            DGW.Columns[1].Caption = "Adı";
            DGW.Columns[2].Caption = "Növü";
            DGW.Columns[3].Caption = "Ölçü vahidi";
            DGW.Columns[4].Caption = "Qeyd tarixi";
            DGW.Columns[5].Caption = "Qeyd";
            DGW.Columns[6].Caption = "Redaktə olunan";
            DGW.Columns[7].Caption = "Silinən";
            DGW.Columns[8].Caption = "MehsulID";
            DGW.Columns[9].Caption = "KategoriyİD";
            DGW.Columns[7].Visible = false;
            DGW.Columns[8].Visible = false;
            DGW.Columns[9].Visible = false;
        }
             

        private void addBtn_Click(object sender, EventArgs e)
        {
            listelecomboboxKategoriy();
            KategoryComboBox.Text = "";
            mehsulNameTxt.Text = "";
            mehsulTypeTxt.Text = "";
            mehsulUnitTxt.Text = "";
            mehsulNoteTxt.Text = "";
            addEditGFLPanel.Visible = true;
            editGBtn.Visible = false;
            addEditFLPanel.Visible = false;
            addEditGroupBox.Visible = true;
        }
        private void editBtn_Click(object sender, EventArgs e)
        {
            {
                if (Convert.ToInt32(DGW.RowCount) == 0)
                {
                    MessageBox.Show("Redaktə olunacaq məlumat yoxdur!", "DİQQƏT!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    listelecomboboxKategoriy();
                    KategoryComboBox.Text = DGW.GetDataRow(DGW.FocusedRowHandle)[0].ToString();
                    mehsulNameTxt.Text = DGW.GetDataRow(DGW.FocusedRowHandle)[1].ToString();
                    mehsulTypeTxt.Text = DGW.GetDataRow(DGW.FocusedRowHandle)[2].ToString();
                    mehsulUnitTxt.Text = DGW.GetDataRow(DGW.FocusedRowHandle)[3].ToString();
                    mehsulNoteTxt.Text = DGW.GetDataRow(DGW.FocusedRowHandle)[5].ToString();
                    string operationDate = DGW.GetDataRow(DGW.FocusedRowHandle)[4].ToString();

                    selectTable = User.name + " " + '"' + this.Text + '"' + " -ndə Köhnə məlumatı: ( Məhsulun Kateqoriyası: " + KategoryComboBox.Text + " , Məhsulun adı: " + mehsulNameTxt.Text + " , Növü: " + mehsulTypeTxt.Text + " , Ölçü vahidi: " + mehsulUnitTxt.Text + " , Əməliyyat tarixi: " + operationDate + " , Qeyd: " + mehsulNoteTxt.Text + " ) -->  Yeni məlumata: ( ";

                    addEditFLPanel.Visible = false;
                    addEditGroupBox.Visible = true;
                    addEditGFLPanel.Visible = true;
                    addGBtn.Visible = false;
                }
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
                    int id = Convert.ToInt32(DGW.GetDataRow(DGW.FocusedRowHandle)[8].ToString());
                    string kategoriya = DGW.GetDataRow(DGW.FocusedRowHandle)[0].ToString();
                    string ad = DGW.GetDataRow(DGW.FocusedRowHandle)[1].ToString();
                    string nov = DGW.GetDataRow(DGW.FocusedRowHandle)[2].ToString();
                    string olcuvahidi = DGW.GetDataRow(DGW.FocusedRowHandle)[3].ToString();
                    string operationDate = DGW.GetDataRow(DGW.FocusedRowHandle)[4].ToString();
                    string qeyd = DGW.GetDataRow(DGW.FocusedRowHandle)[5].ToString();
                    string editInfo = DGW.GetDataRow(DGW.FocusedRowHandle)[6].ToString();

                    DataTable table = new DataTable();
                    kommand.Connection = baqlanti;
                    kommand.CommandText = "Update MehsulTable Set DeleteInfo=@DeleteInfo Where MehsulID=@MehsulID";
                    kommand.Parameters.AddWithValue("@MehsulID", id);
                    kommand.Parameters.AddWithValue("@DeleteInfo", 2);
                    baqlanti.Open();
                    kommand.ExecuteNonQuery();
                    baqlanti.Close();

                    string DeleteRowLog = User.name + " Sildi: " + '"' + this.Text + '"' + " ində" + "( Məhsulun Kateqoriyası: " + kategoriya + " , Ad: " + ad + " , Növ: " + nov + " , Ölçü vahidi: " + olcuvahidi + " , Əməliyyat tarixi: " + operationDate + " , Qeyd: " + qeyd + ")";

                    kommand.Connection = baqlanti;
                    kommand.CommandText = "Insert Into LogTable (IsciID,OperationDate,OperationType,CommentInfo) Values (@IsciID,@OperationDate,@OperationType,@CommentInfo)";
                    kommand.Parameters.AddWithValue("@IsciID", Convert.ToInt32(User.isciid));
                    kommand.Parameters.AddWithValue("@OperationDate", DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));
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
            try
            {
                if (KategoryComboBox.Text.Trim() == "" || mehsulNameTxt.Text.Trim() == "" || mehsulTypeTxt.Text.Trim() == "" || mehsulUnitTxt.Text.Trim() == "")
                {
                    MessageBox.Show("Boş xana buraxmayın!");
                }
                else
                {
                    string operatitonDate = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                    var kategoriyid = (KategoryComboBox.SelectedItem as ComboboxItem).Value;
                    try
                    {
                        SQLiteCommand kommand = new SQLiteCommand();
                        kommand.Connection = baqlanti;
                        kommand.CommandText = "Insert Into MehsulTable (KategoriyID,Ad,Nov,OlcuVahidi,OperationDate,Qeyd) Values (@KategoriyID,@Ad,@Nov,@OlcuVahidi,@OperationDate,@Qeyd)";
                        kommand.Parameters.AddWithValue("@KategoriyID", kategoriyid);
                        kommand.Parameters.AddWithValue("@Ad", mehsulNameTxt.Text);
                        kommand.Parameters.AddWithValue("@Nov", mehsulTypeTxt.Text);
                        kommand.Parameters.AddWithValue("@OlcuVahidi", mehsulUnitTxt.Text);
                        kommand.Parameters.AddWithValue("@OperationDate", operatitonDate);
                        kommand.Parameters.AddWithValue("@Qeyd", mehsulNoteTxt.Text);
                        baqlanti.Open();
                        kommand.ExecuteNonQuery();
                        baqlanti.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    try
                    {
                        string addLog = User.name + " " + '"' + this.Text + '"' + " -nə əlavə etdi: ( Məhsulun Kateqoriyası: " + KategoryComboBox.Text + " Adı: " + mehsulNameTxt.Text + " , Növü: " + mehsulTypeTxt.Text + " , Ölçü vahidi: " + mehsulUnitTxt.Text + " , Əməliyyat tarixi: " + operatitonDate + " , Qeyd: " + mehsulNoteTxt.Text + " )";
                        SQLiteCommand kommand = new SQLiteCommand();
                        kommand.Connection = baqlanti;
                        baqlanti.Open();
                        kommand.CommandText = "Insert Into LogTable (IsciID,OperationDate,OperationType,CommentInfo) Values (@IsciID,@OperationDate,@OperationType,@CommentInfo)";
                        kommand.Parameters.AddWithValue("@IsciID", Convert.ToInt32(User.isciid));
                        kommand.Parameters.AddWithValue("@OperationDate", operatitonDate);
                        kommand.Parameters.AddWithValue("@OperationType", 0);
                        kommand.Parameters.AddWithValue("@CommentInfo", addLog);
                        kommand.ExecuteNonQuery();
                        baqlanti.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    baqlanti.Close();
                    MessageBox.Show("Əlavə olundu!");
                    silinen = false;
                    selectlistele();
                    addEditFLPanel.Visible = false;
                    KategoryComboBox.Text = "";
                    mehsulNameTxt.Text = "";
                    mehsulTypeTxt.Text = "";
                    mehsulUnitTxt.Text = "";
                    mehsulNoteTxt.Text = "";
                }
            }
            catch (Exception ex)
            {
                baqlanti.Close();
                MessageBox.Show(ex.Message);
            }            
        }
        private void editGBtn_Click(object sender, EventArgs e)
        {
            int mehsulId = Convert.ToInt32(DGW.GetDataRow(DGW.FocusedRowHandle)[8].ToString());
            var kategoriyid = (KategoryComboBox.SelectedItem as ComboboxItem).Value;
            try
            {
                if (KategoryComboBox.Text.Trim() == "" || mehsulNameTxt.Text.Trim() == "" || mehsulTypeTxt.Text.Trim() == "" || mehsulUnitTxt.Text.Trim() == "" || mehsulNoteTxt.Text.Trim() == "")
                {
                    MessageBox.Show("Boş xana buraxmayın!");
                }
                else
                {
                    string operatitonDate = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                    try
                    {
                        SQLiteCommand kommand = new SQLiteCommand();
                        kommand.Connection = baqlanti;
                        kommand.CommandText = "Update MehsulTable Set KategoriyID=@KategoriyID,Ad=@Ad,Nov=@Nov,OlcuVahidi=@OlcuVahidi,OperationDate=@OperationDate,Qeyd=@Qeyd,EditInfo=@EditInfo Where MehsulID=@MehsulID";
                        kommand.Parameters.AddWithValue("@MehsulID", mehsulId);
                        kommand.Parameters.AddWithValue("@KategoriyID", kategoriyid);
                        kommand.Parameters.AddWithValue("@Ad", mehsulNameTxt.Text);
                        kommand.Parameters.AddWithValue("@Nov", mehsulTypeTxt.Text);
                        kommand.Parameters.AddWithValue("@OlcuVahidi", mehsulUnitTxt.Text);
                        kommand.Parameters.AddWithValue("@OperationDate", operatitonDate);
                        kommand.Parameters.AddWithValue("@Qeyd", mehsulNoteTxt.Text);
                        kommand.Parameters.AddWithValue("@EditInfo", 1);
                        baqlanti.Open();
                        kommand.ExecuteNonQuery();
                        baqlanti.Close();

                        string changetable = " Məhsulun Kateqoriyası: " + KategoryComboBox.Text + " , Adı: " + mehsulNameTxt.Text + " , Növü: " + mehsulTypeTxt.Text + " , Ölçü vahidi: " + mehsulUnitTxt.Text + " , Əməliyyat tarixi: " + operatitonDate + " , Qeyd: " + mehsulNoteTxt.Text + " ) dəyişdi";

                        kommand.CommandText = "Insert Into LogTable (IsciID,OperationDate,OperationType,CommentInfo) Values (@IsciID,@OperationDate,@OperationType,@CommentInfo)";
                        kommand.Parameters.AddWithValue("@IsciID", Convert.ToInt32(User.isciid));
                        kommand.Parameters.AddWithValue("@OperationDate", operatitonDate);
                        kommand.Parameters.AddWithValue("@OperationType", 1);
                        kommand.Parameters.AddWithValue("@CommentInfo", selectTable + changetable);
                        baqlanti.Open();
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
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
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
            editinsozu = " MehsulTable.EditInfo " + editedsql + " And ";
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
            DGW.Columns[7].Visible = false;
            hideDeleteBtn.Visible = false;
            showDeleteBtn.Visible = true;
            commonFLPanel.Visible = true;
            silinen = false;
            selectlistele();
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

        private void productForm_FormClosed(object sender, FormClosedEventArgs e)
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
