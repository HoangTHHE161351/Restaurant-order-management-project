using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public partial class ADatBan : Form
    {
        public ADatBan()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            using (var context = new MTableContext())
            {
               // dateTimePicker3.MinDate = DateTime.Now.AddDays(-1); 
                List<Order> list = context.Orders.OrderByDescending(x=>x.DateOrder).ToList();
                dataGridView1.Rows.Clear();
                foreach(Order item in list)
                {
                    Information inf = context.Information.FirstOrDefault(x => x.Id == item.UserOrder);
                    string status;
                    if (item.Status == 1)
                        status = "Da gui yeu cau";
                    else if (item.Status == 2)
                        status = "Thanh cong";
                    else
                        status = "That bai";
                    Models.Table t1 = context.Tables.FirstOrDefault(x => x.Id == item.TableId);
                    dataGridView1.Rows.Add(item.Id, inf.FullName,t1.Name, item.TimeOrder, item.DateOrder.Value.ToString("dd-MM-yyyy"), item.NoteUser, item.DateCf, status, item.NoteEmployee);
                }
                List<string> listtime = new List<string> { "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00" };
                comboBox3.DisplayMember = "string";
                comboBox3.ValueMember = "string";
                comboBox3.DataSource = listtime;

                List<Models.Table> listT = context.Tables.ToList();
                comboBox2.DisplayMember = "Name";
                comboBox2.ValueMember = "Id";
                comboBox2.DataSource=listT;

           

                List<Information> listI = context.Information.Where(x=>x.Id!=1).ToList();
                comboBox1.DisplayMember = "FullName";
                comboBox1.ValueMember = "Id";
                comboBox1.DataSource = listI;
                textBox2.Text = string.Empty;
                textBox1.Text = string.Empty;
                textBox3.Text = string.Empty;
                dateTimePicker3.Value = DateTime.Now;

            }
        }
        private void ADatBan_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime to = dateTimePicker2.Value;
            DateTime from = dateTimePicker1.Value;
            using (var context = new MTableContext())
            {
                List<Order> list = context.Orders.Where(x=>x.DateOrder>= from && x.DateOrder<= to).OrderByDescending(x => x.DateOrder).ToList();
                dataGridView1.Rows.Clear();
                foreach (Order item in list)
                {
                    Information inf = context.Information.FirstOrDefault(x => x.Id == item.UserOrder);
                    string status;
                    if (item.Status == 1)
                        status = "Da gui yeu cau";
                    else if (item.Status == 2)
                        status = "Thanh cong";
                    else
                        status = "That bai";
                    Models.Table t1 = context.Tables.FirstOrDefault(x => x.Id == item.TableId);
                    dataGridView1.Rows.Add(item.Id, inf.FullName, t1.Name, item.TimeOrder, item.DateOrder.Value.ToString("dd-MM-yyyy"), item.NoteUser, item.DateCf, status, item.NoteEmployee);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString());
            using (var context = new MTableContext())
            {
                Order ord = context.Orders.FirstOrDefault(x => x.Id == id);
                textBox1.Text = ord.Id.ToString();
                string nameuser = context.Information.FirstOrDefault(x => x.Id == ord.UserOrder).FullName;
                comboBox1.SelectedIndex= comboBox1.FindStringExact(nameuser);

                Models.Table t1 = context.Tables.FirstOrDefault(x => x.Id == ord.TableId);
                comboBox2.SelectedIndex = comboBox2.FindStringExact(t1.Name);

                dateTimePicker3.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells["Column4"].Value.ToString());

                List<Order> list = context.Orders.Where(x => x.DateOrder == ord.DateOrder && x.TableId == t1.Id).ToList();
                list.Remove(ord);
                List<string> listtime = new List<string> { "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00" };
                foreach (Order item in list)
                {
                    string s = listtime.FirstOrDefault(x => x == item.TimeOrder);
                    if (s != null)
                    {
                        listtime.Remove(s);
                    }
                }
                //chay a xem voi lai giup a nha

                comboBox3.DisplayMember = "string";
                comboBox3.ValueMember = "string";
                comboBox3.DataSource = listtime;

                comboBox3.SelectedIndex= comboBox3.FindStringExact(ord.TimeOrder);
                textBox2.Text = ord.NoteUser;

            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idban = int.Parse(comboBox2.SelectedValue.ToString());
            DateTime dt = dateTimePicker3.Value;
            using (var context = new MTableContext())
            {
                List<Order> list = context.Orders.Where(x => x.DateOrder == dt && x.TableId == idban && x.Status != 3).ToList();
                List<string> listtime = new List<string> { "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00" };
                foreach (Order item in list)
                {
                    string s = listtime.FirstOrDefault(x => x == item.TimeOrder);
                    if (s != null)
                    {
                        listtime.Remove(s);
                    }
                }
                comboBox3.DisplayMember = "string";
                comboBox3.ValueMember = "string";
                comboBox3.DataSource = listtime;

            
            }
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            int idban = int.Parse(comboBox2.SelectedValue.ToString());
            DateTime dt = dateTimePicker3.Value;
            using (var context = new MTableContext())
            {
                List<Order> list = context.Orders.Where(x => x.DateOrder == dt && x.TableId == idban && x.Status != 3).ToList();
                List<string> listtime = new List<string> { "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00" };
                foreach (Order item in list)
                {
                    string s = listtime.FirstOrDefault(x => x == item.TimeOrder);
                    if (s != null)
                    {
                        listtime.Remove(s);
                    }
                }
                comboBox3.DisplayMember = "string";
                comboBox3.ValueMember = "string";
                comboBox3.DataSource = listtime;


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
               int id = int.Parse(textBox1.Text);
               using(var context = new MTableContext())
                {
                    Order or = context.Orders.FirstOrDefault(x => x.Id == id);
                    or.Status = 2;
                    or.DateCf = DateTime.Now;
                    or.NoteEmployee = textBox3.Text;
                    if (textBox3.Text.Trim()== "")
                    {
                        textBox3.Focus();

                    }
                    else
                    {
                        context.Orders.Update(or);
                        MessageBox.Show("Da xac nhan yeu cau dat ban");
                        context.SaveChanges();
                        LoadData();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ban dang lam sai thao tac!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox1.Text);
                using (var context = new MTableContext())
                {
                    Order or = context.Orders.FirstOrDefault(x => x.Id == id);
                    or.Status = 3;
                    or.DateCf = DateTime.Now;
                    or.NoteEmployee = textBox3.Text;
                    if (textBox3.Text.Trim() == "")
                    {
                        textBox3.Focus();

                    }
                    else
                    {
                        context.Orders.Update(or);
                        MessageBox.Show("Da huy yeu cau dat ban");
                        context.SaveChanges();
                        LoadData();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ban dang lam sai thao tac!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dateTimePicker3.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Cap nhat thoi gian dat ban sai");
            }
            else
            {
                using (var context = new MTableContext())
                {
                    try
                    {
                        int id = int.Parse(textBox1.Text);
                        Order or = context.Orders.FirstOrDefault(x => x.Id == id);
                        if (or.Status == 1)
                        {
                            or.TableId = int.Parse(comboBox2.SelectedValue.ToString());
                            or.DateOrder = dateTimePicker3.Value;
                            or.TimeOrder = comboBox3.SelectedValue.ToString();
                            context.Orders.Update(or);
                            context.SaveChanges();

                            MessageBox.Show("Cap nhat thanh cong");
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Ban khong duoc cap nhat");
                        }


                    }
                    catch
                    {
                        MessageBox.Show("Ban dang lam sai thao tac!");
                    }
                }
            }
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(dateTimePicker3.Value.Date< DateTime.Now.Date)
            {
                MessageBox.Show("Dat ban sai ngay");
            }
            else
            {
                using (var context = new MTableContext())
                {
                    try
                    {

                        Order or = new Order();

                        or.TableId = int.Parse(comboBox2.SelectedValue.ToString());
                        or.DateOrder = dateTimePicker3.Value;
                        or.TimeOrder = comboBox3.SelectedValue.ToString();
                        or.UserOrder = int.Parse(comboBox1.SelectedValue.ToString());
                        or.Status = 1;
                        or.NoteUser = textBox2.Text;
                        context.Orders.Add(or);
                        context.SaveChanges();
                        MessageBox.Show("Tao moi thanh cong");
                        LoadData();

                    }
                    catch
                    {
                        MessageBox.Show("Ban dang lam sai thao tac!");
                    }
                }
            }
           
        }
    }
}
