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
    public partial class ZOBorc : Form
    {
        SQLiteConnection baqlanti = new SQLiteConnection();
        public ZOBorc()
        {
            InitializeComponent();
        }
        string connectionString = ConfigurationManager.ConnectionStrings["CharityManagement"].ConnectionString;
    
        string query;
        public void selectlistele3()
        {
            try
            {
                    baqlanti.ConnectionString = (connectionString);
                    DataTable table = new DataTable();
                    table.Clear();
                        SQLiteDataAdapter adtr = new SQLiteDataAdapter(query, baqlanti);
                        adtr.Fill(table);
                    DGV1.DataSource = table;
                DGW1.Columns[0].Caption = "Müəssisə adı";
                DGW1.Columns[1].Caption = "Alınan məhsulun məbləği";
                DGW1.Columns[2].Caption = "Ödənilən məbləğ";
                DGW1.Columns[3].Caption = "Qalan məbləğ";
                DGW1.Columns[4].Visible = false;
                baqlanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ZOBorc_Load(object sender, EventArgs e)
        {
            this.Text = " Zavodlarla hesabat";
            WindowState = FormWindowState.Maximized;
            query = "Select SciT.AD, ifnull(sum (AlisSatisMehsulTable.CemGuzestliQiymet), 0) as Borc, ifnull(sum (AlisSatisMehsulTable.AlinanVerilenPul), 0) as OdenenPul, (ifnull(sum (AlisSatisMehsulTable.CemGuzestliQiymet), 0) - ifnull(sum (AlisSatisMehsulTable.AlinanVerilenPul), 0)) As QaliqMebleq, SciT.SifarisciID from AlisSatisMehsulTable join SifarisciTable SciT on AlisSatisMehsulTable.SifarisciID = SciT.SifarisciID where  SciT.SifarisciType=0 And AlisSatisMehsulTable.DeleteInfo is not 2 group by AlisSatisMehsulTable.SifarisciID order by AlisSatisMehsulID desc";
            

            DGV1.Visible = true;
            selectlistele3();
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
