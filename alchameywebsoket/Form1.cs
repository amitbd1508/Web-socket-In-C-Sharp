using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alchemy;
using Alchemy.Classes;
using System.Net;
using Newtonsoft.Json.Linq;


namespace AlchameyWebsoket
{
    public partial class Form1 : Form
    {
        int rowindex = 0;
        public Form1()
        {
            InitializeComponent();
            startServer();
        }

        void startServer()
        {
            var aServer = new WebSocketServer(8182, IPAddress.Any)
            {

                OnReceive = OnReceive,
                OnSend = OnSend,
                OnConnect = OnConnect,
                OnConnected = OnConnected,
                OnDisconnect = OnDisconnect,
                TimeOut = new TimeSpan(0, 5, 0)
            };
            richTextBox1.AppendText("Initializing......\n");
            aServer.Start();
            richTextBox1.AppendText("Start at " + aServer.ListenAddress+":8182" + "\n");
        }
        

        private void OnDisconnect(UserContext context)
        {
            
            Invoke(new Action(() => richTextBox1.AppendText(context.ClientAddress+"Disconnected............." + "\n")));
            
        }

        private void OnConnect(UserContext context)
        {

            Invoke(new Action(() => richTextBox1.AppendText(context.ClientAddress + "OnConnect............." + "\n")));
        }

        private void OnSend(UserContext context)
        {
           
            Invoke(new Action(() => richTextBox1.AppendText("OnSend..............\n")));
        }

        private void OnReceive(UserContext context)
        {
            Invoke(new Action(() => richTextBox1.AppendText(context.DataFrame+"\n" )));
            ////context.Send("hi");
            //JArray arry = JArray.Parse(context.DataFrame.ToString());
            
            ////dataGridView1.Rows[rowindex].Cells[1].Value = s;
            //DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            //row.Cells[0].Value = "Table 1";
            //dataGridView1.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //string s="";
            //for (int i = 0; i < arry.Count-1;i++ )
            //    s =s+ arry[i]+Environment.NewLine;
            //row.Cells[1].Value = s;
            //row.Cells[2].Value = arry[arry.Count - 1];
            //Invoke(new Action(() => dataGridView1.Rows.Add(row)));
            

        }
        private void OnConnected(UserContext context)
        {
            
            Invoke(new Action(() => richTextBox1.AppendText("Client Connection From : " + context.ClientAddress.ToString())));
        }
    }
}
