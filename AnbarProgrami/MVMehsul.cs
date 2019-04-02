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
using DevExpress.XtraReports.UI;

namespace AnbarProgrami
{
    public partial class MVMehsul : Form
    {
        SQLiteConnection baqlanti = new SQLiteConnection();
        public MVMehsul()
        {
            InitializeComponent();
        }
        string connectionString = ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString;
  
        string query;

        public void selectlistele()
        {
            try
            {
                    baqlanti.ConnectionString = (connectionString);
                    DataTable table = new DataTable();
                    table.Clear();
                        SQLiteDataAdapter adtr = new SQLiteDataAdapter(query, baqlanti);
                        adtr.Fill(table);
                    DGV1.DataSource = table;
                        DGW1.Columns[0].Caption = "Müəssə adı";
                        DGW1.Columns[1].Caption = "Məhsul adı";
                        DGW1.Columns[2].Caption = "Məhsulun növü";
                        DGW1.Columns[3].Caption = "Ölçü vahidi";
                        DGW1.Columns[4].Caption = "Miqdarı";
                        DGW1.Columns[5].Caption = "Güzəştsiz qiymət";
                        DGW1.Columns[6].Caption = "Güzəştli qiymət";
                        DGW1.Columns[7].Visible = false;
                        DGW1.Columns[8].Visible = false;
                        DGW1.Columns[9].Visible = false;
                baqlanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MVMehsul_Load(object sender, EventArgs e)
        {
            this.Text = " Marketlərə verilən məhsullar";
            WindowState = FormWindowState.Maximized;
            query = "select SciT.AD, mt.AD , mt.Nov, mt.OlcuVahidi, ((select ifnull(sum(Miqdari), 0) from AlisSatisMehsulTable where OperationType=2 and MehsulID =asmt.MehsulID And AlisSatisMehsulTable.DeleteInfo is not 2)) as Miqdar, ((select ifnull(sum(CemGuzestsizQiymet), 0) from AlisSatisMehsulTable where OperationType=2 and MehsulID =asmt.MehsulID And AlisSatisMehsulTable.DeleteInfo is not 2)) as CemGuzestsizQiymet, ((select ifnull(sum(CemGuzestliQiymet), 0) from AlisSatisMehsulTable where OperationType=2 and MehsulID =asmt.MehsulID And AlisSatisMehsulTable.DeleteInfo is not 2)) as CemGuzestliQiymet, asmt.MehsulID, OperationType, SciT.SifarisciID from AlisSatisMehsulTable asmt join MehsulTable mt on asmt.MehsulID=mt.MehsulID join SifarisciTable SciT on asmt.SifarisciID = SciT.SifarisciID where asmt.OperationType=2 And asmt.DeleteInfo is not 2 group by SciT.AD, mt.AD , mt.Nov, mt.OlcuVahidi";

           

            DGV1.Visible = true;
            selectlistele();
        }

        private void excellexportBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Excel Files(Excel 97-2003 Workbook)|*.xlsx";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    DevExpress.XtraGrid.Views.Grid.GridView View = DGV1.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
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
}
