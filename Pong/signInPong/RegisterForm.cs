using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace signInPong
{
    public partial class RegisterForm : Form
    {
        List<Player> players;
        XmlDocument allPlayers;
        public RegisterForm(string username,string password, IEnumerable<Player> players, XmlDocument playerXml)
        {
            InitializeComponent();
            usernameTextBox.Text = username;
            passwordTextBox.Text = password;
            confirmPwTxtBox.Focus();
            this.players = players.ToList();
            this.allPlayers = playerXml;
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            foreach (Player player in players)
            {
                if (player.Name == usernameTextBox.Text)
                {
                    MessageBox.Show("User already exists.");
                    return;
                }
            }
            if (confirmPwTxtBox.Text != passwordTextBox.Text)
            {
                MessageBox.Show("Passwords don't match.");
                return;
            }
            if (!IsValidEmail(emailtxtBox.Text))
            {
                MessageBox.Show("Invalid email address.");
                return;
            }
            XmlElement newStudent = allPlayers.CreateElement("player");

            XmlElement studentName = allPlayers.CreateElement("name");
            studentName.InnerText = usernameTextBox.Text;
            XmlElement pwd = allPlayers.CreateElement("password");
            pwd.InnerText = passwordTextBox.Text;
            XmlElement score = allPlayers.CreateElement("score");
            score.InnerText = "0";
            XmlElement email = allPlayers.CreateElement("email");
            email.InnerText = emailtxtBox.Text;
            newStudent.AppendChild(studentName);
            newStudent.AppendChild(pwd);
            newStudent.AppendChild(score);
            newStudent.AppendChild(email);
            allPlayers.GetElementsByTagName("scores")[0].AppendChild(newStudent);
            allPlayers.Save("PlayerDetail.xml");
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
