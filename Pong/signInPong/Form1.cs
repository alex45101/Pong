using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Pong;
using System.Threading;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace signInPong
{
    public partial class Form1 : Form
    {
        XmlDocument xml;
        List<Player> players = new List<Player>();

        public Form1()
        {
            InitializeComponent();
        }

        public void sendMailMessage(string mailMessageSendTo, string subject, string body)
        {
            MailMessage mm = new MailMessage();
            System.Net.Mail.MailAddress sendFrom = new System.Net.Mail.MailAddress("mcponggame@gmail.com", Environment.UserName);
                mm.Sender = sendFrom;
                mm.IsBodyHtml = true;
                mm.To.Add(new MailAddress(mailMessageSendTo));
                mm.From = sendFrom;
                mm.Body = body;
                mm.Subject = subject;
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("mcponggame@gmail.com", "alex45101")
                };
                smtp.Send(mm);
        }

        private void loadPlayers()
        {
            //Create an object using XmlDocument class
            xml = new XmlDocument();
            xml.Load("PlayerDetail.xml");

            foreach (XmlElement element in xml.GetElementsByTagName("player"))
            {
                string name = element.GetElementsByTagName("name")[0].InnerText.Trim();
                string password = element.GetElementsByTagName("password")[0].InnerText.Trim();
                string email = element.GetElementsByTagName("email")[0].InnerText.Trim();
                players.Add(new Player(name, password, email));
            }


            foreach (Player player in players)
            {
                name.Items.Add(player);
            }

        }

        void StartGame(object param)
        {
            object[] parameters = (object[])param;
            Game1 theGame = new Game1();
            theGame.signInAs(parameters[0].ToString());
            if (parameters[1] != null)
            {
                theGame.setSteveIcon(new StreamReader(parameters[1].ToString()).BaseStream);
            }
            theGame.Window.Title = "Pong";
            theGame.Run();
        }

        private void sign_Click(object sender, EventArgs e)
        {
            // Do username validation
            String username = name.Text.Trim();
            String passwordText = password.Text;

            bool login = false;
            bool isValidUser = false;

            foreach (Player player in players)
            {
                if (player.Name == username)
                {
                    isValidUser = true;
                }
                if (player.Name == username && player.Password == passwordText)
                {
                    login = true;
                    break;
                }
            }

            if (login)
            {
                Hide();
               /* foreach (Player player in players)
                {
                    sendMailMessage(player.Email, "Someone logged in.", "Someone logged in to minecraft pong. Thank you for playing!");
                }*/
                ParameterizedThreadStart starta = new ParameterizedThreadStart(StartGame);
                Thread theThread = new Thread(starta);
                theThread.Start(new object[] { username, icon });
                Application.Exit();
            }
            else if (!login && !isValidUser)
            {
                // Register new user
                RegisterForm register = new RegisterForm(username, passwordText, players, xml);
                if (register.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show("Registration canceled.");
                }
                else
                {
                    Guid regKey = Guid.NewGuid();
                    sendMailMessage(register.emailtxtBox.Text, "Confirm Minecraft Pong Registration", "Please confirm your minecraft pong registration as the user '"+register.usernameTextBox.Text+"' by entering this code:<br/><br/>" + regKey.ToString()+"<br/><br/>Thank you for registering!");
                    string inputString = null;
                    ConfirmRegForm confirm = new ConfirmRegForm(regKey);
                    confirm.ShowDialog();
                    Hide();
                    ParameterizedThreadStart starta = new ParameterizedThreadStart(StartGame);
                    Thread theThread = new Thread(starta);
                    theThread.Start(new object[] { username, icon });
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show("Invalid Login");
            }
        }

        string icon = null;

        private void button2_Click(object sender, EventArgs e)
        {
            if (iconChooser.ShowDialog() != DialogResult.Cancel)
            {
                icon = iconChooser.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadPlayers();
        }
    }
}
