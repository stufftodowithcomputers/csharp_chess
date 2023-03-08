namespace Chess
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();

            Form2 form = new Form2();
            form.ShowDialog();

            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();

            Form3 form = new Form3();
            form.ShowDialog();

            Show();
        }
    }
}