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
using System.Data.SQLite;
using System.Text.RegularExpressions;
using Excel;
using System.IO;
using System.Diagnostics;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using System.Globalization;
using System.Net.Mail;

namespace AnbarProgrami
{
    public partial class factoryForm : Form
    {
        SQLiteConnection baqlanti = new SQLiteConnection();
        public string selectTable;
        public bool silinen = false;
        public string silinensql;
        public string editinsozu;
        public bool edited = false;
        public string editedsql;
        public factoryForm()
        {
            WindowsFormsSettings.ScrollUIMode = ScrollUIMode.Touch;
            InitializeComponent();
        }
        string connectionString = ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString;
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
                baqlanti.ConnectionString = (connectionString);
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

                SQLiteCommand kommand = new SQLiteCommand("Select KategoriyaTable.KategoriyName, Ad, WeherUnvan, RayonUnvan, QesebeUnvan, TamUnvan, Email, Temsilci, TWexsNomresi, TQeydUnvani, Phone, Tarixi, SifarisciTable.OperationDate, SifarisciTable.Qeyd, CAST ( CASE WHEN SifarisciTable.EditInfo = 1 THEN 'Redaktə olundu' END AS nvarchar(55)) as EditInfo, CAST ( CASE WHEN SifarisciTable.DeleteInfo = 2 THEN 'Silindi' END AS nvarchar(55)) as DeleteInfo, SifarisciID,SifarisciType, KategoriyaTable.KategoriyID From  SifarisciTable join KategoriyaTable on SifarisciTable.KategoriyID=KategoriyaTable.KategoriyID Where SifarisciType=0 And " + editedsql + " SifarisciTable.DeleteInfo " + silinensql, baqlanti);
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
        private void FactoryForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            selectlistele();
            silinen = false;
            if (User.ruletype == "Admin")
            {
                adminToolStripMenu.Visible = true;
                DGW.Columns[14].Visible = true;
                showDeleteBtn.Visible = true;
                showEditBtn.Visible = true;
            }
            else
            {
                adminToolStripMenu.Visible = false;
                DGW.Columns[14].Visible = false;
                showDeleteBtn.Visible = false;
                showEditBtn.Visible = false;
            }
            DGW.Columns[0].Caption = "Kateqoriyası";
            DGW.Columns[1].Caption = "Müəssənin adı";
            DGW.Columns[2].Caption = "Şəhər";
            DGW.Columns[3].Caption = "Rayon";
            DGW.Columns[4].Caption = "Qəsəbə";
            DGW.Columns[5].Caption = "Tam ünvan";
            DGW.Columns[6].Caption = "E-mail";
            DGW.Columns[7].Caption = "Təmsilçisi";
            DGW.Columns[8].Caption = "Təmsilçi Ş/V nömrəsi";
            DGW.Columns[9].Caption = "Təmsilçi Q ünvanı ";
            DGW.Columns[10].Caption = "Telefon nömrəsi";
            DGW.Columns[11].Caption = "Əlavə olunma tarixi";
            DGW.Columns[12].Caption = "Qeyd tarixi";
            DGW.Columns[13].Caption = "Qeyd";
            DGW.Columns[14].Caption = "Redaktə olunan";
            DGW.Columns[15].Caption = "Silinən";
            DGW.Columns[16].Caption = "SifarisciID";
            DGW.Columns[17].Caption = "SifarisciType";
            DGW.Columns[18].Caption = "KategoriyİD";
            DGW.Columns[15].Visible = false;
            DGW.Columns[16].Visible = false;
            DGW.Columns[17].Visible = false;
            DGW.Columns[18].Visible = false;
        }
        
       
        private void addBtn_Click(object sender, EventArgs e)
        {
            listelecomboboxKategoriy();
            factoryMarketNameTxt.Text = "";
            factoryMarketLocationSehTxt.Text = "";
            factoryMarketLocationRayTxt.Text = "";
            factoryMarketLocationQesTxt.Text = "";
            factoryMarketLocationTamTxt.Text = "";
            factoryMarketEmailTxt.Text = "";
            factoryMarketTemsilciTxt.Text = "";
            factoryMarketTemsilciSVNTxt.Text = "";
            factoryMarketTemsilciQUTxt.Text = "";
            factoryMarketPhoneTxt.Text = "";
            factoryMarketAddDTPicker.Text = "";
            factoryMarketNoteTxt.Text = "";
            addEditGFLPanel.Visible = true;
            editGBtn.Visible = false;
            addEditFLPanel.Visible = false;
            addEditGroupBox.Visible = true;
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(DGW.RowCount) == 0)
                {
                    MessageBox.Show("Redaktə olunacaq məlumat yoxdur!", "DİQQƏT!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    listelecomboboxKategoriy();
                    KategoryComboBox.Text = DGW.GetDataRow(DGW.FocusedRowHandle)[0].ToString();
                    factoryMarketNameTxt.Text = DGW.GetDataRow(DGW.FocusedRowHandle)[1].ToString();
                    factoryMarketLocationSehTxt.Text = DGW.GetDataRow(DGW.FocusedRowHandle)[2].ToString();
                    factoryMarketLocationRayTxt.Text = DGW.GetDataRow(DGW.FocusedRowHandle)[3].ToString();
                    factoryMarketLocationQesTxt.Text = DGW.GetDataRow(DGW.FocusedRowHandle)[4].ToString();
                    factoryMarketLocationTamTxt.Text = DGW.GetDataRow(DGW.FocusedRowHandle)[5].ToString();
                    factoryMarketEmailTxt.Text = DGW.GetDataRow(DGW.FocusedRowHandle)[6].ToString();
                    factoryMarketTemsilciTxt.Text = DGW.GetDataRow(DGW.FocusedRowHandle)[7].ToString();
                    factoryMarketTemsilciSVNTxt.Text = DGW.GetDataRow(DGW.FocusedRowHandle)[8].ToString();
                    factoryMarketTemsilciQUTxt.Text = DGW.GetDataRow(DGW.FocusedRowHandle)[9].ToString();
                    factoryMarketPhoneTxt.Text = DGW.GetDataRow(DGW.FocusedRowHandle)[10].ToString();
                    string qeydt = DGW.GetDataRow(DGW.FocusedRowHandle)[11].ToString();
                    string operationdate = DGW.GetDataRow(DGW.FocusedRowHandle)[12].ToString();
                    factoryMarketNoteTxt.Text = DGW.GetDataRow(DGW.FocusedRowHandle)[13].ToString();
                    int sifarisciid = Convert.ToInt32(DGW.GetDataRow(DGW.FocusedRowHandle)[16].ToString());
                    factoryMarketAddDTPicker.Text = DGW.GetDataRow(DGW.FocusedRowHandle)[14].ToString();


                    selectTable = User.name + " " + '"' + this.Text + '"' + " -ndə Köhnə məlumatı: ( Kateqoriyası: " + KategoryComboBox.Text + " , Adı: " + factoryMarketNameTxt.Text + " , Şəhər: " + factoryMarketLocationSehTxt.Text + " , Rayon: " + factoryMarketLocationRayTxt.Text + " , Qəsəbə: " + factoryMarketLocationQesTxt.Text + " , Tam ünvanı: " + factoryMarketLocationTamTxt.Text + " , Email: " + factoryMarketEmailTxt.Text + " , Təmsilçi: " + factoryMarketTemsilciTxt.Text + " , Təmsilçi Ş/V nömrəsi: " + factoryMarketTemsilciSVNTxt.Text + " , Təmsilçi Qeyd ünvanı: " + factoryMarketTemsilciQUTxt.Text + " , Telefon nömrəsi: " + factoryMarketPhoneTxt.Text + " , Əlavə olunma tarixi: " + factoryMarketAddDTPicker.Text + " , Qeyd tarixi: " + operationdate + " , Qeyd: " + factoryMarketNoteTxt.Text + " ) -->  Yeni məlumata: ( ";

                    addEditFLPanel.Visible = false;
                    addEditGroupBox.Visible = true;
                    addEditGFLPanel.Visible = true;
                    addGBtn.Visible = false;
                }
            }
            catch (Exception xeta)
            {
                MessageBox.Show(xeta.Message);
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
                    string operationdate = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                    string ad = DGW.GetDataRow(DGW.FocusedRowHandle)[1].ToString();
                    string seher = DGW.GetDataRow(DGW.FocusedRowHandle)[2].ToString();
                    string rayon = DGW.GetDataRow(DGW.FocusedRowHandle)[3].ToString();
                    string qesebe = DGW.GetDataRow(DGW.FocusedRowHandle)[4].ToString();
                    string tamunvan = DGW.GetDataRow(DGW.FocusedRowHandle)[5].ToString();
                    string email = DGW.GetDataRow(DGW.FocusedRowHandle)[6].ToString();
                    string temsilci = DGW.GetDataRow(DGW.FocusedRowHandle)[7].ToString();
                    string temsilciSVNTxt = DGW.GetDataRow(DGW.FocusedRowHandle)[8].ToString();
                    string temsilciQUTxt = DGW.GetDataRow(DGW.FocusedRowHandle)[9].ToString();
                    string phoneTxt = DGW.GetDataRow(DGW.FocusedRowHandle)[10].ToString();
                    string qeydt = DGW.GetDataRow(DGW.FocusedRowHandle)[11].ToString();
                    string addt = DGW.GetDataRow(DGW.FocusedRowHandle)[12].ToString();
                    string noteTxt = DGW.GetDataRow(DGW.FocusedRowHandle)[13].ToString();
                    int sifarisciid = Convert.ToInt32(DGW.GetDataRow(DGW.FocusedRowHandle)[16].ToString());
                    int sifariscitype = Convert.ToInt32(DGW.GetDataRow(DGW.FocusedRowHandle)[17].ToString());

                    SQLiteCommand kommand = new SQLiteCommand();

                    kommand.Connection = baqlanti;
                    kommand.CommandText = "Update SifarisciTable Set DeleteInfo=@DeleteInfo Where SifarisciID=@SifarisciID";
                    kommand.Parameters.AddWithValue("@SifarisciID", sifarisciid);
                    kommand.Parameters.AddWithValue("@DeleteInfo", 2);
                    baqlanti.Open();
                    kommand.ExecuteNonQuery();
                    baqlanti.Close();

                    string DeleteRowLog = User.name + " Sildi: " + '"' + this.Text + '"' + " ində" + "( Kateqoriyası: " + KategoryComboBox.Text + " , Adı: " + ad + " , Şəhər: " + seher + " , Rayon: " + rayon + " , Qəsəbə: " + qesebe + " , Tam ünvanı: " + tamunvan + " , Email: " + email + " , Təmsilçi: " + temsilci + " , Təmsilçi Ş/V nömrəsi: " + temsilciSVNTxt + " , Təmsilçi Qeyd ünvanı: " + temsilciQUTxt + " , Telefon nömrəsi: " + phoneTxt + " , Əlavə olunma tarixi: " + qeydt + " , Qeyd tarixi: " + addt + " , Qeyd: " + noteTxt + ")";

                    kommand.Connection = baqlanti;
                    kommand.CommandText = "Insert Into LogTable (IsciID,OperationDate,OperationType,CommentInfo) Values (@IsciID,@OperationDate,@OperationType,@CommentInfo)";
                    kommand.Parameters.AddWithValue("@IsciID", Convert.ToInt32(User.isciid));
                    kommand.Parameters.AddWithValue("@OperationDate", operationdate);
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
                string operationdate = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                if (KategoryComboBox.Text.Trim() == "" ||  factoryMarketNameTxt.Text.Trim() == "" || factoryMarketLocationSehTxt.Text.Trim() == "" || factoryMarketLocationRayTxt.Text.Trim() == "" || factoryMarketLocationQesTxt.Text.Trim() == "" || factoryMarketLocationTamTxt.Text.Trim() == "" || factoryMarketEmailTxt.Text.Trim() == "" || factoryMarketTemsilciTxt.Text.Trim() == "" || factoryMarketTemsilciSVNTxt.Text.Trim() == "" || factoryMarketTemsilciQUTxt.Text.Trim() == "" || factoryMarketPhoneTxt.Text.Trim() == "" || factoryMarketAddDTPicker.Text.Trim() == "")
                {
                    MessageBox.Show("Boş xana buraxmayın!");
                }
                else
                {
                    try
                    {
                        var kategoriyid = (KategoryComboBox.SelectedItem as ComboboxItem).Value;

                        SQLiteCommand kommand = new SQLiteCommand();
                        kommand.Connection = baqlanti;
                        baqlanti.Open();
                        kommand.CommandText = "Insert Into SifarisciTable (KategoriyID, Ad, WeherUnvan, RayonUnvan, QesebeUnvan, TamUnvan, Email, Temsilci, TWexsNomresi, TQeydUnvani, Phone, Tarixi, OperationDate, Qeyd, SifarisciType) Values (@KategoriyID, @Ad, @WeherUnvan, @RayonUnvan, @QesebeUnvan, @TamUnvan, @Email, @Temsilci, @TWexsNomresi, @TQeydUnvani, @Phone, @Tarixi, @OperationDate, @Qeyd, @SifarisciType)";
                        kommand.Parameters.AddWithValue("@KategoriyID", kategoriyid);
                        kommand.Parameters.AddWithValue("@Ad", factoryMarketNameTxt.Text);
                        kommand.Parameters.AddWithValue("@WeherUnvan", factoryMarketLocationSehTxt.Text);
                        kommand.Parameters.AddWithValue("@RayonUnvan", factoryMarketLocationRayTxt.Text);
                        kommand.Parameters.AddWithValue("@QesebeUnvan", factoryMarketLocationQesTxt.Text);
                        kommand.Parameters.AddWithValue("@TamUnvan", factoryMarketLocationTamTxt.Text);
                        kommand.Parameters.AddWithValue("@Email", factoryMarketEmailTxt.Text);
                        kommand.Parameters.AddWithValue("@Temsilci", factoryMarketTemsilciTxt.Text);
                        kommand.Parameters.AddWithValue("@TWexsNomresi", factoryMarketTemsilciSVNTxt.Text);
                        kommand.Parameters.AddWithValue("@TQeydUnvani", factoryMarketTemsilciQUTxt.Text);
                        kommand.Parameters.AddWithValue("@Phone", factoryMarketPhoneTxt.Text);
                        kommand.Parameters.AddWithValue("@Tarixi", factoryMarketAddDTPicker.Text);
                        kommand.Parameters.AddWithValue("@OperationDate", operationdate);
                        kommand.Parameters.AddWithValue("@Qeyd", factoryMarketNoteTxt.Text);
                        kommand.Parameters.AddWithValue("@SifarisciType", 0);
                        kommand.ExecuteNonQuery();
                        baqlanti.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    try
                    {
                        string addLog = User.name + " " + '"' + this.Text + '"' + " -nə əlavə etdi: ( Kateqoriyası: " + KategoryComboBox.Text + " , Adı: " + factoryMarketNameTxt.Text + " , Şəhər: " + factoryMarketLocationSehTxt.Text + " , Rayon: " + factoryMarketLocationRayTxt.Text + " , Qəsəbə: " + factoryMarketLocationQesTxt.Text + " , Tam ünvanı: " + factoryMarketLocationTamTxt.Text + " , Email: " + factoryMarketEmailTxt.Text + " , Təmsilçi: " + factoryMarketTemsilciTxt.Text + " , Təmsilçi Ş/V nömrəsi: " + factoryMarketTemsilciSVNTxt.Text + " , Təmsilçi Qeyd ünvanı: " + factoryMarketTemsilciQUTxt.Text + " , Telefon nömrəsi: " + factoryMarketPhoneTxt.Text + " , Əlavə olunma tarixi: " + factoryMarketAddDTPicker.Text + " , Qeyd tarixi: " + operationdate + " , Qeyd: " + factoryMarketNoteTxt.Text + " )";
                        SQLiteCommand kommand = new SQLiteCommand();
                        kommand.Connection = baqlanti;
                        kommand.CommandText = "Insert Into LogTable (IsciID,OperationDate,OperationType,CommentInfo) Values (@IsciID,@OperationDate,@OperationType,@CommentInfo)";
                        kommand.Parameters.AddWithValue("@IsciID", Convert.ToInt32(User.isciid));
                        kommand.Parameters.AddWithValue("@OperationDate", operationdate);
                        kommand.Parameters.AddWithValue("@OperationType", 0);
                        kommand.Parameters.AddWithValue("@CommentInfo", addLog);
                        baqlanti.Open();
                        kommand.ExecuteNonQuery();
                        baqlanti.Close();
                        MessageBox.Show("Əlavə olundu!");
                        silinen = false;
                        selectlistele();
                        factoryMarketNameTxt.Text = "";
                        factoryMarketLocationSehTxt.Text = "";
                        factoryMarketLocationRayTxt.Text = "";
                        factoryMarketLocationQesTxt.Text = "";
                        factoryMarketLocationTamTxt.Text = "";
                        factoryMarketEmailTxt.Text = "";
                        factoryMarketTemsilciTxt.Text = "";
                        factoryMarketTemsilciSVNTxt.Text = "";
                        factoryMarketTemsilciQUTxt.Text = "";
                        factoryMarketPhoneTxt.Text = "";
                        factoryMarketAddDTPicker.Text = "";
                        factoryMarketNoteTxt.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
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
            int sifarisciid = Convert.ToInt32(DGW.GetDataRow(DGW.FocusedRowHandle)[16].ToString());
            string operationdate = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            try
            {
                if (KategoryComboBox.Text.Trim() == "" || factoryMarketNameTxt.Text.Trim() == "" || factoryMarketLocationSehTxt.Text.Trim() == "" || factoryMarketLocationRayTxt.Text.Trim() == "" || factoryMarketLocationQesTxt.Text.Trim() == "" || factoryMarketLocationTamTxt.Text.Trim() == "" || factoryMarketEmailTxt.Text.Trim() == "" || factoryMarketTemsilciTxt.Text.Trim() == "" || factoryMarketTemsilciSVNTxt.Text.Trim() == "" || factoryMarketTemsilciQUTxt.Text.Trim() == "" || factoryMarketPhoneTxt.Text.Trim() == "" || factoryMarketAddDTPicker.Text.Trim() == "" || factoryMarketNoteTxt.Text.Trim() == "")
                {
                    MessageBox.Show("Boş xana buraxmayın!");
                }
                else
                {
                    try
                    {
                        var kategoriyid = (KategoryComboBox.SelectedItem as ComboboxItem).Value;

                        SQLiteCommand kommand = new SQLiteCommand();
                        kommand.Connection = baqlanti;
                        kommand.CommandText = "Update SifarisciTable Set KategoriyID=@KategoriyID, Ad=@Ad, WeherUnvan=@WeherUnvan, RayonUnvan=@RayonUnvan, QesebeUnvan=@QesebeUnvan, TamUnvan=@TamUnvan, Email=@Email, Temsilci=@Temsilci, TWexsNomresi=@TWexsNomresi, TQeydUnvani=@TQeydUnvani, Phone=@Phone, Tarixi=Tarixi, OperationDate=@OperationDate, Qeyd=@Qeyd, EditInfo=@EditInfo Where SifarisciID=@SifarisciID";
                        kommand.Parameters.AddWithValue("@SifarisciID", sifarisciid);
                        kommand.Parameters.AddWithValue("@KategoriyID", kategoriyid);
                        kommand.Parameters.AddWithValue("@Ad", factoryMarketNameTxt.Text);
                        kommand.Parameters.AddWithValue("@WeherUnvan", factoryMarketLocationSehTxt.Text);
                        kommand.Parameters.AddWithValue("@RayonUnvan", factoryMarketLocationRayTxt.Text);
                        kommand.Parameters.AddWithValue("@QesebeUnvan", factoryMarketLocationQesTxt.Text);
                        kommand.Parameters.AddWithValue("@TamUnvan", factoryMarketLocationTamTxt.Text);
                        kommand.Parameters.AddWithValue("@Email", factoryMarketEmailTxt.Text);
                        kommand.Parameters.AddWithValue("@Temsilci", factoryMarketTemsilciTxt.Text);
                        kommand.Parameters.AddWithValue("@TWexsNomresi", factoryMarketTemsilciSVNTxt.Text);
                        kommand.Parameters.AddWithValue("@TQeydUnvani", factoryMarketTemsilciQUTxt.Text);
                        kommand.Parameters.AddWithValue("@Phone", factoryMarketPhoneTxt.Text);
                        kommand.Parameters.AddWithValue("@Tarixi", factoryMarketAddDTPicker.Text);
                        kommand.Parameters.AddWithValue("@OperationDate", operationdate);
                        kommand.Parameters.AddWithValue("@Qeyd", factoryMarketNoteTxt.Text);
                        kommand.Parameters.AddWithValue("@EditInfo", 1);
                        baqlanti.Open();
                        kommand.ExecuteNonQuery();
                        baqlanti.Close();
                        string changetable = " Kateqoriyası: " + KategoryComboBox.Text + " , Adı: " + factoryMarketNameTxt.Text + " , Şəhər: " + factoryMarketLocationSehTxt.Text + " , Rayon: " + factoryMarketLocationRayTxt.Text + " , Qəsəbə: " + factoryMarketLocationQesTxt.Text + " , Tam ünvanı: " + factoryMarketLocationTamTxt.Text + " , Email: " + factoryMarketEmailTxt.Text + " , Təmsilçi: " + factoryMarketTemsilciTxt.Text + " , Təmsilçi Ş/V nömrəsi: " + factoryMarketTemsilciSVNTxt.Text + " , Təmsilçi Qeyd ünvanı: " + factoryMarketTemsilciQUTxt.Text + " , Telefon nömrəsi: " + factoryMarketPhoneTxt.Text + " , Əlavə olunma tarixi: " + factoryMarketAddDTPicker.Text + " , Qeyd tarixi: " + operationdate + " , Qeyd: " + factoryMarketNoteTxt.Text + " ) dəyişdi";
                        kommand.CommandText = "Insert Into LogTable (IsciID,OperationDate,OperationType,CommentInfo) Values (@IsciID,@OperationDate,@OperationType,@CommentInfo)";
                        kommand.Parameters.AddWithValue("@IsciID", Convert.ToInt32(User.isciid));
                        kommand.Parameters.AddWithValue("@OperationDate", operationdate);
                        kommand.Parameters.AddWithValue("@OperationType", 1);
                        kommand.Parameters.AddWithValue("@CommentInfo", selectTable + changetable);
                        baqlanti.Open();
                        kommand.ExecuteNonQuery();
                        baqlanti.Close();
                        MessageBox.Show("Redaktə olundu");
                        factoryMarketNameTxt.Text = "";
                        factoryMarketLocationSehTxt.Text = "";
                        factoryMarketLocationRayTxt.Text = "";
                        factoryMarketLocationQesTxt.Text = "";
                        factoryMarketLocationTamTxt.Text = "";
                        factoryMarketEmailTxt.Text = "";
                        factoryMarketTemsilciTxt.Text = "";
                        factoryMarketTemsilciSVNTxt.Text = "";
                        factoryMarketTemsilciQUTxt.Text = "";
                        factoryMarketPhoneTxt.Text = "";
                        factoryMarketAddDTPicker.Text = "";
                        factoryMarketNoteTxt.Text = "";

                        silinen = false;
                        selectlistele();

                        addEditFLPanel.Visible = true;
                        addEditGroupBox.Visible = false;
                        addEditGFLPanel.Visible = false;
                        addGBtn.Visible = true;
                        editGBtn.Visible = true;
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
            editinsozu = " SifarisciTable.EditInfo " + editedsql + " And ";
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
                DGW.Columns[15].Visible = true;
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
            {
                DGW.Columns[15].Visible = false;
                hideDeleteBtn.Visible = false;
                showDeleteBtn.Visible = true;
                commonFLPanel.Visible = true;
                silinen = false;
                selectlistele();
            }
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

        private void factoryForm_FormClosed(object sender, FormClosedEventArgs e)
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

        private void zavodAlışSəhifəsiToolStripMenuItem_Click(object sender, EventArgs e)
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
