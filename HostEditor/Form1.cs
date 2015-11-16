using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostEditor
{
    public partial class HostEditor : Form
    {
        public HostEditor()
        {
            InitializeComponent();
        }
        static string baglanticümlesi = "Data Source=.; initial Catalog=  HostEditor ; Integrated security = true;";
        SqlConnection baglanti = new SqlConnection(baglanticümlesi);

        private void Form1_Load(object sender, EventArgs e)
        {            
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            baglanti.Open();
            cmd.CommandText = "Select Host.Ip,Host.name,Host.Description,Category.CategoryName From Host inner join Category on Host.CategoryId= Category.CategoryId ";
            da.SelectCommand = cmd;
            cmd.Connection = baglanti;
            da.Fill(ds, "Host");
            GvHost.DataSource = ds.Tables["Host"];
            baglanti.Close();
        }

        Entitiesss db = new Entitiesss();

        private static void DosyaYaz()
        {
          
            Entitiesss db = new Entitiesss();
            StreamWriter write;
            write = File.AppendText(@"C:\Users\büşra\Desktop\busra.txt");

            List<Host> host = (from b in db.Host  select b).ToList();
           
            foreach (var item in host)
            {   
                
                //write.WriteLine(item.Category.CategoryName + " / " + item.Ip + " / " + item.Name + " / " + item.Description);
                write.WriteLine(item.Category.CategoryName);
                write.WriteLine(item.Ip + "  " + item.Name);
            }


            write.Close();
              
        }

        private void BtnGoster_Click(object sender, EventArgs e)
        {

            DosyaYaz();         
        }



    }
}
