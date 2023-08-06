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

namespace WindowsFormsApp2
{
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }


        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Mylogin;Integrated Security=True");
        
        private void Login_Form_Load(object sender, EventArgs e)
        {

        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            String username, user_password;

            username = txt_Name.Text;
            user_password = txt_Password.Text;

            try
            {
                String query = "SELECT * FROM LoginData WHERE username = '" + txt_Name.Text + "' AND password = '" + txt_Password.Text + "'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);

                DataTable dataTable = new DataTable();

                sqlDataAdapter.Fill(dataTable);

                if(dataTable.Rows.Count > 0)
                {
                    username = txt_Name.Text;
                    user_password = txt_Password.Text;

                    //page be needed to load next

                    MenuForm page2 = new MenuForm();
                    page2.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Invalid Login Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_Name.Clear();
                    txt_Password.Clear();

                    //to focus username
                    txt_Name.Focus();


                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                conn.Close();
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txt_Name.Clear();
            txt_Password.Clear();

            txt_Name.Focus();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Do you want to exit" , "Exit" , MessageBoxButtons.YesNo , MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }
        }
    }
}
