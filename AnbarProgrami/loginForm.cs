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
using System.Collections.Specialized;
using System.Configuration;
using System.Data.SQLite;
using System.Security.Cryptography;

namespace AnbarProgrami
{
    public partial class loginForm : Form
    {
        SQLiteConnection baqlanti = new SQLiteConnection();
        public loginForm()
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
        private void loginBtn_Click(object sender, EventArgs e)
        {
            {
                if (logintxt.Text == "" || passwordxt.Text == "")
                {
                    errMsg.Visible = true;
                    errMsg.Text = "Boş sahə buraxmayın!";
                }
                else
                {
                    try
                    {
                        
                     baqlanti.ConnectionString = (connectionString);
                        baqlanti.Open();

                        string query = "select * from IsciTable join IstifadeciTable on IsciTable.IsciID=IstifadeciTable.IsciID join RuleTable on IstifadeciTable.RuleID=RuleTable.RuleID Where Login=@Login and UPassword=@UPassword and IstifadeciTable.DeleteInfo is null";

                        string UsernameLog = logintxt.Text;
                        string PasswordLog = GetMD5(passwordxt.Text);
                        SQLiteParameter prm1 = new SQLiteParameter("Login", UsernameLog);
                        SQLiteParameter prm2 = new SQLiteParameter("UPassword", PasswordLog);
                        SQLiteCommand kommand = new SQLiteCommand(query, baqlanti);
                        kommand.Parameters.Add(prm1);
                        kommand.Parameters.Add(prm2);
                        DataTable dt = new DataTable();
                        SQLiteDataAdapter da = new SQLiteDataAdapter(kommand);
                        da.Fill(dt);
                        SQLiteDataReader reader;
                        reader = kommand.ExecuteReader();
                        int count = 0;
                        while (reader.Read())
                        {
                            User.isciid = reader["IsciID"].ToString();
                            User.login = reader["Login"].ToString();
                            User.ruleid = reader["RuleID"].ToString();
                            User.ruletype = reader["RuleType"].ToString();
                            User.name = reader["Ad"].ToString();
                            count = count + 1;
                        }

                        if (count == 1)
                        {

                            if (User.ruletype == "Admin")
                            {
                                this.Hide();
                                homeForm homeform = new homeForm();
                                homeform.ShowDialog();
                                this.Close();
                            }
                            else
                            {
                                this.Hide();
                                homeForm homeform = new homeForm();
                                homeform.ShowDialog();
                                this.Close();
                            }
                        }
                        else if (count > 0)
                        {
                            errMsg.Text = "Belə istifadəçi artıq var";
                        }
                        else
                        {
                            for (int i = 0; i < Controls.Count; i++)
                            {
                                if (Controls[i] is TextBox)
                                {
                                    Controls[i].Text = "";
                                }
                            }
                            errMsg.Visible = true;
                            errMsg.Text = "İstifadəçi adı vəya şifrə yanlışdır!";
                        }

                        baqlanti.Close();
                    }
                    catch (Exception xeta)
                    {
                        baqlanti.Close();
                        MessageBox.Show(xeta.Message);
                    }

                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            Application.Exit();
        }
    }
}
