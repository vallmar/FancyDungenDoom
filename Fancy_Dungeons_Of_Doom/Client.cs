using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fancy_Dungeons_Of_Doom
{
    class Client
    {
        private TcpClient client;
        private Form1 OurForm;
        private Thread listenThread;
        private Thread sendThread;

        public Client(Form1 ourForm)
        {
            OurForm = ourForm;
        }

        ~Client()
        {
            if (listenThread.IsAlive)
                listenThread.Abort();

            if (sendThread.IsAlive)
                sendThread.Abort();
        }

        
        public void Start()
        {
            client = new TcpClient("192.168.220.103", 5000);
            listenThread = new Thread(Listen);
            listenThread.Start();
            sendThread = new Thread(Send);
            sendThread.Start();

            listenThread.Join();
            sendThread.Join();
        }

        public void Send()
        {
            string input;

            try
            {
                while (true)
                {
                    if (Form1.drive == false)
                    {
                    Thread.Sleep(200);
                        NetworkStream n = client.GetStream();

                        input = (Form1.player.X + ";" + Form1.player.Y).ToString();

                        BinaryWriter w = new BinaryWriter(n);
                        w.Write(input);
                        w.Flush();
                    }
                }

            }
            catch (Exception)
            {

            }
        }

        public void Listen()
        {
            string input;

            try
            {
                while (true)
                {
                    NetworkStream n = client.GetStream();

                    input = new BinaryReader(n).ReadString();
                    //string[] inputString = input.Split(';');
                    //Form1.player.X = Convert.ToInt32(inputString[0]);
                    //Form1.player.Y = Convert.ToInt32(inputString[1]);
                    OurForm.DisplayPlayer(input);

                }
            }
            catch (Exception ex)
            {
                
            }
        }

        internal void KillYourself()
        {
            
            if (listenThread.IsAlive)
                listenThread.Abort();

            if (sendThread.IsAlive)
                sendThread.Abort();
        }
    }
}
