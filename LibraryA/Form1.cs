using WindowsFormsApp2;

namespace Library_A
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = t1.Text;
            string password = t2.Text;

            Program.InsertUser(username, password);
        }
    }
}
