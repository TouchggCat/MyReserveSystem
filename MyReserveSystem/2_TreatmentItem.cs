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
    public partial class TreatmentItem : Form
    {
        public TreatmentItem()
        {
            InitializeComponent();
        }

        private void TreatmentItem_Load(object sender, EventArgs e)
        {

        }

        MedicalEntities dbC = new MedicalEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            ReservationMain r_1 = new ReservationMain();

            Reserve reserve = new Reserve
            {
                ClinicID = 1,
                IdentityID = "GGG7111000",
                StatueID = 1,
                TreatmentID = 2,
                DoctorID = 2,
                //ReserveDate = r_1.monthCalendar1.SelectionStart.Date,    //TODO 設定格式 抓到小時
                ReserveDate = Convert.ToDateTime($"{label8.Text} {label9.Text}"),
                //TODO 無法呼叫前一個表單的日期，目前使用字串輸入
                //轉型別 Convert.ToDateTime(string)   --string格式有要求，必須是yyyy-MM-dd hh:mm:ss
                Remark_Patient = textBox1.Text
            };
            this.dbC.Reserve.Add(reserve);
            this.dbC.SaveChanges();   //查看資料表

          //==============================================
            Complete cpt = new Complete();   //秀出資訊到complete表單
            cpt.label12.Text = this.label12.Text;
            cpt.label7.Text = this.label7.Text;
            cpt.label8.Text = this.label8.Text;
            cpt.label9.Text = this.label9.Text;
            cpt.label2.Text = (from n in dbC.Reserve  
                               where n.IdentityID.Contains("GGG7111000")&& n.StatueID==1  //針對預約狀態為1的(未看診)
                               select n.ReserveID).FirstOrDefault().ToString();      //TODO 無法用LastOrDefault() 抓到新增的那筆???
            cpt.label4.Text = textBox1.Text;
            MessageBox.Show("預約成功!?");
            cpt.Show();
        }
       
    }
}
