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
    public partial class workerForm : Form
    {
        SQLiteConnection baqlanti = new SQLiteConnection();
        public string selectTable;
        public string setHeader;
        public string setType;
        public bool silinen = false;
        public string silinensql;
        public workerForm()
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
                //baqlanti.ConnectionString = (connectionUrl);
                if (comboBoxSearch.SelectedIndex == 0)
                {
                    setHeader = "";
                    setType = searchTxt.Text;
                    if (silinen.Equals(true))
                    {
                        silinensql = " is not null";
                    }
                    else {
                        silinensql = " is null";
                    }

                    if (comboBoxSearch.SelectedIndex == -1)
                    {
                        setHeader = "1=1";
                        setType = "1=1";
                    }
                }
                else
                {
                    if (comboBoxSearch.SelectedIndex == 1)
                    {
                        setHeader = "IsciID like @tags";
                        setType = searchTxt.Text;
                    }
                    else if (comboBoxSearch.SelectedIndex == 2)
                    {
                        setHeader = "Ad like @tags";
                        setType = searchTxt.Text;
                    }
                    else if (comboBoxSearch.SelectedIndex == 3)
                    {
                        setHeader = "Soyad like @tags";
                        setType = searchTxt.Text;
                    }
                    else if (comboBoxSearch.SelectedIndex == 4)
                    {
                        setHeader = "Meslek like @tags";
                        setType = searchTxt.Text;
                    }
                    else if (comboBoxSearch.SelectedIndex == 5)
                    {
                        setHeader = "Phone like @tags";
                        setType = searchTxt.Text;
                    }
                    else if (comboBoxSearch.SelectedIndex == 6)
                    {
                        setHeader = "Qeyd like @tags";
                        setType = searchTxt.Text;
                    }
                    else if (comboBoxSearch.SelectedIndex == 7)
                    {
                        setHeader = "BaslamaTarixi like @tags";
                        setType = searchTxt.Text;
                    }
                    else if (comboBoxSearch.SelectedIndex == 8)
                    {
                        setHeader = "EditInfo like @tags";
                        setType = searchTxt.Text;
                    }
                    else if (comboBoxSearch.SelectedIndex == 9)
                    {
                        setHeader = "DeleteInfo like @tags";
                        setType = searchTxt.Text;
                    }

                    if (silinen.Equals(true))
                    {
                        silinensql = " is not null";
                    }
                    else {
                        silinensql = " is null";
                    }

                    if (comboBoxSearch.SelectedIndex == -1)
                    {
                        setHeader = "1=1";
                        setType = "1=1";
                    }
                    setHeader += " And ";
                }
                
                SQLiteCommand kommand = new SQLiteCommand("Select IsciID, AD,Soyad,Meslek,Phone,BaslamaTarixi,Qeyd,EditInfo,DeleteInfo From  IsciTable Where " + setHeader + " DeleteInfo " + silinensql, baqlanti);
                if (comboBoxSearch.SelectedIndex != -1)
                { kommand.Parameters.AddWithValue("@tags", "%" + setType + "%"); }
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
        private void WorkerForm_Load(object sender, EventArgs e)
        {
            selectlistele();
            silinen = false;
            WindowState = FormWindowState.Maximized;
            if (User.ruletype == "Admin")
            {
                this.comboBoxSearch.Items.AddRange(new object[] { "Hamısını göstər", "İşci İD-si", "İşci adı", "Soyadı", "Vəzifəsi", "Telefon nömrəsi", "Başlama tarixi", "Qeyd", "Redaktə olunan" });
                adminToolStripMenu.Visible = true;
                DGV.Columns[7].Visible = true;
                showDeleteBtn.Visible = true;
            }
            else
            {
                this.comboBoxSearch.Items.AddRange(new object[] { "Hamısını göstər", "İşci İD-si", "İşci adı", "Soyadı", "Vəzifəsi", "Telefon nömrəsi", "Başlama tarixi", "Qeyd" });
                adminToolStripMenu.Visible = false;
                DGV.Columns[7].Visible = false;
                showDeleteBtn.Visible = false;
            }
            DGV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DGV.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DGV.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DGV.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DGV.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DGV.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DGV.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DGV.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DGV.Columns[0].HeaderText = "İd-si";
            DGV.Columns[1].HeaderText = "Adı";
            DGV.Columns[2].HeaderText = "Soyadı";
            DGV.Columns[3].HeaderText = "Vəzifəsi";
            DGV.Columns[4].HeaderText = "Telefon nömrəsi";
            DGV.Columns[5].HeaderText = "Başlama tarixi";
            DGV.Columns[6].HeaderText = "Qeyd";
            DGV.Columns[7].HeaderText = "Redaktə olan";
            DGV.Columns[8].HeaderText = "Silinən";
            DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV.Columns[8].Visible = false;
        }
       
        private void searchTxt_TextChanged(object sender, EventArgs e)
        {
            selectlistele();
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            workerIdTxt.Text = "";
            workerNameTxt.Text = "";
            workerSurnameTxt.Text = "";
            workerMeslekTxt.Text = "";
            workerPhoneTxt.Text = "";
            workerNoteTxt.Text = "";
            addEditGroupBox.Visible = true;
            workerIdTxt.Visible = false;
            workerİdLabel.Visible = false;
            editBtn.Enabled = false;
            editGBtn.Enabled = false;
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            addEditGroupBox.Visible = true;
            workerIdTxt.Visible = true;
            workerİdLabel.Visible = true;
            workerIdTxt.Enabled = false;
            addGBtn.Visible = false;
            addBtn.Enabled = false;
            deleteBtn.Enabled = false;

            workerIdTxt.Text = DGV.CurrentRow.Cells[0].Value.ToString();
            workerNameTxt.Text = DGV.CurrentRow.Cells[1].Value.ToString();
            workerSurnameTxt.Text = DGV.CurrentRow.Cells[2].Value.ToString();
            workerMeslekTxt.Text = DGV.CurrentRow.Cells[3].Value.ToString();
            workerPhoneTxt.Text = DGV.CurrentRow.Cells[4].Value.ToString();
            string beginDate = DGV.CurrentRow.Cells[5].Value.ToString();
            workerNoteTxt.Text = DGV.CurrentRow.Cells[6].Value.ToString();
            selectTable = User.name + " " + '"' + this.Text + '"' + " -ndə Köhnə məlumatı: ( ID-si: " + workerIdTxt.Text + " , Adı: " + workerNameTxt.Text + " , Soyadı: " + workerSurnameTxt.Text + " , Vəzifəsi: " + workerMeslekTxt.Text + " , Telefon nömrəsi: " + workerPhoneTxt.Text + " , Başlama tarixi: " + beginDate + " , Qeyd: " + workerNoteTxt.Text + " ) -->  Yeni məlumata: ( ";
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult cavab;
            cavab = MessageBox.Show("Silmək istədiyinizə əminsiniz?", "Ehtiyatlı olun!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cavab == DialogResult.Yes)
            {
                int id = Convert.ToInt32(DGV.CurrentRow.Cells[0].Value.ToString());
                string ad = DGV.CurrentRow.Cells[1].Value.ToString();
                string soyad = DGV.CurrentRow.Cells[2].Value.ToString();
                string meslek = DGV.CurrentRow.Cells[3].Value.ToString();
                string telefonNomresi = DGV.CurrentRow.Cells[4].Value.ToString();
                string beginDate = DGV.CurrentRow.Cells[5].Value.ToString();
                string qeyd = DGV.CurrentRow.Cells[6].Value.ToString();
                string editInfo = DGV.CurrentRow.Cells[7].Value.ToString();

                SQLiteCommand kommand = new SQLiteCommand();

                kommand.Connection = baqlanti;
                kommand.CommandText = "Update IsciTable Set Ad=@Ad,Soyad=@Soyad,Meslek=@Meslek,Phone=@Phone,BaslamaTarixi=@BaslamaTarixi,Qeyd=@Qeyd,DeleteInfo=@DeleteInfo Where IsciID=@IsciID";
                kommand.Parameters.AddWithValue("@IsciID", id);
                kommand.Parameters.AddWithValue("@Ad", ad);
                kommand.Parameters.AddWithValue("@Soyad", soyad);
                kommand.Parameters.AddWithValue("@Meslek", meslek);
                kommand.Parameters.AddWithValue("@Phone", telefonNomresi);
                kommand.Parameters.AddWithValue("@BaslamaTarixi", beginDate);
                kommand.Parameters.AddWithValue("@Qeyd", qeyd);
                kommand.Parameters.AddWithValue("@DeleteInfo", 2);
                baqlanti.Open();
                kommand.ExecuteNonQuery();
                baqlanti.Close();
                string DeleteRowLog = User.name + " Sildi: " + '"' + this.Text + '"' + " ində " + "(ID-si: " + id + " , Adı: " + ad + " , Soyadı: " + soyad + " , Vəzifəsi: " + meslek + " , Telefon nömrəsi: " + telefonNomresi + " , Başlama tarixi: " + beginDate + " , Qeyd: " + qeyd + ")";
                kommand.Connection = baqlanti;
                kommand.CommandText = "Insert Into LogTable (IsciID,OperationDate,OperationType,CommentInfo) Values (@IsciID,@OperationDate,@OperationType,@CommentInfo)";
                kommand.Parameters.AddWithValue("@IsciID", Convert.ToInt32(User.isciid));
                kommand.Parameters.AddWithValue("@OperationDate", DateTime.Now.ToString());
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

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            homeForm homeform = new homeForm();
            homeform.ShowDialog();
            this.Close();
        }

        private void addGBtn_Click(object sender, EventArgs e)
        {

            try
            {
                if (workerNameTxt.Text.Trim() == "" || workerSurnameTxt.Text.Trim() == "" || workerMeslekTxt.Text.Trim() == "" || workerPhoneTxt.Text.Trim() == "")
                {
                    MessageBox.Show("Boş xana buraxmayın!");
                }
                else
                {
                    try
                    {
                        SQLiteCommand kommand = new SQLiteCommand();
                        kommand.Connection = baqlanti;
                        kommand.CommandText = "Insert Into IsciTable (Ad,Soyad,Meslek,Phone,BaslamaTarixi,Qeyd) Values (@Ad,@Soyad,@Meslek,@Phone,@BaslamaTarixi,@Qeyd)";
                        kommand.Parameters.AddWithValue("@Ad", workerNameTxt.Text);
                        kommand.Parameters.AddWithValue("@Soyad", workerSurnameTxt.Text);
                        kommand.Parameters.AddWithValue("@Meslek", workerMeslekTxt.Text);
                        kommand.Parameters.AddWithValue("@Phone", workerPhoneTxt.Text);
                        kommand.Parameters.AddWithValue("@BaslamaTarixi", begindateDateTimePicker.Text);
                        kommand.Parameters.AddWithValue("@Qeyd", workerNoteTxt.Text);
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
                        string addLog = User.name + " " + '"' + this.Text + '"' + " -nə əlavə etdi: ( Adı: " + workerNameTxt.Text + " , Soyadı: " + workerSurnameTxt.Text + " , Vəzifəsi: " + workerMeslekTxt.Text + " , Telefon nömrəsi: " + workerPhoneTxt.Text + " , Başlama tarixi: " + begindateDateTimePicker.Text + " , Qeyd: " + workerNoteTxt.Text + " )";
                        SQLiteCommand kommand = new SQLiteCommand();
                        kommand.Connection = baqlanti;
                        kommand.CommandText = "Insert Into LogTable (IsciID,OperationDate,OperationType,CommentInfo) Values (@IsciID,@OperationDate,@OperationType,@CommentInfo)";
                        kommand.Parameters.AddWithValue("@IsciID", Convert.ToInt32(User.isciid));
                        kommand.Parameters.AddWithValue("@OperationDate", DateTime.Now.ToString());
                        kommand.Parameters.AddWithValue("@OperationType", 0);
                        kommand.Parameters.AddWithValue("@CommentInfo",addLog);
                        baqlanti.Open();
                        kommand.ExecuteNonQuery();
                        baqlanti.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                    MessageBox.Show("Əlavə olundu!");
                    silinen = false;
                    selectlistele();
                    workerNameTxt.Text = "";
                    workerSurnameTxt.Text = "";
                    workerMeslekTxt.Text = "";
                    workerPhoneTxt.Text = "";
                    workerNoteTxt.Text = "";
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
            try
            {
                if (workerNameTxt.Text.Trim() == "" || workerSurnameTxt.Text.Trim() == "" || workerMeslekTxt.Text.Trim() == "" || workerPhoneTxt.Text.Trim() == "" || workerNoteTxt.Text.Trim() == "")
                {
                    MessageBox.Show("Boş xana buraxmayın!");
                }
                else
                {
                    try
                    {
                        SQLiteCommand kommand = new SQLiteCommand();
                        kommand.Connection = baqlanti;
                        kommand.CommandText = "Update IsciTable Set Ad=@Ad,Soyad=@Soyad,Meslek=@Meslek,Phone=@Phone,BaslamaTarixi=@BaslamaTarixi,Qeyd=@Qeyd,EditInfo=@EditInfo Where IsciID=@IsciID";
                        kommand.Parameters.AddWithValue("@IsciID", workerIdTxt.Text);
                        kommand.Parameters.AddWithValue("@Ad", workerNameTxt.Text);
                        kommand.Parameters.AddWithValue("@Soyad", workerSurnameTxt.Text);
                        kommand.Parameters.AddWithValue("@Meslek", workerMeslekTxt.Text);
                        kommand.Parameters.AddWithValue("@Phone", workerPhoneTxt.Text);
                        kommand.Parameters.AddWithValue("@BaslamaTarixi", begindateDateTimePicker.Text);
                        kommand.Parameters.AddWithValue("@Qeyd", workerNoteTxt.Text);
                        kommand.Parameters.AddWithValue("@EditInfo", 1);
                        baqlanti.Open();
                        kommand.ExecuteNonQuery();
                        baqlanti.Close();
                        string changetable = "İd-si: " + workerIdTxt.Text + " , Adı: " + workerNameTxt.Text + " , Soyadı: " + workerSurnameTxt.Text + " , Vəzifəsi: " + workerMeslekTxt.Text + " , Telefon nömrəsi: " + workerPhoneTxt.Text + " , Başlama tarixi: " + begindateDateTimePicker.Text + " , Qeyd: " + workerNoteTxt.Text + " ) dəyişdi";

                        kommand.CommandText = "Insert Into LogTable (IsciID,OperationDate,OperationType,CommentInfo) Values (@IsciID,@OperationDate,@OperationType,@CommentInfo)";
                        kommand.Parameters.AddWithValue("@IsciID", Convert.ToInt32(User.isciid));
                        kommand.Parameters.AddWithValue("@OperationDate", DateTime.Now.ToString());
                        kommand.Parameters.AddWithValue("@OperationType", 1);
                        kommand.Parameters.AddWithValue("@CommentInfo", selectTable + changetable);
                        baqlanti.Open();
                        kommand.ExecuteNonQuery();
                        baqlanti.Close();
                        MessageBox.Show("Redaktə olundu");
                        addEditGroupBox.Visible = false;
                        addGBtn.Visible = true;
                        addBtn.Enabled = true;
                        deleteBtn.Enabled = true;
                        addEditGroupBox.Hide();
                        silinen = false;
                        selectlistele();
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

        private void hideBtn_Click(object sender, EventArgs e)
        {
            addEditGroupBox.Visible = false;

            editBtn.Enabled = true;
            editGBtn.Enabled = true;

            addGBtn.Visible = true;
            addBtn.Enabled = true;
            deleteBtn.Enabled = true;
        }

        private void excellexportBtn_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.InitialDirectory = "C:";
                saveFileDialog1.Title = "Excel-ə yaz";
                saveFileDialog1.FileName = this.Text;
                saveFileDialog1.Filter = "Excel Files(Excel 97-2003 Workbook)|*.xlsx";
                if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
                {
                    Microsoft.Office.Interop.Excel.Application yazdir = new Microsoft.Office.Interop.Excel.Application();
                    yazdir.Application.Workbooks.Add(Type.Missing);
                    yazdir.Columns.ColumnWidth = 20;
                    for (int i = 1; i < DGV.Columns.Count + 1; i++)
                    {
                        yazdir.Cells[1, i] = DGV.Columns[i - 1].HeaderText;

                    }
                    for (int i = 0; i < DGV.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < DGV.Columns.Count; j++)
                        {
                            yazdir.Cells[i + 2, j + 1] = DGV.Rows[i].Cells[j].Value.ToString();

                        }

                    }
                    yazdir.ActiveWorkbook.SaveCopyAs(saveFileDialog1.FileName.ToString());
                    yazdir.ActiveWorkbook.Saved = true;
                    yazdir.Quit();
                    MessageBox.Show("Məlumat excel-ə yazıldı", "Diqqət");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cancelSearchBtn_Click(object sender, EventArgs e)
        {
            comboBoxSearch.SelectedItem = "Hamısını göstər";
            searchTxt.Text = "";
            setType = "";
            selectlistele();
        }

        private void showDeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                silinen = true;
                selectlistele();
                buttonGroupbox.Visible = false;
                DGV.Columns[8].Visible = true;
                hideDeleteBtn.Visible = true;
                showDeleteBtn.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void hideDeleteBtn_Click(object sender, EventArgs e)
        {
            buttonGroupbox.Visible = true;
            DGV.Columns[8].Visible = false;
            hideDeleteBtn.Visible = false;
            showDeleteBtn.Visible = true;
            silinen = false;
            selectlistele();
        }

        private void workerForm_FormClosed(object sender, FormClosedEventArgs e)
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
                string sourcePath = @"C:\Anbar Proqrami\db";
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
            mail.Attachments.Add(new Attachment(@"C:\Anbar Proqrami\AnbarProgram.db"));
            //mail.Attachments.Add(new Attachment(@"D:\backp\Program\16.05.2018\AnbarProgrami\AnbarProgrami\bin\Release\db\AnbarProgram.db"));
            SmtpClient client = new SmtpClient(smtpServerName);
            client.Port = Convert.ToInt32(port);
            client.Credentials = new System.Net.NetworkCredential(senderEmailId, senderPassword);
            client.EnableSsl = true;
            client.Send(mail);
            MessageBox.Show("Message Sent Successfully");
        }
    }
}
