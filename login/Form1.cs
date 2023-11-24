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

namespace login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-54ATNKA\SQLEXPRESS;Initial Catalog=Youtube;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           
                string username, userpassword;
                username = btnText.Text;
                userpassword = btntextpass.Text;

                try
                {
                    string querry = "SELECT * FROM Login_newx where username='" + btnText.Text + "' And password='" + btntextpass.Text + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(querry, conn);
                    DataTable dtable = new DataTable();
                    sda.Fill(dtable);
                    if (dtable.Rows.Count > 0)
                    {
                        username = btnText.Text;
                        userpassword = btntextpass.Text;
                        Menuform form2 = new Menuform();
                        form2.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid login details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnText.Clear();
                        btntextpass.Clear();
                        btnText.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("Error");

                }
                finally
                { conn.Close(); }
            }

        private void btnClear_Click(object sender, EventArgs e)
        {
               btnText.Clear();
                        btntextpass.Clear();
                        btnText.Focus();
        }
    }
    }

