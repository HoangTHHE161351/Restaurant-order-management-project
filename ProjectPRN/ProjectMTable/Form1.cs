using ProjectMTable.Models;

namespace ProjectMTable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user= textBox1.Text;
            string pass = textBox2.Text;
            using (var context = new MTableContext())
            {
                Account ac = context.Accounts.Where(x => x.Username == user && x.Password == pass).FirstOrDefault();
                if(ac == null)
                {
                    MessageBox.Show("Dang nhap that bai");
                }
                else
                {
                    if (ac.Status== false)
                    {
                        MessageBox.Show("Tai khoan da bi khoa");
                    }
                    else
                    {
                        if (ac.Role == 0)
                        {
                            AdminPage form = new AdminPage();
                            form.Show();
                            this.Hide();
                        }
                        else
                        {
                            UserPage form = new UserPage(ac.Id);
                            form.Show();
                            this.Hide();
                        }
                    }
                }

            }
        }
    }
}