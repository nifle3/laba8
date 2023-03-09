using System.DirectoryServices;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace laba8
{
    public partial class Form1 : Form
    {
        private List<IFigurable> _figures = new List<IFigurable>();

        private bool Check(params string[] x)
        {
            bool a = false;
            foreach (string c in x)
            {
                a = double.TryParse(c, out double v);
            }
            return a;
        }

        private void AddFigure(IFigurable temp)
        {
            _figures.Add(temp);
            _figures[_figures.Count - 1].Draw();
            comboBox1.Items.Add(_figures.IndexOf(_figures[_figures.Count - 1]));
        }

        public Form1()
        {
            InitializeComponent();

            Init.bitmap = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            Init.pictureBox = pictureBox1;
            Init.pen = new Pen(Color.Black, 5); ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool eq = Check(tBy.Text, tBx.Text, tBh.Text);
            bool a = eq && Check(tBw.Text);

            if (radioButton1.Checked && a)
            {
                AddFigure(new Ellipse(double.Parse(tBx.Text), double.Parse(tBy.Text), double.Parse(tBw.Text) / 2, double.Parse(tBh.Text) / 2 ));
            }

            else if (radioButton2.Checked && eq)
            {
                AddFigure(new Circle(double.Parse(tBx.Text), double.Parse(tBy.Text), double.Parse(tBh.Text ) / 2));
            }

            else if (radioButton3.Checked && a)
            {
                AddFigure(new Rectangle(double.Parse(tBx.Text), double.Parse(tBy.Text), double.Parse(tBw.Text), double.Parse(tBh.Text)));
            }

            else if (radioButton4.Checked && eq)
            {
                AddFigure(new Square(double.Parse(tBx.Text), double.Parse(tBy.Text), double.Parse(tBh.Text)));
            }

            else if (radioButton5.Checked)
            {
                _figures[_figures.Count - 1].Draw();
                comboBox1.Items.Add(_figures.IndexOf(_figures[_figures.Count - 1]));

                textBox4.Enabled = true;
                button4.Enabled = true;
            }

            else if (radioButton6.Checked)
            {
                _figures[_figures.Count - 1].Draw();
                comboBox1.Items.Add(_figures.IndexOf(_figures[_figures.Count - 1]));
                
                textBox4.Enabled = false;
                button4.Enabled = true;
            }

            else if (radioButton7.Checked)
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
                button4.Enabled = false;
                button5.Enabled = false;
                button1.Enabled = true;

                (tBx.Enabled, tBy.Enabled) = (true, true);
                (tBw.Enabled, tBh.Enabled) = (true, true);

                textBox4.Enabled = false;
            }

            else if (radioButton2.Checked || radioButton4.Checked)
            {
                button4.Enabled = false;
                button5.Enabled = false;
                button1.Enabled = true;

                (tBx.Enabled, tBy.Enabled) = (true, true);
                (tBw.Enabled, tBh.Enabled) = (true, false);

                textBox4.Enabled = false;
            }

            else if (radioButton5.Checked || radioButton6.Checked)
            {
                button4.Enabled = true;
                button5.Enabled = false;
                button1.Enabled = false;

                (tBx.Enabled, tBy.Enabled) = (true, true);
                (tBw.Enabled, tBh.Enabled) = (false, false);

                if (radioButton5.Checked)
                {
                    textBox4.Text = string.Empty;
                    textBox4.Enabled = true;
                }

                else
                {
                    textBox4.Enabled = false;
                    textBox4.Text = "3";
                }
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
            if (double.TryParse(textBox3.Text, out double deltaX) && double.TryParse(textBox7.Text, out double deltaY) && comboBox1.Items.Count >= 1)
            {
                Graphics g = Graphics.FromImage(Init.bitmap);
                g.Clear(Color.White);

                _figures[comboBox1.SelectedIndex].MoveTo(deltaX, deltaY);

                foreach (IFigurable fg in _figures)
                {
                    fg.Draw();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //if (int.TryParse(textBox4.Text, out int i) && i >= 3)
            //{
            //    if (radioButton5.Checked)
            //        _figures.Add(new Polygon(i));

            //    else if (radioButton6.Checked)
            //        _figures.Add(new Triangle());

            //    textBox4.Enabled = false;
            //    button5.Enabled = true;
            //    button4.Enabled = false;
            //}
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //Polygon? pg = _figures[_figures.Count - 1] as Polygon;

            //if (int.TryParse(textBox1.Text, out int x) && int.TryParse(textBox5.Text, out int y) && pg is not null)
            //{
            //    if (pg.i < pg.count)
            //    {
            //        pg[pg.i] = new Point(x, y);
            //        pg.i++;

            //        textBox1.Text = string.Empty;
            //        textBox5.Text = string.Empty;
            //    }
                
            //    if (pg.i == pg.count)
            //    {
            //        label1.Text = "giuasdsad";
            //        button1.Enabled = true;
            //        button5.Enabled = false;
            //    }

            //}
        }
    }
}
