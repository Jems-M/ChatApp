using Microsoft.VisualBasic;
using System.Linq.Expressions;
using System.Net.Sockets;

namespace WinClient
{
    public partial class Form1 : Form
    {
        const int portNo = 500;
        TcpClient client;
        byte[] data;

        public Form1()
        {
            InitializeComponent();
        }

        public void SendMessage(string message)
        {
            try
            {
                // send a message to the server
                NetworkStream ns = client.GetStream();
                byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                // send the text
                ns.Write(data, 0, data.Length);
                ns.Flush();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void ReceiveMessage(IAsyncResult ar)
        {
            try
            {
                int bytesRead;

                // read the data from the server
                bytesRead = client.GetStream().EndRead(ar);
                if (bytesRead == 0)
                {
                    return;
                }
                else
                {
                    // invoke the delegate to display the received data
                    object[] para = { System.Text.Encoding.ASCII.GetString(data, 0, bytesRead) };
                    this.Invoke(new delUpdateHistory(UpdateHistory), para);
                }
                // continue reading
                client.GetStream().BeginRead(data, 0,
                    System.Convert.ToInt32(client.ReceiveBufferSize), ReceiveMessage, null);
            } catch (Exception ex)
            {
                // ignore the error, occurs when a user signs out
            }
            
        }

        public delegate void delUpdateHistory(string str);

        public void UpdateHistory(string str)
        {
            txtMessageHistory.AppendText(str);
        }

        public void Disconnect()
        {
            try
            {
                // disconnect from server
                client.GetStream().Close();
                client.Close();
            } catch (Exception ex) 
            { 
                MessageBox.Show(ex.ToString());
            }
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (btnSignIn.Text == "Sign In")
            {
                try
                {
                    // connect to server
                    client = new TcpClient();
                    client.Connect("127.0.0.1", portNo);
                    data = new byte[client.ReceiveBufferSize];

                    // read from server
                    SendMessage(txtNick.Text);
                    client.GetStream().BeginRead(data, 0,
                        System.Convert.ToInt32(client.ReceiveBufferSize),
                        ReceiveMessage, null);
                    btnSignIn.Text = "Sign Out";
                    btnSend.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                // disconnect from server

                Disconnect();
                btnSignIn.Text = "Sign In";
                btnSend.Enabled = false;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage(txtMessage.Text);
            txtMessage.Clear();
        }
    }
}
