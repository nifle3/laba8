using System.DirectoryServices;

namespace laba8
{
    public partial class Form1 : Form
    {
        private List<Figure> _figures = new List<Figure>();

        public Form1()
        {
            InitializeComponent();

            Init.bitmap = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            Init.pictureBox = pictureBox1;
            Init.pen = new Pen(Color.Black, 5); ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true && double.TryParse(textBox1.Text, out double x) && double.TryParse(textBox5.Text, out double y) && double.TryParse(textBox2.Text, out double width) && double.TryParse(textBox6.Text, out double height))
            {
                _figures.Add(new Ellipse(x, y, width/2, height/2));
                _figures[_figures.Count - 1].Draw();
                comboBox1.Items.Add(_figures.IndexOf(_figures[_figures.Count - 1]));
            }

            else if (radioButton2.Checked == true && double.TryParse(textBox1.Text, out x) && double.TryParse(textBox5.Text, out y) && double.TryParse(textBox2.Text, out height))
            {
                _figures.Add(new Circle(y, x, height / 2));
                _figures[_figures.Count - 1].Draw();
                comboBox1.Items.Add(_figures.IndexOf(_figures[_figures.Count - 1]));
            }

            else if (radioButton3.Checked == true && double.TryParse(textBox1.Text, out x) && double.TryParse(textBox5.Text, out y) && double.TryParse(textBox2.Text, out width) && double.TryParse(textBox6.Text, out height))
            {
                _figures.Add(new Rectangle(x, y, width, height));
                _figures[_figures.Count - 1].Draw();
                comboBox1.Items.Add(_figures.IndexOf(_figures[_figures.Count - 1]));
            }

            else if (radioButton4.Checked == true && double.TryParse(textBox1.Text, out x) && double.TryParse(textBox5.Text, out y) && double.TryParse(textBox2.Text, out height))
            {
                _figures.Add(new Square(x, y, height));
                _figures[_figures.Count - 1].Draw();
                comboBox1.Items.Add(_figures.IndexOf(_figures[_figures.Count - 1]));
            }

            else if (radioButton5.Checked == true)
            {
                _figures.Add(new Ellipse());
                _figures[_figures.Count - 1].Draw();
                comboBox1.Items.Add(_figures.IndexOf(_figures[_figures.Count - 1]));
            }

            else if (radioButton6.Checked == true)
            {
                _figures.Add(new Ellipse());
                _figures[_figures.Count - 1].Draw();
                comboBox1.Items.Add(_figures.IndexOf(_figures[_figures.Count - 1]));
            }

            else if (radioButton7.Checked == true)
            {
                _figures.Add(new Ellipse());
                _figures[_figures.Count - 1].Draw();
                comboBox1.Items.Add(_figures.IndexOf(_figures[_figures.Count - 1]));
            }
        }

        private void radioButtonClick(object sender, EventArgs e)
        {
            if (radioButton1.Checked || radioButton3.Checked || radioButton7.Checked)
            {
                (textBox1.Enabled, textBox5.Enabled) = (true, true);
                (textBox2.Enabled, textBox6.Enabled) = (true, true);
                textBox4.Enabled = false;
            }

            else if (radioButton2.Checked || radioButton4.Checked)
            {
                (textBox1.Enabled, textBox5.Enabled) = (true, true);
                (textBox2.Enabled, textBox6.Enabled) = (true, false);
                textBox4.Enabled = false;
            }

            else if (radioButton5.Checked || radioButton6.Checked)
            {
                (textBox1.Enabled, textBox5.Enabled) = (true, true);
                (textBox2.Enabled, textBox6.Enabled) = (true, true);
                textBox4.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count > 1)
            {
                Init.pictureBox.Image = null;

                _figures.RemoveAt(comboBox1.SelectedIndex);
                comboBox1.Items.Clear();

                for (int i = 0; i < _figures.Count; i++)
                {
                    _figures[i].Draw();
                    comboBox1.Items.Add(i);
                }

                comboBox1.SelectedIndex = 0;
            }

            else if (comboBox1.Items.Count == 1)
            {
                Init.pictureBox.Image = null;

                _figures.RemoveAt(comboBox1.SelectedIndex);
                comboBox1.Items.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox3.Text, out double deltaX) && double.TryParse(textBox7.Text, out double deltaY))
            {
                Graphics g = Graphics.FromImage(Init.bitmap);
                g.Clear(Color.White);

                if(_figures[comboBox1.SelectedIndex].X + deltaX < Init.pictureBox.Width)
                    _figures[comboBox1.SelectedIndex].X += deltaX;

                if (_figures[comboBox1.SelectedIndex].Y + deltaY < Init.pictureBox.Height)
                    _figures[comboBox1.SelectedIndex].Y += deltaY;

                foreach (Figure fg in _figures)
                {
                    fg.Draw();
                }
            }
        }
    }
}
