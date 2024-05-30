using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading.Tasks.Dataflow;

namespace Server
{
    public class ChatClient
    {
        public static Hashtable AllClients = new Hashtable();

        private TcpClient _client;
        private string _clientIP;
        private string _clientNick;

        private byte[] data;

        private bool ReceiveNick = true;

        public ChatClient(TcpClient client) 
        { 
            _client = client;

            // get client IP address
            _clientIP = client.Client.RemoteEndPoint.ToString();

            // add current client to the hash table
            AllClients.Add(_clientIP, this);

            // start reading data from the client in another thread
            data = new byte[_client.ReceiveBufferSize];
            client.GetStream().BeginRead(data, 0, 
                System.Convert.ToInt32(_client.ReceiveBufferSize), ReceiveMessage, null);
        }

        public void ReceiveMessage(IAsyncResult ar)
        {
            // read from client
            int bytesRead;
            try
            {
                lock (_client.GetStream())
                {
                    bytesRead = _client.GetStream().EndRead(ar);
                }

                // client has disconnected
                if (bytesRead < 1) 
                {
                    AllClients.Remove(_clientIP);
                    Broadcast(_clientNick + " has left the chat.");
                    return;
                } else
                {
                    // get the message sent
                    string messageReceived = 
                        System.Text.Encoding.ASCII.GetString(data, 0, bytesRead);

                    // client is sending its nickname
                    if (ReceiveNick)
                    {
                        _clientNick = messageReceived;

                        Broadcast(_clientNick + " has joined the chat.");
                        ReceiveNick = false;
                    }
                    else
                    {
                        Broadcast(_clientNick + ">" + messageReceived);
                    }
                }

                // continue reading from client
                lock(_client.GetStream())
                {
                    _client.GetStream().BeginRead(data, 0, 
                        System.Convert.ToInt32(_client.ReceiveBufferSize), ReceiveMessage, null);
                }
            } catch (Exception ex)
            {
                AllClients.Remove(_clientIP);
                Broadcast(_clientNick + " has left the chat.");
            }
        }

        public void SendMessage(string message)
        {
            try
            {
                // send the text
                System.Net.Sockets.NetworkStream ns;
                lock (_client.GetStream())
                {
                    ns = _client.GetStream();
                }

                byte[] bytesToSend = System.Text.Encoding.ASCII.GetBytes(message);
                ns.Write(bytesToSend, 0, bytesToSend.Length);
                ns.Flush();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void Broadcast(string message)
        {
            // log it locally
            Console.WriteLine(message);
            foreach (DictionaryEntry c in AllClients)
            {
                // broadcast to other users
                ((ChatClient)(c.Value)).SendMessage(message 
                    + Environment.NewLine);
            }
        }
    }
}
