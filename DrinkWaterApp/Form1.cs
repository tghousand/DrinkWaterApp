namespace DrinkWaterApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.comboBox1.SelectedIndex= 0;
        }

        private System.Windows.Forms.Timer timer1;
        private int counter = 5;
        private int repeatsCounter = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    counter = (int)numericUpDown1.Value;
                    comboBox1.Visible = false;
                    numericUpDown1.Visible = false;
                    checkBox1.Visible = false;
                    labelCountDown.Visible = true;
                    timer1 = new System.Windows.Forms.Timer();
                    timer1.Tick += new EventHandler(timer1_Tick);
                    timer1.Interval = 1000;
                    timer1.Start();
                    labelCountDown.Text = counter.ToString();
                    break;
                case 1:
                    counter = (int)numericUpDown1.Value * 60;
                    comboBox1.Visible = false;
                    numericUpDown1.Visible = false;
                    checkBox1.Visible = false;
                    labelCountDown.Visible = true;
                    timer1 = new System.Windows.Forms.Timer();
                    timer1.Tick += new EventHandler(timer1_Tick);
                    timer1.Interval = 1000;
                    timer1.Start();
                    labelCountDown.Text = counter.ToString();
                    break;
                case 2:
                    counter = (int)numericUpDown1.Value * 60 * 60;
                    comboBox1.Visible = false;
                    numericUpDown1.Visible = false;
                    checkBox1.Visible = false;
                    labelCountDown.Visible = true;
                    timer1 = new System.Windows.Forms.Timer();
                    timer1.Tick += new EventHandler(timer1_Tick);
                    timer1.Interval = 1000;
                    timer1.Start();
                    labelCountDown.Text = counter.ToString();
                    break;
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter--;
            labelCountDown.Text = counter.ToString();
            if (counter == 0 || counter < 0)
            {
                if(checkBox1.Checked)
                {
                    repeatTimer(sender, e, repeatsCounter);
                    repeatsCounter++;
                } else
                {
                    stopTimer();
                }
                
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    numericUpDown1.Maximum = 60;
                    break;
                case 1:
                    numericUpDown1.Maximum = 60;
                    break;
                case 2:
                    numericUpDown1.Maximum = 24;
                    break;
            }
        }

        private void stopTimer()
        {
            timer1.Stop();
            MessageBox.Show("Drink Water", "Drink!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            labelCountDown.Visible = false;
            checkBox1.Visible = true;
            numericUpDown1.Visible = true;
            comboBox1.Visible = true;
            Activate();
        }

        private void repeatTimer(object sender, EventArgs e, int repeats)
        {
            if(repeats >= 1)
            {
                timer1.Stop();
                DialogResult result = MessageBox.Show("Drink Water. Repeat?", "Drink!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                if(result == DialogResult.Yes) { button1_Click(sender, e); }
                else
                {
                    labelCountDown.Visible = false;
                    checkBox1.Visible = true;
                    numericUpDown1.Visible = true;
                    comboBox1.Visible = true;
                    Activate();
                }
            } else
            {
                timer1.Stop();
                MessageBox.Show("Drink Water", "Drink!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                button1_Click(sender, e);
            }
            
        }
    }
}