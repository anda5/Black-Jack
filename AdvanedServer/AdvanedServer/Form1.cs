﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetworksApi.TCP.SERVER;

namespace AdvanedServer
{
    public delegate void UpdateChat(string txt);
    public delegate void UpdateListBox(ListBox box, string txt, bool remove);
    public partial class Form1 : Form
    {
        Server server;

        public Form1()
        {
            InitializeComponent();
        }
        public void ChangeChat(string txt)
        {
            if (textBox1.InvokeRequired)
            {

                Invoke(new UpdateChat(ChangeChat), new object[] { txt });

            }
            else
            {
                textBox1.Text = txt +  "\r\n";
            }
        }
        public void ChangeListBox(ListBox box, string txt, bool remove)
        {
            if (listBox1.InvokeRequired)
            {
                Invoke(new UpdateListBox(ChangeListBox), new object[] { box, txt, remove });

            }
            else
            {
                if (remove)
                {
                    box.Items.Remove(txt);
                }
                else
                {
                    box.Items.Add(txt);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            server = new Server("192.168.0.102", "80");
            server.OnClientConnected += new OnConnectedDelegate(server_OnClientConected);
            server.OnClientDisconnected += new OnDisconnectedDelegate(server_OnClientDisconected);
            server.OnDataReceived += new OnReceivedDelegate(server_OnRecived);
            server.OnServerError += new OnErrorDelegate(server_OnServerError);
            server.Start();
        }

        private void server_OnClientDisconected(object Sender, DisconnectedArguments R)
        {
            server.BroadCast(R.Name + "  has disconnected");
            ChangeListBox(listBox1, R.Name, true);
            ChangeListBox(listBox2, R.Ip, true);
        }

        private void server_OnServerError(object Sender, ErrorArguments R)
        {
            MessageBox.Show(R.ErrorMessage);


        }

        private void server_OnRecived(object Sender, ReceivedArguments R)
        {
            ChangeChat(R.ReceivedData);
            server.BroadCast(R.Name + " says: " + R.ReceivedData);

        }

        private void server_OnClientConected(object Sender, ConnectedArguments R)
        {
            server.BroadCast(R.Name + " has connected");
            ChangeListBox(listBox1, R.Name,false);
            ChangeListBox(listBox2, R.Ip, false);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.SelectedIndex = listBox1.SelectedIndex;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = listBox2.SelectedIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            server.SendTo((string)listBox1.SelectedItem, textBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            server.BroadCast(textBox2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            server.DisconnectClient((string)listBox1.SelectedItem);
        }


    }
}