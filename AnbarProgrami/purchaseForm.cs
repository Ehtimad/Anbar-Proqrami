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
using DevExpress.XtraReports.UI;

namespace AnbarProgrami
{
    public partial class purchaseForm : Form
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
        public purchaseForm()
        {
            InitializeComponent();
        }

        string connectionString = ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString;

        public void listelecomboboxQaime()
        {
            try
            {
                qaimeAlisSatisComboBox.Items.Clear();
                baqlanti.Open();
                string query = "Select * from QaimeTable where QaimeTable.DeleteInfo is not 2 order by QaimeID desc";
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
                        Value = Convert.ToInt32(reader["QaimeID"]),
                        Text = reader["QaimeNomresi"].ToString()
                    };
                    qaimeAlisSatisComboBox.Items.Add(cbitem);
                }
                baqlanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void listelecomboboxfactory()
        {
            try
            {
                factorymarketComboBox.Items.Clear();
                baqlanti.Open();
                string query = "select * from SifarisciTable Where SifarisciType=0 And DeleteInfo is not 2 order by Ad asc";
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
                        Value = Convert.ToInt32(reader["SifarisciID"]),
                        Text = reader["Ad"].ToString()
                    };
                    factorymarketComboBox.Items.Add(cbitem);
                }
                baqlanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void listelecomboboxProduc()
        {

            productNameComboBox.Items.Clear();
            productNameComboBox.Items.Add("Yoxdur");
            SQLiteCommand kommandkat = new SQLiteCommand();
            baqlanti.Open();
            string querykat = "select * from MehsulTable Where DeleteInfo is not 2 order by Ad asc";
            kommandkat = new SQLiteCommand(querykat, baqlanti);
            DataTable dtkat = new DataTable();
            SQLiteDataAdapter dakat = new SQLiteDataAdapter(kommandkat);
            dakat.Fill(dtkat);
            SQLiteDataReader readerkat;
            readerkat = kommandkat.ExecuteReader();
            while (readerkat.Read())
            {
                ComboboxItem cbitem = new ComboboxItem()
                {
                    Value = Convert.ToInt32(readerkat["MehsulID"]),
                    Text = readerkat["Ad"].ToString() + " " + readerkat["Nov"].ToString()
                };
                productNameComboBox.Items.Add(cbitem);
            }
            baqlanti.Close();
        }
        public void listelecomboboxProducBonus()
        {
            bonusMehsulcomboBox.Items.Clear();
            bonusMehsulcomboBox.Items.Add("Yoxdur");
            SQLiteCommand kommandkat = new SQLiteCommand();
            baqlanti.Open();
            string querykat = "select * from MehsulTable Where DeleteInfo is not 2 order by Ad asc";
            kommandkat = new SQLiteCommand(querykat, baqlanti);
            DataTable dtkat = new DataTable();
            SQLiteDataAdapter dakat = new SQLiteDataAdapter(kommandkat);
            dakat.Fill(dtkat);
            SQLiteDataReader readerkat;
            readerkat = kommandkat.ExecuteReader();
            while (readerkat.Read())
            {
                ComboboxItem cbitem = new ComboboxItem()
                {
                    Value = Convert.ToInt32(readerkat["MehsulID"]),
                    Text = readerkat["Ad"].ToString() + " " + readerkat["Nov"].ToString()
                };
                bonusMehsulcomboBox.Items.Add(cbitem);
            }
            baqlanti.Close();
        }
        public void selectlistele()
        {

            try
            {
                baqlanti.ConnectionString = (connectionString);
                if (silinen.Equals(true))
                {
                    silinensql = " is 2";
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

                DataTable table = new DataTable();
                SQLiteCommand kommand = new SQLiteCommand("Select QaimeTable.QaimeNomresi, QaimeTable.Tarix, KT.KategoriyName, SciT.AD, SciT.Temsilci, SciT.WeherUnvan, SciT.RayonUnvan, SciT.QesebeUnvan, IT.Ad, mt.AD, mt.Nov, mt.OlcuVahidi, CAST ( CASE WHEN ASMT.OperationType = 0 THEN 'Alış' WHEN ASMT.OperationType = 1 THEN 'Qaytarma' WHEN ASMT.OperationType = 2 THEN 'Satış' ELSE 'Qaytarma' END AS nvarchar(55)) as OperationType, Miqdari, Qiymet, Guzest, mt1.AD, mt1.Nov, BonusMiqdar, UmumiSay, BirGuzestMebleqi, CemGuzestMebleqi, CemGuzestsizQiymet, BirGuzestliQiymet, CemGuzestliQiymet, ASMT.OperationDate, ASMT.Qeyd, CAST ( CASE WHEN ASMT.EditInfo = 1 THEN 'Redaktə olundu' END AS nvarchar(55)) as EditInfo, CAST ( CASE WHEN ASMT.DeleteInfo = 2 THEN 'Silindi' END AS nvarchar(55)) as DeleteInfo, ASMT.AlisSatisMehsulID, QaimeTable.QaimeID, mt.MehsulID, SciT.SifarisciID, BonusMehsulID from AlisSatisMehsulTable ASMT left join MehsulTable mt on mt.MehsulID=ASMT.MehsulID left join MehsulTable mt1 on mt1.MehsulID=ASMT.BonusMehsulID left join QaimeTable on ASMT.QaimeID = QaimeTable.QaimeID join SifarisciTable SciT on ASMT.SifarisciID = SciT.SifarisciID left join KategoriyaTable KT on SciT.KategoriyID=KT.KategoriyID join IsciTable IT on QaimeTable.IsciID=IT.IsciID Where " + editedsql + " ASMT.DeleteInfo " + silinensql + " And QaimeTable.Tarix >=  @Date1 And QaimeTable.Tarix <= @Date2 And OdemeType is null And (ASMT.OperationType=0 or ASMT.OperationType=1) order by AlisSatisMehsulID desc", baqlanti);
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
        private void PurchaseForm_Load(object sender, EventArgs e)
        {
            search1DTPicker.Text = "";
            search2DTPicker.Text = "";
            WindowState = FormWindowState.Maximized;
            selectlistele();
            silinen = false;
            if (User.ruletype == "Admin")
            {
                adminToolStripMenu.Visible = true;
                DGW.Columns[27].Visible = true;
                showDeleteBtn.Visible = true;
                showEditBtn.Visible = true;
                ReportBtn.Visible = true;
            }
            else
            {
                adminToolStripMenu.Visible = false;
                DGW.Columns[27].Visible = false;
                showDeleteBtn.Visible = false;
                showEditBtn.Visible = false;
                ReportBtn.Visible = false;
            }
            DGW.Columns[0].Caption = "Qaimə nömrəsi";
            DGW.Columns[1].Caption = "Tarix";
            DGW.Columns[2].Caption = "Kateqoriyası";
            DGW.Columns[3].Caption = "Müəssənin adı";
            DGW.Columns[4].Caption = "Təmsilçisi";
            DGW.Columns[5].Caption = "Şəhər";
            DGW.Columns[6].Caption = "Rayon";
            DGW.Columns[7].Caption = "Qəsəbə";
            DGW.Columns[8].Caption = "İşcinin adı";
            DGW.Columns[9].Caption = "Məhsulun adı";
            DGW.Columns[10].Caption = "Məhsulun növü";
            DGW.Columns[11].Caption = "Ölçü vahidi";
            DGW.Columns[12].Caption = "Əməliyyatın növü";
            DGW.Columns[13].Caption = "Məhsulun miqdarı";
            DGW.Columns[14].Caption = "Qiyməti";
            DGW.Columns[15].Caption = "Güzəşt faizi";
            DGW.Columns[16].Caption = "Hədiyyə məhsulun adı";
            DGW.Columns[17].Caption = "Hədiyyə məhsulun növü";
            DGW.Columns[18].Caption = "Hədiyyə məhsulun miqdarı";
            DGW.Columns[19].Caption = "Ümumi sayı";
            DGW.Columns[20].Caption = "Bir ədədin güzəşti";
            DGW.Columns[21].Caption = "Cəm ədədin güzəşti";
            DGW.Columns[22].Caption = "Cəm güzəştsiz qiymət";
            DGW.Columns[23].Caption = "Birinin güzəştli qiyməti";
            DGW.Columns[24].Caption = "Cəm güzəştli qiymət";
            DGW.Columns[25].Caption = "Qeyd tarixi";
            DGW.Columns[26].Caption = "Qeyd";
            DGW.Columns[27].Caption = "Redaktə olunan";
            DGW.Columns[28].Caption = "Silinən";
            DGW.Columns[29].Caption = "AlisSatisMehsulID";
            DGW.Columns[30].Caption = "QaimeID";
            DGW.Columns[31].Caption = "MehsulID";
            DGW.Columns[32].Caption = "SifarisciID";
            DGW.Columns[33].Caption = "BonusMehsulID";
            DGW.Columns[28].Visible = false;
            DGW.Columns[29].Visible = false;
            DGW.Columns[30].Visible = false;
            DGW.Columns[31].Visible = false;
            DGW.Columns[32].Visible = false;
            DGW.Columns[33].Visible = false;
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
                    int AlisSatismehsulid = Convert.ToInt32(DGW.GetDataRow(DGW.FocusedRowHandle)[29].ToString());
                    string qaimen = DGW.GetDataRow(DGW.FocusedRowHandle)[0].ToString();
                    string silmevaxdi = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

                    SQLiteCommand kommand = new SQLiteCommand();
                    kommand.Connection = baqlanti;
                    kommand.CommandText = "Update AlisSatisMehsulTable Set DeleteInfo=@DeleteInfo Where AlisSatisMehsulID=@AlisSatisMehsulID";
                    kommand.Parameters.AddWithValue("@AlisSatisMehsulID", AlisSatismehsulid);
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

        private void hideGBtn_Click(object sender, EventArgs e)
        {
            addEditFLPanel.Visible = true;
            addEditQeydGroupBox.Visible = false;
            addEditGFLPanel.Visible = false;
            listelecomboboxProduc();
            listelecomboboxQaime();
            listelecomboboxfactory();

            operationTypeComboBox.SelectedIndex = 0;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            listelecomboboxfactory();
            listelecomboboxProduc();
            listelecomboboxProducBonus();
            listelecomboboxQaime();
            factorymarketComboBox.Text = "";
            qaimeAlisSatisComboBox.Text = "";
            productNameComboBox.Text = "";
            productMiqdarTxt.Text = "";
            mehsulPriceTxt.Text = "";
            operationTypeComboBox.Text = "";

            bonusMehsulcomboBox.Text = "";
            guzestTxt.Text = "";
            productNameComboBox.Text = "";
            bonusMiqdarTxt.Text = "";
            noteTxt.Text = "";

            addEditFLPanel.Visible = false;
            addEditQeydGroupBox.Visible = true;
            addEditGFLPanel.Visible = true;
            editGBtn.Visible = false;
            addGBtn.Visible = true;
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(DGW.RowCount) == 0)
            {
                MessageBox.Show("Redaktə olunacaq məlumat yoxdur!", "DİQQƏT!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                listelecomboboxProduc();
                listelecomboboxfactory();
                listelecomboboxProducBonus();
                listelecomboboxQaime();
                addEditFLPanel.Visible = false;
                addEditQeydGroupBox.Visible = true;
                addEditGFLPanel.Visible = true;
                addGBtn.Visible = false;
                editGBtn.Visible = true;
                qaimeAlisSatisComboBox.Text = DGW.GetDataRow(DGW.FocusedRowHandle)[0].ToString();
                factorymarketComboBox.Text = DGW.GetDataRow(DGW.FocusedRowHandle)[3].ToString();
                productNameComboBox.Text = DGW.GetDataRow(DGW.FocusedRowHandle)[9].ToString();
                operationTypeComboBox.Text = DGW.GetDataRow(DGW.FocusedRowHandle)[12].ToString();
                productMiqdarTxt.Text = DGW.GetDataRow(DGW.FocusedRowHandle)[13].ToString();
                mehsulPriceTxt.Text = DGW.GetDataRow(DGW.FocusedRowHandle)[14].ToString();
                guzestTxt.Text = DGW.GetDataRow(DGW.FocusedRowHandle)[15].ToString();
                string bonusmad = DGW.GetDataRow(DGW.FocusedRowHandle)[16].ToString();
                if (string.IsNullOrEmpty(bonusmad))
                {
                    bonusMehsulcomboBox.SelectedItem = 0;
                }
                else
                {
                    bonusMehsulcomboBox.Text = DGW.GetDataRow(DGW.FocusedRowHandle)[16].ToString();
                }
                bonusMiqdarTxt.Text = DGW.GetDataRow(DGW.FocusedRowHandle)[18].ToString();
                noteTxt.Text = DGW.GetDataRow(DGW.FocusedRowHandle)[26].ToString();
                selectTable = User.name + " " + '"' + this.Text + '"' + " Səhifəsində" + " Köhnə məlumatı: ( Qaimə nömrəsi: " + qaimeAlisSatisComboBox.Text + "Müəssisə adı: " + factorymarketComboBox.Text + " ,Məhsulun adı:" + productNameComboBox.Text + " , Alış və ya geri qaytarma: " + operationTypeComboBox.Text + " ,Miqdarı:" + productMiqdarTxt.Text + " ,Alış qiyməti:" + mehsulPriceTxt.Text + " ,Güzəşt:" + guzestTxt.Text + " Faiz " + " ,Hədiyyə məhsulun adı:" + productNameComboBox.Text + " , Hədiyyə məhsulun miqdarı:" + bonusMiqdarTxt.Text + " , Qeyd: " + noteTxt.Text + " ) -->  Yeni məlumata: ( ";
            }

        }

        private void addGBtn_Click(object sender, EventArgs e)
        {
            try
            {
                    if (factorymarketComboBox.Text.Trim() == "" || qaimeAlisSatisComboBox.Text.Trim() == "" || productNameComboBox.Text.Trim() == "" || operationTypeComboBox.Text.Trim() == "")
                {
                    MessageBox.Show("Boş xana buraxmayın!");
                }
                else
                {
                    if (guzestTxt.Text == "")
                    {
                        guzestTxt.Text = "0";
                    }
                    if (bonusMiqdarTxt.Text == "")
                    {
                        bonusMiqdarTxt.Text = "0";
                    }

                    float UmumiSay, BirGuzestMebleqi, CemGuzestsizQiymet, CemGuzestMebleqi, CemGuzestliQiymet, BirGuzestliQiymet, miqdar, bonus, qiymet, guzest;
                    int operationtype;
                   
                    if (productNameComboBox.SelectedIndex == 0)
                    {
                        qiymet = 0;
                        miqdar = 0;
                    }
                    else
                    {
                        qiymet = (float.Parse(mehsulPriceTxt.Text));
                        miqdar = (float.Parse(productMiqdarTxt.Text));
                    }
                    if (operationTypeComboBox.SelectedIndex == 0)
                    {
                        operationtype = 0;
                        bonus = (float.Parse(bonusMiqdarTxt.Text));
                        guzest = (float.Parse(guzestTxt.Text));
                        UmumiSay = miqdar + bonus;
                        BirGuzestMebleqi = (Math.Abs(qiymet) * guzest) / 100;
                        CemGuzestsizQiymet = (miqdar * qiymet);
                        CemGuzestMebleqi = (BirGuzestMebleqi * Math.Abs(miqdar));
                        BirGuzestliQiymet = qiymet - BirGuzestMebleqi;
                        CemGuzestliQiymet = miqdar * BirGuzestliQiymet;
                    }
                    else
                    {
                        operationtype = 1;
                        miqdar = (0 - float.Parse(productMiqdarTxt.Text));
                        bonus = (0 - float.Parse(bonusMiqdarTxt.Text));
                        guzest = (float.Parse(guzestTxt.Text));
                        UmumiSay = miqdar + bonus;
                        BirGuzestMebleqi = (Math.Abs(qiymet) * guzest) / 100;
                        CemGuzestsizQiymet = (miqdar * qiymet);
                        CemGuzestMebleqi = (BirGuzestMebleqi * Math.Abs(miqdar));
                        BirGuzestliQiymet = qiymet - BirGuzestMebleqi;
                        CemGuzestliQiymet = miqdar * BirGuzestliQiymet;
                    }

                    var zavodmarketid = (factorymarketComboBox.SelectedItem as ComboboxItem).Value;
                    var QaimeID = (qaimeAlisSatisComboBox.SelectedItem as ComboboxItem).Value;
                    string qeydt = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

                    SQLiteCommand kommand = new SQLiteCommand();
                    kommand.Connection = baqlanti;
                    baqlanti.Open();
                    kommand.CommandText = "Insert Into AlisSatisMehsulTable (QaimeID, OperationType, SifarisciID, MehsulID,  Miqdari, Qiymet, Guzest, BonusMehsulID, BonusMiqdar, UmumiSay, BirGuzestMebleqi, CemGuzestMebleqi,  CemGuzestsizQiymet, BirGuzestliQiymet, CemGuzestliQiymet,  OperationDate, Qeyd) Values (@QaimeID, @OperationType, @SifarisciID, @MehsulID, @Miqdari, @Qiymet, @Guzest, @BonusMehsulID, @BonusMiqdar, @UmumiSay, @BirGuzestMebleqi, @CemGuzestMebleqi, @CemGuzestsizQiymet, @BirGuzestliQiymet, @CemGuzestliQiymet, @OperationDate, @Qeyd)";
                    kommand.Parameters.AddWithValue("@QaimeID", QaimeID);
                    kommand.Parameters.AddWithValue("@OperationType", operationtype);
                    kommand.Parameters.AddWithValue("@SifarisciID", Convert.ToInt32(zavodmarketid));

                    if (productNameComboBox.SelectedIndex == 0)
                    {
                        kommand.Parameters.AddWithValue("@MehsulID", null);
                        kommand.Parameters.AddWithValue("@Miqdari", null);
                    }
                    else
                    {
                        var mehsulid = (productNameComboBox.SelectedItem as ComboboxItem).Value;
                        kommand.Parameters.AddWithValue("@MehsulID", mehsulid);
                        kommand.Parameters.AddWithValue("@Miqdari", Math.Round(miqdar, 2));
                    }

                    kommand.Parameters.AddWithValue("@Qiymet", Math.Round(qiymet, 2));
                    if (bonusMehsulcomboBox.SelectedIndex == 0)
                    {
                        kommand.Parameters.AddWithValue("@BonusMehsulID", null);
                        kommand.Parameters.AddWithValue("@BonusMiqdar", null);
                    }
                    else
                    {
                        var mehsulidbonus = (bonusMehsulcomboBox.SelectedItem as ComboboxItem).Value;
                        kommand.Parameters.AddWithValue("@BonusMehsulID", mehsulidbonus);
                        kommand.Parameters.AddWithValue("@BonusMiqdar", Math.Round(bonus, 2));
                    }
                    if (guzestTxt.Text == "0")
                    {
                        kommand.Parameters.AddWithValue("@Guzest", null);
                    }
                    else
                    {
                        kommand.Parameters.AddWithValue("@Guzest", Math.Round(guzest, 2));
                    }
                    kommand.Parameters.AddWithValue("@UmumiSay", Math.Round(UmumiSay, 2));
                    kommand.Parameters.AddWithValue("@BirGuzestMebleqi", Math.Round(BirGuzestMebleqi, 2));
                    kommand.Parameters.AddWithValue("@CemGuzestMebleqi", Math.Round(CemGuzestMebleqi, 2));
                    kommand.Parameters.AddWithValue("@CemGuzestsizQiymet", Math.Round(CemGuzestsizQiymet, 2));
                    kommand.Parameters.AddWithValue("@BirGuzestliQiymet", Math.Round(BirGuzestliQiymet, 2));
                    kommand.Parameters.AddWithValue("@CemGuzestliQiymet", Math.Round(CemGuzestliQiymet, 2));
                    kommand.Parameters.AddWithValue("@OperationDate", qeydt);
                    kommand.Parameters.AddWithValue("@Qeyd", noteTxt.Text);
                    kommand.ExecuteNonQuery();
                    baqlanti.Close();

                    kommand = new SQLiteCommand();
                    kommand.Connection = baqlanti;
                    baqlanti.Open();
                    string addLog = User.name + " " + '"' + this.Text + '"' + " Səhifəsinə əlavə etdi: ( Qaimə nömrəsi: " + qaimeAlisSatisComboBox.Text + " Müəssisə adı:" + factorymarketComboBox.Text + " ,Məhsulun adı:" + productNameComboBox.Text + " , Alış və ya geri qaytarma: " + operationTypeComboBox.Text + " ,Miqdarı:" + productMiqdarTxt.Text + " ,Alış qiyməti:" + mehsulPriceTxt.Text + " ,Güzəşt:" + guzestTxt.Text + " Faiz " + " ,Hədiyyə məhsulun adı:" + bonusMehsulcomboBox.Text + " , Hədiyyə məhsulun miqdarı:" + bonusMiqdarTxt.Text + " , Qeyd: " + noteTxt.Text + " )";
                    kommand.CommandText = "Insert Into LogTable (IsciID,OperationDate,OperationType,CommentInfo) Values (@IsciID,@OperationDate,@OperationType,@CommentInfo)";
                    kommand.Parameters.AddWithValue("@IsciID", Convert.ToInt32(User.isciid));
                    kommand.Parameters.AddWithValue("@OperationDate", qeydt);
                    kommand.Parameters.AddWithValue("@OperationType", 0);
                    kommand.Parameters.AddWithValue("@CommentInfo", addLog);
                    kommand.ExecuteNonQuery();
                    baqlanti.Close();
                    MessageBox.Show("Əlavə olundu!");

                    qaimeAlisSatisComboBox.Text = "";
                    factorymarketComboBox.Text = "";
                    productNameComboBox.Text = "";
                    operationTypeComboBox.Text = "";
                    bonusMehsulcomboBox.Text = "";
                    productMiqdarTxt.Text = "";
                    mehsulPriceTxt.Text = "";
                    guzestTxt.Text = "";
                    productNameComboBox.Text = "";
                    bonusMiqdarTxt.Text = "";
                    noteTxt.Text = "";
                    listelecomboboxProduc();
                    listelecomboboxfactory();
                    listelecomboboxProducBonus();
                    listelecomboboxQaime();
                    silinen = false;
                    selectlistele();
                }
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void editGBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (factorymarketComboBox.Text.Trim() == "" || qaimeAlisSatisComboBox.Text.Trim() == "" || productNameComboBox.Text.Trim() == "" || operationTypeComboBox.Text.Trim() == "" || productMiqdarTxt.Text.Trim() == "" || mehsulPriceTxt.Text.Trim() == "" || noteTxt.Text.Trim() == "")
                {
                    MessageBox.Show("Boş xana buraxmayın!");
                }
                else
                {
                    try
                    {
                        if (guzestTxt.Text == "")
                        {
                            guzestTxt.Text = "0";
                        }
                        if (bonusMiqdarTxt.Text == "")
                        {
                            bonusMiqdarTxt.Text = "0";
                        }
                        
                        float UmumiSay, BirGuzestMebleqi, CemGuzestsizQiymet, CemGuzestMebleqi, CemGuzestliQiymet, BirGuzestliQiymet, miqdar, bonus, qiymet, guzest ;
                        int operationtype;
                        
                        if (productNameComboBox.SelectedIndex == 0)
                        {
                            qiymet = 0;
                            miqdar = 0;
                        }
                        else
                        {
                            qiymet = (float.Parse(mehsulPriceTxt.Text));
                            miqdar = (float.Parse(productMiqdarTxt.Text));
                        }

                        if (operationTypeComboBox.SelectedIndex == 0)
                        {
                            operationtype = 0;
                            bonus = (float.Parse(bonusMiqdarTxt.Text));
                            guzest = (float.Parse(guzestTxt.Text));
                            UmumiSay = miqdar + bonus;
                            BirGuzestMebleqi = (Math.Abs(qiymet) * guzest) / 100;
                            CemGuzestsizQiymet = (miqdar * qiymet);
                            CemGuzestMebleqi = (BirGuzestMebleqi * Math.Abs(miqdar));
                            BirGuzestliQiymet = qiymet - BirGuzestMebleqi;
                            CemGuzestliQiymet = miqdar * BirGuzestliQiymet;
                        }
                        else
                        {
                            operationtype = 1;
                            miqdar = (0 - float.Parse(productMiqdarTxt.Text));
                            bonus = (0 - float.Parse(bonusMiqdarTxt.Text));
                            guzest = (float.Parse(guzestTxt.Text));
                            UmumiSay = miqdar + bonus;
                            BirGuzestMebleqi = (Math.Abs(qiymet) * guzest) / 100;
                            CemGuzestsizQiymet = (miqdar * qiymet);
                            CemGuzestMebleqi = (BirGuzestMebleqi * Math.Abs(miqdar));
                            BirGuzestliQiymet = qiymet - BirGuzestMebleqi;
                            CemGuzestliQiymet = miqdar * BirGuzestliQiymet;
                        }

                        
                        var QaimeID = (qaimeAlisSatisComboBox.SelectedItem as ComboboxItem).Value;
                        int alissatismehsulid = int.Parse(DGW.GetDataRow(DGW.FocusedRowHandle)[29].ToString());
                        var zavodid = (factorymarketComboBox.SelectedItem as ComboboxItem).Value;
                        string qeydt = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                        SQLiteCommand kommand = new SQLiteCommand();
                        kommand.Connection = baqlanti;
                        baqlanti.Open();
                        kommand.CommandText = "Update AlisSatisMehsulTable Set QaimeID=@QaimeID, SifarisciID= @SifarisciID,  OperationType=@OperationType, MehsulID=@MehsulID,  Miqdari=@Miqdari, Qiymet=@Qiymet, Guzest=@Guzest, BonusMehsulID=@BonusMehsulID, BonusMiqdar = @BonusMiqdar, UmumiSay=@UmumiSay, BirGuzestMebleqi=@BirGuzestMebleqi, CemGuzestMebleqi=@CemGuzestMebleqi, CemGuzestsizQiymet=@CemGuzestsizQiymet, BirGuzestliQiymet=@BirGuzestliQiymet, CemGuzestliQiymet=@CemGuzestliQiymet, OperationDate=@OperationDate, Qeyd=@Qeyd, EditInfo=@EditInfo Where AlisSatisMehsulID=@AlisSatisMehsulID";
                        kommand.Parameters.AddWithValue("@AlisSatisMehsulID", alissatismehsulid);
                        kommand.Parameters.AddWithValue("@QaimeID", QaimeID);
                        kommand.Parameters.AddWithValue("@SifarisciID", Convert.ToInt32(zavodid));
                        kommand.Parameters.AddWithValue("@OperationType", operationtype);
                        if (productNameComboBox.SelectedIndex == 0)
                        {
                            kommand.Parameters.AddWithValue("@MehsulID", null);
                            kommand.Parameters.AddWithValue("@Miqdari", null);
                        }
                        else
                        {
                            var mehsulid = (productNameComboBox.SelectedItem as ComboboxItem).Value;
                            kommand.Parameters.AddWithValue("@MehsulID", mehsulid);
                            kommand.Parameters.AddWithValue("@Miqdari", Math.Round(miqdar, 2));
                        }
                        kommand.Parameters.AddWithValue("@Qiymet", Math.Round(qiymet, 2));
                        if (bonusMehsulcomboBox.SelectedIndex == 0)
                        {
                            kommand.Parameters.AddWithValue("@BonusMehsulID", null);
                            kommand.Parameters.AddWithValue("@BonusMiqdar", null);
                        }
                        else
                        {
                            var mehsulidbonus = (bonusMehsulcomboBox.SelectedItem as ComboboxItem).Value;
                            kommand.Parameters.AddWithValue("@BonusMehsulID", mehsulidbonus);
                            kommand.Parameters.AddWithValue("@BonusMiqdar", Math.Round(bonus, 2));
                        }
                        if (guzestTxt.Text == "0")
                        {
                            kommand.Parameters.AddWithValue("@Guzest", null);
                        }
                        else
                        {
                            kommand.Parameters.AddWithValue("@Guzest", Math.Round(guzest, 2));
                        }
                        kommand.Parameters.AddWithValue("@UmumiSay", Math.Round(UmumiSay, 2));
                        kommand.Parameters.AddWithValue("@BirGuzestMebleqi", Math.Round(BirGuzestMebleqi, 2));
                        kommand.Parameters.AddWithValue("@CemGuzestMebleqi", Math.Round(CemGuzestMebleqi, 2));
                        kommand.Parameters.AddWithValue("@CemGuzestsizQiymet", Math.Round(CemGuzestsizQiymet, 2));
                        kommand.Parameters.AddWithValue("@BirGuzestliQiymet", Math.Round(BirGuzestliQiymet, 2));
                        kommand.Parameters.AddWithValue("@CemGuzestliQiymet", Math.Round(CemGuzestliQiymet, 2));
                        kommand.Parameters.AddWithValue("@OperationDate", qeydt);
                        kommand.Parameters.AddWithValue("@Qeyd", noteTxt.Text);
                        kommand.Parameters.AddWithValue("@EditInfo", 1);
                        kommand.ExecuteNonQuery();
                        baqlanti.Close();

                        string changetable = "Qaimə nömrəsi: " + qaimeAlisSatisComboBox.Text + " Müəssisə adı:" + factorymarketComboBox.Text + " ,Məhsulun adı:" + productNameComboBox.Text + " , Alış və ya geri qaytarma: " + operationTypeComboBox.Text + " ,Miqdarı:" + productMiqdarTxt.Text + " ,Alış qiyməti:" + mehsulPriceTxt.Text + " ,Güzəşt:" + guzestTxt.Text + " Faiz " + " ,Hədiyyə məhsulun adı:" + bonusMehsulcomboBox.Text + " , Hədiyyə məhsulun miqdarı:" + bonusMiqdarTxt.Text + " , Qeyd: " + noteTxt.Text + " ) dəyişdi";

                        baqlanti.Open();
                        kommand.CommandText = "Insert Into LogTable (IsciID,OperationDate,OperationType,CommentInfo) Values (@IsciID,@OperationDate,@OperationType,@CommentInfo)";
                        kommand.Parameters.AddWithValue("@IsciID", Convert.ToInt32(User.isciid));
                        kommand.Parameters.AddWithValue("@OperationDate", qeydt);
                        kommand.Parameters.AddWithValue("@OperationType", 1);
                        kommand.Parameters.AddWithValue("@CommentInfo", selectTable + changetable);
                        kommand.ExecuteNonQuery();
                        baqlanti.Close();
                        MessageBox.Show("Redaktə olundu");

                        addEditFLPanel.Visible = true;
                        addEditQeydGroupBox.Visible = false;
                        addEditGFLPanel.Visible = false;

                        listelecomboboxProduc();
                        listelecomboboxProducBonus();
                        listelecomboboxQaime();
                        listelecomboboxfactory();
                        silinen = false;
                        selectlistele();
                        factorymarketComboBox.Text = "";
                        qaimeAlisSatisComboBox.Text = "";
                        productNameComboBox.Text = "";
                        operationTypeComboBox.Text = "";
                        bonusMehsulcomboBox.Text = "";
                        productMiqdarTxt.Text = "";
                        mehsulPriceTxt.Text = "";
                        guzestTxt.Text = "";
                        productNameComboBox.Text = "";
                        bonusMiqdarTxt.Text = "";
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

        private void excellexportBtn_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(DGW.RowCount) == 0)
            {
                MessageBox.Show("Məlumat yoxdur!", "DİQQƏT!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            

        }

        private void showEditBtn_Click(object sender, EventArgs e)
        {
            editinsozu = " ASMT.EditInfo " + editedsql + " And ";
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
            {
                try
                {
                    silinen = true;
                    selectlistele();
                    DGW.Columns[28].Visible = true;
                    hideDeleteBtn.Visible = true;
                    showDeleteBtn.Visible = false;
                    commonFlowLayoutPanel.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void hideDeleteBtn_Click(object sender, EventArgs e)
        {
            DGW.Columns[28].Visible = false;
            hideDeleteBtn.Visible = false;
            showDeleteBtn.Visible = true;
            commonFlowLayoutPanel.Visible = true;
            silinen = false;
            selectlistele();
        }

       

        private void showDateBtn_Click(object sender, EventArgs e)
        {
            searchdate1 = search1DTPicker.Text;
            searchdate2 = search2DTPicker.Text;
            selectlistele();
        }

        
                private DataTable ReportListborc()
                {
                    DataTable data = new DataTable();
                    string qaimeadi = DGW.GetDataRow(DGW.FocusedRowHandle)[0].ToString();

                    // Qaime uzre  olan mehsullarin listi

                    baqlanti.Open();
                    SQLiteCommand kommand = new SQLiteCommand("Select AST.QaimeNomresi, AST.Tarix, SciT.AD as SifrisciAd, SciT.Temsilci, SciT.WeherUnvan, SciT.RayonUnvan, SciT.QesebeUnvan, SciT.Phone, IT.Ad as IsciAd, mt.Ad as MAd, mt.Nov as MNov, mt.OlcuVahidi as MOVahidi,  CAST ( CASE WHEN ASMT.OperationType = 0 THEN 'Alış' WHEN ASMT.OperationType = 1 THEN 'Geri qaytarma'  WHEN ASMT.OperationType = 2 THEN 'Satış' WHEN ASMT.OperationType = 3 THEN 'Geri qaytarma' END AS nvarchar(55)) as OperationType,  Miqdari, Qiymet, Guzest, mt1.Ad as BMAd, mt1.Nov as BMNov, mt1.OlcuVahidi as BMOVahidi, BonusMehsulID, BonusMiqdar, ((select ifnull(sum(Miqdari), 0) from AlisSatisMehsulTable where OperationType=0 and QaimeID =ASMT.QaimeID  And AlisSatisMehsulTable.DeleteInfo is not 2) - (select ifnull(sum(Miqdari), 0) from AlisSatisMehsulTable where OperationType=1 and QaimeID =ASMT.QaimeID And AlisSatisMehsulTable.DeleteInfo is not 2))as MiqdarCemQaime,  ((select ifnull(sum(BonusMiqdar), 0) from AlisSatisMehsulTable where OperationType=0 and QaimeID =ASMT.QaimeID  And AlisSatisMehsulTable.DeleteInfo is not 2) - (select ifnull(sum(BonusMiqdar), 0) from AlisSatisMehsulTable where OperationType=1 and QaimeID =ASMT.QaimeID And AlisSatisMehsulTable.DeleteInfo is not 2))as BonusMiqdarCemQaime, UmumiSay,  ((select ifnull(sum(UmumiSay), 0) from AlisSatisMehsulTable where OperationType=0 and QaimeID =ASMT.QaimeID  And AlisSatisMehsulTable.DeleteInfo is not 2 ) - (select ifnull(sum(UmumiSay), 0) from AlisSatisMehsulTable where OperationType=1 and QaimeID =ASMT.QaimeID And AlisSatisMehsulTable.DeleteInfo is not 2 ))as UmumiSayCemQaime, BirGuzestMebleqi, CemGuzestMebleqi, BirGuzestMebleqi, CemGuzestMebleqi,  ((select ifnull(sum(CemGuzestMebleqi), 0) from AlisSatisMehsulTable where OperationType=0 and QaimeID =ASMT.QaimeID  And AlisSatisMehsulTable.DeleteInfo is not 2 ) - (select ifnull(sum(CemGuzestMebleqi), 0) from AlisSatisMehsulTable where OperationType=1 and QaimeID =ASMT.QaimeID And AlisSatisMehsulTable.DeleteInfo is not 2 ))as CemGuzestMebleqiQaime,  CemGuzestsizQiymet,  ((select ifnull(sum(CemGuzestsizQiymet), 0) from AlisSatisMehsulTable where OperationType=0 and QaimeID =ASMT.QaimeID  And AlisSatisMehsulTable.DeleteInfo is not 2 ) - (select ifnull(sum(CemGuzestsizQiymet), 0) from AlisSatisMehsulTable where OperationType=1 and QaimeID =ASMT.QaimeID And AlisSatisMehsulTable.DeleteInfo is not 2 ))as CemGuzestsizQiymetQaime,  BirGuzestliQiymet, CemGuzestliQiymet,  ((select ifnull(sum(CemGuzestliQiymet), 0) from AlisSatisMehsulTable where OperationType=0 and QaimeID =ASMT.QaimeID  And AlisSatisMehsulTable.DeleteInfo is not 2 ) - (select ifnull(sum(CemGuzestliQiymet), 0) from AlisSatisMehsulTable where OperationType=1 and QaimeID =ASMT.QaimeID And AlisSatisMehsulTable.DeleteInfo is not 2 ))as CemGuzestliQiymetQaime,  ((select ifnull(sum(CemGuzestsizQiymet), 0) from AlisSatisMehsulTable where OperationType=0 and SifarisciID =SciT.SifarisciID And AlisSatisMehsulTable.DeleteInfo is not 2 ) - (select ifnull(sum(CemGuzestsizQiymet), 0) from AlisSatisMehsulTable where OperationType=1 and SifarisciID =SciT.SifarisciID And AlisSatisMehsulTable.DeleteInfo is not 2 ))as CemGuzestsizQiymetSifarisci,  ((select ifnull(sum(CemGuzestliQiymet), 0) from AlisSatisMehsulTable where OperationType=0 and SifarisciID =SciT.SifarisciID And AlisSatisMehsulTable.DeleteInfo is not 2 ) + (select ifnull(sum(CemGuzestliQiymet), 0) from AlisSatisMehsulTable where OperationType=1 and SifarisciID =SciT.SifarisciID And AlisSatisMehsulTable.DeleteInfo is not 2 ))as CemGuzestliQiymetSifarisci,  ((select ifnull(sum(AlinanVerilenPul), 0) from AlisSatisMehsulTable where AlisSatisMehsulTable.SifarisciID =SciT.SifarisciID And AlisSatisMehsulTable.DeleteInfo is not 2))as CemOdemeSifarisci,  ((select ifnull(sum(AlinanVerilenPul), 0) from AlisSatisMehsulTable where AlisSatisMehsulTable.SifarisciID =SciT.SifarisciID And AlisSatisMehsulTable.DeleteInfo is not 2) - (select ifnull(sum(CemGuzestliQiymet), 0) from AlisSatisMehsulTable where OperationType=0 and SifarisciID =SciT.SifarisciID  And AlisSatisMehsulTable.DeleteInfo is not 2 ) + (select ifnull(sum(CemGuzestliQiymet), 0) from AlisSatisMehsulTable where OperationType=1 and SifarisciID =SciT.SifarisciID And AlisSatisMehsulTable.DeleteInfo is not 2 )) as CemBorcSifarisci,  ((select ifnull(sum(AlinanVerilenPul), 0) from AlisSatisMehsulTable where AlisSatisMehsulTable.SifarisciID =SciT.SifarisciID And AlisSatisMehsulTable.DeleteInfo is not 2) - (select ifnull(sum(CemGuzestliQiymet), 0) from AlisSatisMehsulTable where OperationType=0 and SifarisciID =SciT.SifarisciID  And AlisSatisMehsulTable.DeleteInfo is not 2 ) + (select ifnull(sum(CemGuzestliQiymet), 0) from AlisSatisMehsulTable where OperationType=1 and SifarisciID =SciT.SifarisciID And AlisSatisMehsulTable.DeleteInfo is not 2 )+ (select ifnull(sum(CemGuzestliQiymet), 0) from AlisSatisMehsulTable where OperationType=0 and QaimeID =ASMT.QaimeID  And AlisSatisMehsulTable.DeleteInfo is not 2 ) - (select ifnull(sum(CemGuzestliQiymet), 0) from AlisSatisMehsulTable where OperationType=1 and QaimeID =ASMT.QaimeID And AlisSatisMehsulTable.DeleteInfo is not 2 )) as CemBorcQaimedenEvvel,  ASMT.AlisSatisMehsulID, AST.QaimeID, ASMT.OperationType, mt.MehsulID, SciT.SifarisciID  from AlisSatisMehsulTable ASMT  left join MehsulTable mt on mt.MehsulID=asmt.MehsulID  left join MehsulTable mt1 on mt1.MehsulID=asmt.BonusMehsulID  left join QaimeTable AST on ASMT.QaimeID = AST.QaimeID  join SifarisciTable SciT on ASMT.SifarisciID = SciT.SifarisciID  left join KategoriyaTable KT on SciT.KategoriyID=KT.KategoriyID  join IsciTable IT on AST.IsciID=IT.IsciID  where Qaimenomresi=@QaimeSoz And ASMT.DeleteInfo is not 2  order by mt.Ad Asc", baqlanti);
                    kommand.Parameters.AddWithValue("@QaimeSoz", qaimeadi);
                    SQLiteDataAdapter adtr = new SQLiteDataAdapter(kommand);
                    adtr.Fill(data);
            baqlanti.Close();

            return data;
                }

        private void ReportEditBtn_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(DGW.RowCount) == 0)
            {
                MessageBox.Show("Məlumat yoxdur!", "DİQQƏT!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    XtraReport report = new XtraReport();
                    report.LoadLayout(Application.StartupPath + @"\report\XtraReportAlis.repx");
                    report.DataSource = ReportListborc();

                    // desineri acmaq ucun
                    report.ShowDesigner();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
           
        }

        private void ReportShowBtn_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(DGW.RowCount) == 0)
            {
                MessageBox.Show("Məlumat yoxdur!", "DİQQƏT!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    string qaimeadi = DGW.GetDataRow(DGW.FocusedRowHandle)[0].ToString();
                    if (qaimeadi == "")
                    {
                        MessageBox.Show("Qaiməni daxil edin!", "DİQQƏT!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    var reportlis = ReportListborc();
                    if (reportlis.Rows.Count == 0)
                    {
                        MessageBox.Show("Bu qaimə üzrə məlumat yoxdur!", "DİQQƏT!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    XtraReport report = new XtraReport();
                    report.LoadLayout(Application.StartupPath + @"\report\XtraReportAlis.repx");
                    report.DataSource = ReportListborc();
                    report.ShowPreview();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void purchaseForm_FormClosed(object sender, FormClosedEventArgs e)
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

        // ededin yazi formasinda yazilmasi ucun baslanqic
        public enum NumberName : long
        {
            Sıfır, Bir, İki, Üç, Dörd, Beş, Altı, Yeddi, Səkkiz, Doqquz, On, Iyirmi = 20, Otuz = 30, Qırx = 40, Əlli = 50, Altmış = 60, Yetmiş = 70, Səksən = 80, Doxsan = 90, Yüz = 100, Min = 1000, Milyon = Min * Min, Milyard = Milyon * Min, Trilyon = Milyard * Min, Trilyard = Trilyon * Min, Kvartrilyon = Trilyard * Min
        }

        //TODO support floating numbers
        //TODO also write iterative solution, recursive call will cause StackOverFlow exception with too big numbers ( even that numbers aren't named)
        //TODO also write vise versa ( str -> long)
        //TODO support negative numbers
        // O(Log(N))
        private static StringBuilder NumberToWordsRecursive(long number, int rank, StringBuilder tail)
        {
            if (number == 0)
                if (rank == 0) //number is just 0
                    return new StringBuilder(((NumberName)number).ToString());
                else //0 is one of the digits of number. just ignore
                    return tail;
            if (rank > 0 && rank % 3 == 0 && number % 1000 > 0)
                // 3rd stages have spacial names ( min, miliyon, miliyard,.. )
                tail.Insert(0, (NumberName)Math.Pow((int)NumberName.Min, rank / 3) + " ");

            if ( /*(rank - 2) >= 0 &&*/ (rank - 2) % 3 == 0 && number % 10 > 0)
                tail.Insert(0, NumberName.Yüz + " ");

            if (number % 10 != 0 && !(number % 10 == 1 && rank != 0 && ((rank % 3 == 2) || (rank == 3 && number < 10))))
                tail.Insert(0, ((NumberName)(int)(Math.Pow(10, rank % 3 % 2) * (number % 10))) + " ");
            //rank % 3 % 2 ignores named stages and 100s, just evaluate 1-9 or 10-90

            return NumberToWordsRecursive(number / 10, ++rank, tail);
        }

        public static string NumberToWord(long number)
        {
            return NumberToWordsRecursive(number, 0, new StringBuilder()).ToString().ToLower();
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
        // ededin yazi formasinda yazilmasi ucun son
    }

}
