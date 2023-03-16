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

namespace ProjectMTable
{
    public partial class ATaiKhoan : Form
    {
        public ATaiKhoan()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            using (var context = new MTableContext())
            {
                dataGridView1.Rows.Clear();
                List<Information> list = context.Information.ToList();
                foreach (Information item in list)
                {
                    Account ac = context.Accounts.FirstOrDefault(x => x.Id == item.Id);
                    if (ac.Role != 0)
                    {
                        dataGridView1.Rows.Add(item.Id, ac.Username, item.FullName, item.Email, item.Address, item.Phone, "Reset Pass", ac.Status == true ? "Dang mo" : "Dang khoa");
                    }

                }
            }
        }
        private void ATaiKhoan_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column8")
            {
                int id= int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString());
                using (var context = new MTableContext())
                {
                    Account ac = context.Accounts.FirstOrDefault(x => x.Id == id);
                    ac.Password = "123";
                    context.Accounts.Update(ac);
                    context.SaveChanges();
                    MessageBox.Show("Reset thanh cong mat khau thanh '123' !");
                }
            }
            else if(dataGridView1.Columns[e.ColumnIndex].Name == "Column9")
            {
                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString());
                using (var context = new MTableContext())
                {
                    Account ac = context.Accounts.FirstOrDefault(x => x.Id == id);
                    if (ac.Status == true)
                    {
                        ac.Status = false;
                        MessageBox.Show("Tai khoan da khoa");
                    }
                    else
                    {
                        ac.Status = true;
                        MessageBox.Show("Tai khoan da mo");
                    }
                    context.Accounts.Update(ac);
                    context.SaveChanges();
                }
            }
            else
            {
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Column4"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["Column5"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["Column6"].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["Column7"].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
            }
            LoadData();
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox6.Text);
                using (var context = new MTableContext())
                {
                    Information if1 = context.Information.FirstOrDefault(x => x.Id == id);
                    if1.FullName = textBox2.Text;
                    if1.Email = textBox3.Text;
                    if1.Phone = textBox5.Text;
                    if1.Address = textBox4.Text;
                    context.Information.Update(if1);
                    context.SaveChanges();
                    MessageBox.Show("Cap nhat thanh cong tai khoan");
                    LoadData();
                }
            }
            catch
            {
                MessageBox.Show("Ban dang thuc hien sai tao tac!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var context = new MTableContext())
            {
                List<Account> list = context.Accounts.Where(x => x.Username == textBox1.Text).ToList();
                if(list.Count > 0)
                {
                    MessageBox.Show("Tai khoan dang nhap bi trung");
                }
                else
                {
                    Account ac = new Account();
                    ac.Username = textBox1.Text;
                    ac.Password = "123";
                    ac.Role = 1;
                    ac.Status = true;
                    context.Accounts.Add(ac);
                    context.SaveChanges();

                    Information if1 = new Information();
                    if1.Id = ac.Id;
                    if1.FullName = textBox2.Text;
                    if1.Email = textBox3.Text;
                    if1.Phone = textBox5.Text;
                    if1.Address = textBox4.Text;
                    context.Information.Add(if1);
                    context.SaveChanges();
                    MessageBox.Show("Tao moi tai khoan thanh cong");
                    LoadData();
                }
               
            }
        }
    }
}
