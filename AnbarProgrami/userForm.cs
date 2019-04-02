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
using System.Security.Cryptography;

namespace AnbarProgrami
{
    public partial class userForm : Form
    {
        SQLiteConnection baqlanti = new SQLiteConnection();
        public string selectTable;
        public string setHeader;
        public string setType;
        public bool silinen=false;
        public string silinensql;
        public userForm()
        {
            InitializeComponent();
        }
        string connectionString = ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString;
        public string GetMD5(string text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder str = new StringBuilder();
            for (int i = 1; i < result.Length; i++)
            {
                str.Append(result[i].ToString("x2"));
            }
            return str.ToString();
        }
        SQLiteCommand kommand = new SQLiteCommand();
        DataTable table = new DataTable();
        public void listelecomboboxworker()
        {
            try
            {
                workerNameComboBox.Items.Clear();
                baqlanti.Open();
                string query = "select * from IsciTable where Isciid not in (select isciid from IstifadeciTable)";
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
        public void listelecomboboxrule()
        {
            try
            {
                ruleComboBox.Items.Clear();
                baqlanti.Open();
                string query = "select * from RuleTable";
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
                        Value = Convert.ToInt32(reader["RuleID"]),
                        Text = reader["RuleType"].ToString()
                    };
                    ruleComboBox.Items.Add(cbitem);
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
                        setHeader = "IstifadeciID like @tags";
                        setType = searchTxt.Text;
                    }
                    else if (comboBoxSearch.SelectedIndex == 2)
                    {
                        setHeader = "Ad like @tags";
                        setType = searchTxt.Text;
                    }
                    else if (comboBoxSearch.SelectedIndex == 3)
                    {
                        setHeader = "Login like @tags";
                        setType = searchTxt.Text;
                    }
                    else if (comboBoxSearch.SelectedIndex == 4)
                    {
                        setHeader = "UPassword like @tags";
                        setType = searchTxt.Text;
                    }
                    else if (comboBoxSearch.SelectedIndex == 5)
                    {
                        setHeader = "RuleType like @tags";
                        setType = searchTxt.Text;
                    }
                    else if (comboBoxSearch.SelectedIndex == 6)
                    {
                        setHeader = "IstifadeciTable.Qeyd like @tags";
                        setType = searchTxt.Text;
                    }
                    else if (comboBoxSearch.SelectedIndex == 7)
                    {
                        setHeader = "IstifadeciTable.EditInfo like @tags";
                        setType = searchTxt.Text;
                    }
                    else if (comboBoxSearch.SelectedIndex == 8)
                    {
                        setHeader = "IstifadeciTable.DeleteInfo like @tags";
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
                
                SQLiteCommand kommand = new SQLiteCommand("Select IstifadeciID,AD,Login,UPassword,RuleType,IstifadeciTable.Qeyd,IstifadeciTable.EditInfo,IstifadeciTable.DeleteInfo, IstifadeciTable.IsciID, IstifadeciTable.RuleID From IstifadeciTable left join IsciTable on IstifadeciTable.IsciID=IsciTable.IsciID left join RuleTable on IstifadeciTable.RuleID=RuleTable.RuleID Where " + setHeader + " IstifadeciTable.DeleteInfo " + silinensql, baqlanti);
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
        private void UserForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            selectlistele();
            silinen = false;
            if (User.ruletype == "Admin")
            {
                adminToolStripMenu.Visible = true;
                this.comboBoxSearch.Items.AddRange(new object[] { "Hamısını göstər", "İstifadəçi İD", "İşci Adı", "İstifadəçi adı", "Şifrə", "Rolu", "Qeyd", "Redaktə olunan" });
                DGV.Columns[6].Visible = true;
                showDeleteBtn.Visible = true;
            }
            else
            {
                adminToolStripMenu.Visible = false;
                this.comboBoxSearch.Items.AddRange(new object[] { "Hamısını göstər", "İstifadəçi İD", "İşci Adı", "İstifadəçi adı", "Şifrə", "Rolu", "Qeyd" });
                DGV.Columns[6].Visible = false;
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
            DGV.Columns[0].HeaderText = "İstifadəçi İD";
            DGV.Columns[1].HeaderText = "İşci adı";
            DGV.Columns[2].HeaderText = "İstifadəçi adı";
            DGV.Columns[3].HeaderText = "Şifrə";
            DGV.Columns[4].HeaderText = "Rolu";
            DGV.Columns[5].HeaderText = "Qeyd";
            DGV.Columns[6].HeaderText = "Redaktə olan";
            DGV.Columns[7].HeaderText = "Silinən";
            DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV.Columns[7].Visible = false;
            DGV.Columns[8].Visible = false;
            DGV.Columns[9].Visible = false;
        }      
               
        
        private void addBtn_Click(object sender, EventArgs e)
        {
            listelecomboboxworker();
            listelecomboboxrule();

            userIdTxt.Text = "";
            workerNameComboBox.Text = "";
            userNameTxt.Text = "";
            userPasswordTxt.Text = "";
            ruleComboBox.Text = "";
            userNoteTxt.Text = "";
            addEditGroupBox.Visible = true;
            userIdTxt.Visible = false;
            userIdLabel.Visible = false;
            editBtn.Enabled = false;
            editGBtn.Enabled = false;
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            workerNameComboBox.Items.Clear();
            baqlanti.Open();
            string query = "select * from IsciTable";
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
            baqlanti.Open();
            ruleComboBox.Items.Clear();
            query = "select * from RuleTable";
            kommand = new SQLiteCommand(query, baqlanti);
            dt = new DataTable();
            da = new SQLiteDataAdapter(kommand);
            da.Fill(dt);
            reader = kommand.ExecuteReader();
            while (reader.Read())
            {
                ComboboxItem cbitem = new ComboboxItem()
                {
                    Value = Convert.ToInt32(reader["RuleID"]),
                    Text = reader["RuleType"].ToString()
                };
                ruleComboBox.Items.Add(cbitem);
            }
            baqlanti.Close();

            addEditGroupBox.Visible = true;
            userIdTxt.Visible = true;
            userIdTxt.Enabled = false;
            userIdLabel.Visible = true;
            addGBtn.Visible = false;
            addBtn.Enabled = false;
            deleteBtn.Enabled = false;

            userIdTxt.Text = DGV.CurrentRow.Cells[0].Value.ToString();
            workerNameComboBox.Text = DGV.CurrentRow.Cells[1].Value.ToString();
            userNameTxt.Text = DGV.CurrentRow.Cells[2].Value.ToString();
            userPasswordTxt.Text = DGV.CurrentRow.Cells[3].Value.ToString();
            ruleComboBox.Text = DGV.CurrentRow.Cells[4].Value.ToString();
            userNoteTxt.Text = DGV.CurrentRow.Cells[5].Value.ToString();

            selectTable = User.name + " " + '"' + this.Text + '"' + " -ndə Köhnə məlumatı: ( ID-si: " + userIdTxt.Text + " , Adı: " + workerNameComboBox.Text + " , İstifadəçi adı: " + userNameTxt.Text + " , Şifrə: " + userPasswordTxt.Text + " , Rolu: " + ruleComboBox.Text + " , Qeyd: " + userNoteTxt.Text + " ) -->  Yeni məlumata: ( ";
            selectlistele();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult cavab;
            cavab = MessageBox.Show("Silmək istədiyinizə əminsiniz?", "Ehtiyatlı olun!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cavab == DialogResult.Yes)
            {
                int id = Convert.ToInt32(DGV.CurrentRow.Cells[0].Value.ToString());
                int isciid = Convert.ToInt32(DGV.CurrentRow.Cells[8].Value.ToString());
                string login = DGV.CurrentRow.Cells[2].Value.ToString();
                string upassword = DGV.CurrentRow.Cells[3].Value.ToString();
                int ruleid = Convert.ToInt32(DGV.CurrentRow.Cells[9].Value.ToString());
                string qeyd = DGV.CurrentRow.Cells[5].Value.ToString();
                string editInfo = DGV.CurrentRow.Cells[6].Value.ToString();
                string isciadi = DGV.CurrentRow.Cells[1].Value.ToString();
                string ruletype = DGV.CurrentRow.Cells[4].Value.ToString();

                SQLiteCommand kommand = new SQLiteCommand();

                kommand.Connection = baqlanti;
                kommand.CommandText = "Update IstifadeciTable Set IsciID=@IsciID,Login=@Login,UPassword=@UPassword,RuleID=@RuleID,Qeyd=@Qeyd,DeleteInfo=@DeleteInfo Where IstifadeciID=@IstifadeciID";
                kommand.Parameters.AddWithValue("@IstifadeciID", id);
                kommand.Parameters.AddWithValue("@IsciID", isciid);
                kommand.Parameters.AddWithValue("@Login", login);
                kommand.Parameters.AddWithValue("@UPassword", upassword);
                kommand.Parameters.AddWithValue("@RuleID", ruleid);
                kommand.Parameters.AddWithValue("@Qeyd", qeyd);
                kommand.Parameters.AddWithValue("@DeleteInfo", 2);
                baqlanti.Open();
                kommand.ExecuteNonQuery();
                baqlanti.Close();

                string DeleteRowLog = User.name + " Sildi: " + '"' + this.Text + '"' + " ində" + "(ID-si: " + id + " , İşci adı: " + isciadi + " , İstifadəçi adı: " + login + " , Şifrəsi: " + upassword + " , Rolu: " + ruletype + " , Qeyd: " + qeyd + ")";
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
            var isciidi = (workerNameComboBox.SelectedItem as ComboboxItem).Value;
            var ruleidi = (ruleComboBox.SelectedItem as ComboboxItem).Value;
            try
            {
                if (workerNameComboBox.Text.Trim() == "" || userNameTxt.Text.Trim() == "" || userPasswordTxt.Text.Trim() == "" || ruleComboBox.Text.Trim() == "" )
                {
                    MessageBox.Show("Boş xana buraxmayın!");
                }
                else
                {
                    try
                    {
                        string PasswordLog = GetMD5(userPasswordTxt.Text);
                        SQLiteCommand kommand1 = new SQLiteCommand();
                        kommand1.Connection = baqlanti;
                        kommand1.CommandText = "Insert Into IstifadeciTable (IsciID,Login,UPassword,RuleID,Qeyd) Values (@IsciID,@Login,@UPassword,@RuleID,@Qeyd)";
                        kommand1.Parameters.AddWithValue("@IsciID", isciidi);
                        kommand1.Parameters.AddWithValue("@Login", userNameTxt.Text);
                        kommand1.Parameters.AddWithValue("@UPassword", PasswordLog);
                        kommand1.Parameters.AddWithValue("@RuleID", ruleidi);
                        kommand1.Parameters.AddWithValue("@Qeyd", userNoteTxt.Text);
                        baqlanti.Open();
                        kommand1.ExecuteNonQuery();
                        baqlanti.Close();

                        string addLog = User.name + " " + '"' + this.Text + '"' + " -nə əlavə etdi: ( Adı: " + workerNameComboBox.Text + " , İstifadəçi adı: " + userNameTxt.Text + " , Şifrə: " + PasswordLog + " , Rolu: " + ruleComboBox.Text + " , Qeyd: " + userNoteTxt.Text + " )";
                        SQLiteCommand kommand = new SQLiteCommand();
                        kommand.Connection = baqlanti;
                        kommand.CommandText = "Insert Into LogTable (IsciID,OperationDate,OperationType,CommentInfo) Values (@IsciID,@OperationDate,@OperationType,@CommentInfo)";
                        kommand.Parameters.AddWithValue("@IsciID", Convert.ToInt32(User.isciid));
                        kommand.Parameters.AddWithValue("@OperationDate", DateTime.Now.ToString());
                        kommand.Parameters.AddWithValue("@OperationType", 0);
                        kommand.Parameters.AddWithValue("@CommentInfo", addLog);
                        baqlanti.Open();
                        kommand.ExecuteNonQuery();
                        baqlanti.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    baqlanti.Close();
                    MessageBox.Show("Əlavə olundu!");
                    listelecomboboxworker();
                    listelecomboboxrule();
                    silinen = false;
                    selectlistele();
                    workerNameComboBox.Text = "";
                    userNameTxt.Text = "";
                    userPasswordTxt.Text = "";
                    ruleComboBox.Text = "";
                    userNoteTxt.Text = "";
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
                if (workerNameComboBox.Text.Trim() == "" || userNameTxt.Text.Trim() == "" || userPasswordTxt.Text.Trim() == "" || ruleComboBox.Text.Trim() == "" || userNoteTxt.Text.Trim() == "")
                {
                    MessageBox.Show("Boş xana buraxmayın!");
                }
                else
                {
                    try
                    {
                        string PasswordLog = GetMD5(userPasswordTxt.Text);
                        var isciidi = (workerNameComboBox.SelectedItem as ComboboxItem).Value;
                        var ruleidi = (ruleComboBox.SelectedItem as ComboboxItem).Value;
                        SQLiteCommand kommand = new SQLiteCommand();
                        kommand.Connection = baqlanti;
                        baqlanti.Open();
                        kommand.CommandText = "Update IstifadeciTable Set IsciID=@IsciID,Login=@Login,UPassword=@UPassword,RuleID=@RuleID,Qeyd=@Qeyd,EditInfo=@EditInfo Where IstifadeciID=@IstifadeciID";
                        kommand.Parameters.AddWithValue("@IstifadeciID", Convert.ToInt32(userIdTxt.Text));
                        kommand.Parameters.AddWithValue("@IsciID", isciidi);
                        kommand.Parameters.AddWithValue("@Login", userNameTxt.Text);
                        kommand.Parameters.AddWithValue("@UPassword", PasswordLog);
                        kommand.Parameters.AddWithValue("@RuleID", ruleidi);
                        kommand.Parameters.AddWithValue("@Qeyd", userNoteTxt.Text);
                        kommand.Parameters.AddWithValue("@EditInfo", 1);
                        kommand.ExecuteNonQuery();
                        baqlanti.Close();

                        string changetable = " İd-si: " + userIdTxt.Text + " , İşci adı: " + userNoteTxt.Text + " , İstifadəçi adı: " + userNameTxt.Text + " , Şifrə: " + PasswordLog + " , Rolu: " + ruleComboBox.Text + " , Qeyd: " + userNoteTxt.Text + " ) dəyişdi";

                        baqlanti.Open();
                        kommand.CommandText = "Insert Into LogTable (IsciID,OperationDate,OperationType,CommentInfo) Values (@IsciID,@OperationDate,@OperationType,@CommentInfo)";
                        kommand.Parameters.AddWithValue("@IsciID", Convert.ToInt32(User.isciid));
                        kommand.Parameters.AddWithValue("@OperationDate", DateTime.Now.ToString());
                        kommand.Parameters.AddWithValue("@OperationType", 1);
                        kommand.Parameters.AddWithValue("@CommentInfo", selectTable + changetable);
                        kommand.ExecuteNonQuery();
                        baqlanti.Close();
                        MessageBox.Show("Redaktə olundu");
                        silinen = false;
                        selectlistele();
                        addEditGroupBox.Visible = false;
                        addGBtn.Visible = true;
                        addBtn.Enabled = true;
                        deleteBtn.Enabled = true;
                        addEditGroupBox.Hide();
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

            addGBtn.Visible = false;
            addBtn.Enabled = true;
            deleteBtn.Enabled = true;
        }

        private void excellexportBtn_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.InitialDirectory = "C:";
                saveFileDialog1.Title = "Excel-ə yaz";
                saveFileDialog1.FileName = "Məhsul Səhifəsi";
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

        private void showDeleteBtn_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    silinen = true;
                    selectlistele();
                    buttonGroupbox.Visible = false;
                    DGV.Columns[7].Visible = true;
                    hideDeleteBtn.Visible = true;
                    showDeleteBtn.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void hideDeleteBtn_Click(object sender, EventArgs e)
        {
            buttonGroupbox.Visible = true;
            DGV.Columns[7].Visible = false;
            hideDeleteBtn.Visible = false;
            showDeleteBtn.Visible = true;
            silinen = false;
            selectlistele();
        }

        private void cancelSearchBtn_Click(object sender, EventArgs e)
        {
            comboBoxSearch.SelectedItem = "Hamısını göstər";
            searchTxt.Text = "";
            setType = "";
            selectlistele();
        }

        private void searchTxt_TextChanged(object sender, EventArgs e)
        {
            selectlistele();
        }

        private void userForm_FormClosed(object sender, FormClosedEventArgs e)
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

        private void logsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            logForm logform = new logForm();
            logform.ShowDialog();
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
