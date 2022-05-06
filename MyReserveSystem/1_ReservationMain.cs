using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyReserveSystem
{
    public partial class ReservationMain : Form
    {
        public ReservationMain()
        {
            InitializeComponent();
        }
        MedicalEntities dbContex = new MedicalEntities();

        private void ReservationMain_Load(object sender, EventArgs e)
        {
            var s = from dp in dbContex.Departments
                    select dp.DeptName;
            this.comboBox1.DataSource = s.ToList();    //TODO 可能會改掉或刪掉

            //===============
           Button[] btn = { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12 };
            //button放入陣列中，物件名要是Button才可使用button屬性
            //btn[0] = button1;
            //再把他們加入EventHandler中
            for (int i = 0; i < btn.Length; i++)
            {
                btn[i].Click += new EventHandler(mybtn_Click);
            }

        }
       
        private void mybtn_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            t_2.label9.Text = b.Text;

        }
        //List<object> btnList = new List<object>();   //把btn加入list方便管理
        //private void BtnAddList()  //把btn加入list方便管理
        //{
        //    btnList.Add(this.button1);
        //TODO 把每個button分配datetime Hours
        //}

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var q2 = from n in dbContex.Doctors
                     where n.DeptID == this.comboBox1.SelectedIndex + 1
                     select n.DoctorName;
            this.comboBox2.DataSource = q2.ToList();
        }
        TreatmentItem t_2 = new TreatmentItem();
        private void button13_Click(object sender, EventArgs e)
        {
            t_2.label7.Text = this.comboBox2.SelectedItem.ToString();   //Modifiers設為public
            t_2.label8.Text = this.monthCalendar1.SelectionStart.ToString("yyyy/MM/dd");
            t_2.label12.Text = this.comboBox1.SelectedItem.ToString();
            //t.label9.Text = button1.Text.Substring(0, 2);
            //t_2.label11.Text =monthCalendar1.SelectionStart.ToString("yyyy/MM/dd");
            if (t_2.label9.Text == "")
            {
                MessageBox.Show("請選取時間");
            }
            else
            {
                t_2.FormClosing += T_FormClosing;
                t_2.Show();
                //表單2_關閉會發生例外，所以要將表單隱藏
                //https://social.msdn.microsoft.com/Forums/zh-TW/87104588-1ed5-4d4f-93bd-a2a0c0732a32/22914203093529927770?forum=233
                //https://dotblogs.com.tw/v6610688/2014/05/06/close_form_cannot_access_a_disposed_object
            }

        }

        private void T_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true; //關閉視窗時取消
            t_2.Hide(); //隱藏式窗,下次再show出
        }
    }
}
