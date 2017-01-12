using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HearthMirror.Objects;
using HearthMirror;

namespace HearthJarvis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Console.WriteLine("form statr");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("button click");
            int i = Reflection.GetNumCardsPlayerHand();
            Console.WriteLine(i.ToString());
            MatchInfo math = Reflection.GetMatchInfo();
            Console.WriteLine(math.LocalPlayer.Name);
            Reflection.GetFriendHandCards();
        }
    }
}
