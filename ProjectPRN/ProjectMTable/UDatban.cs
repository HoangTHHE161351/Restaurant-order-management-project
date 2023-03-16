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
    public partial class UDatban : Form
    {
        public int idacc;
        public UDatban(int id)
        {
            idacc = id;
            InitializeComponent();
        }

        private void UDatban_Load(object sender, EventArgs e)
        {
            
            using (var context = new MTableContext())
            {

                List<string> listtime = new List<string> { "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00" };
                comboBox2.DisplayMember = "string";
                comboBox2.ValueMember = "string";
                comboBox2.DataSource = listtime;


                List<Table> list = context.Tables.ToList();
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";
                comboBox1.DataSource = list;

                List<Order> listo = context.Orders.Where(x => x.UserOrder == idacc).OrderByDescending(x=>x.Id).ToList();
                dataGridView1.Rows.Clear();
                foreach(Order item in listo)
                {
                    Table t = context.Tables.FirstOrDefault(x => x.Id == item.TableId);
                    string status;
                    if (item.Status == 1)
                        status = "Da gui yeu cau";
                    else if (item.Status == 2)
                        status = "Thanh cong";
                    else
                        status = "That bai";
                    dataGridView1.Rows.Add(item.Id,item.TimeOrder,item.DateOrder.Value.ToString("dd-MM-yyyy"),item.NoteUser,item.EmployeeCf,item.DateCf,t.Name,item.NoteEmployee,status,"Xoa");
                }
                
            }
        }
        public void LoadTable()
        {
            DateTime order = dateTimePicker1.Value;
            int table = int.Parse(comboBox1.SelectedValue.ToString());
            using (var context = new MTableContext())
            {
                List<Order> list = context.Orders.Where(x => x.DateOrder == order && x.TableId == table && x.Status!= 3).ToList();
                List<string> listtime = new List<string> { "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00" };
                foreach (Order item in list)
                {
                    string s = listtime.FirstOrDefault(x => x == item.TimeOrder);
                    if (s != null)
                    {
                        listtime.Remove(s);
                    }
                }
                comboBox2.DisplayMember = "string";
                comboBox2.ValueMember = "string";
                comboBox2.DataSource = listtime;

                List<Order> listo = context.Orders.Where(x => x.UserOrder == idacc).OrderByDescending(x => x.DateOrder).ThenBy(x=>x.Id).ToList();
                dataGridView1.Rows.Clear();
                foreach (Order item in listo)
                {
                    Table t = context.Tables.FirstOrDefault(x => x.Id == item.TableId);
                    string status;
                    if (item.Status == 1)
                        status = "Da gui yeu cau";
                    else if (item.Status == 2)
                        status = "Thanh cong";
                    else
                        status = "That bai";
                    dataGridView1.Rows.Add(item.Id, item.TimeOrder, item.DateOrder.Value.ToString("dd-MM-yyyy"), item.NoteUser, item.EmployeeCf, item.DateCf, t.Name, item.NoteEmployee, status, "Xoa");
                }
            }
        
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoadTable();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTable();
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Dat ban sai ngay");
            }
            else
            {
                using (var context = new MTableContext())
                {
                    Order or = new Order();
                    or.UserOrder = idacc;
                    or.TimeOrder = comboBox2.SelectedValue.ToString();
                    or.DateOrder = dateTimePicker1.Value;
                    or.NoteUser = textBox1.Text;
                    or.Status = 1;
                    or.TableId = int.Parse(comboBox1.SelectedValue.ToString());
                    context.Orders.Add(or);
                    context.SaveChanges();
                    MessageBox.Show("Ban da dat ban thanh cong!");
                    LoadTable();
                }
            }
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column10")
            {
              
                using (var context = new MTableContext())
                {
                    Order o = context.Orders.FirstOrDefault(x => x.Id == int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString()));
                    if(o.DateOrder.Value.Date < DateTime.Now.Date)
                    {
                        MessageBox.Show("Khong xoa duoc lich dat ban da dat truoc hom nay");
                    }
                    else
                    {
                        context.Orders.Remove(o);
                        context.SaveChanges();
                        MessageBox.Show("Xoa lich thanh cong");
                        LoadTable();
                    }

                }
            }
        }
    }
}
