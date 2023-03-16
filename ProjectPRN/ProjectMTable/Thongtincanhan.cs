using ProjectMTable.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectMTable
{
    public partial class Thongtincanhan : Form
    {
        public int idacc;
        public Thongtincanhan(int id)
        {
            idacc = id;
            InitializeComponent();
        }

        private void Thongtincanhan_Load(object sender, EventArgs e)
        {
            using (var context = new MTableContext())
            {
                Account acc = context.Accounts.FirstOrDefault(x => x.Id == idacc);
                Information infor = context.Information.FirstOrDefault(x => x.Id == idacc);

                textBox1.Text = infor.FullName;
                textBox4.Text = infor.Phone;
                textBox3.Text = infor.Address;
                textBox2.Text = infor.Email;

                textBox5.Text = acc.Username;
                textBox6.Text = acc.Password;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new MTableContext())
            {
                Account acc = context.Accounts.FirstOrDefault(x => x.Id == idacc);
                Information infor = context.Information.FirstOrDefault(x => x.Id == idacc);

                 infor.FullName = textBox1.Text;
                 infor.Email= textBox2.Text;
                 infor.Address= textBox3.Text;
                 infor.Phone= textBox4.Text;

                 acc.Username= textBox5.Text;
                acc.Password= textBox6.Text;
                context.Accounts.Update(acc);
                context.Information.Update(infor);
                context.SaveChanges();
                MessageBox.Show("Cap nhat thong tin thanh cong");
            }
        }
    }
}
