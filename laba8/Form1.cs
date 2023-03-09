using System.DirectoryServices;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Diagnostics;

namespace laba8
{
    public partial class Form1 : Form
    {
        private List<IFigurable> _figures = new List<IFigurable>();
        private List<Point> _pt;
        private int _pointLength;

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

            tBy.Text = String.Empty;
            tBx.Text = String.Empty;

            comboBox1.SelectedIndex = _figures.Count - 1;
        }

        public Form1()
        {
            InitializeComponent();

            Init.bitmap = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            Init.pictureBox = pictureBox1;
            Init.pen = new Pen(Color.Black, 5);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool eq = Check(tBy.Text, tBx.Text, tBw.Text);
            bool a = eq && Check(tBw.Text);

            if (radioButton1.Checked && a)
            {
                AddFigure(new Ellipse(double.Parse(tBx.Text), double.Parse(tBy.Text), double.Parse(tBw.Text) / 2, double.Parse(tBh.Text) / 2 ));
            }

            else if (radioButton2.Checked && eq)
            {
                AddFigure(new Circle(double.Parse(tBx.Text), double.Parse(tBy.Text), double.Parse(tBw.Text ) / 2));
            }

            else if (radioButton3.Checked && a)
            {
                AddFigure(new Rectangle(double.Parse(tBx.Text), double.Parse(tBy.Text), double.Parse(tBw.Text), double.Parse(tBh.Text)));
            }

            else if (radioButton4.Checked && eq)
            {
                AddFigure(new Square(double.Parse(tBx.Text), double.Parse(tBy.Text), double.Parse(tBw.Text)));
            }

            else if (radioButton5.Checked)
            {
                AddFigure(new Polygon(_pt.ToArray()));

                textBox4.Enabled = true;
                btSide.Enabled = true;

                button1.Enabled = false;
            }

            else if (radioButton6.Checked)
            {
                AddFigure(new Triangle(_pt.ToArray()));
                
                textBox4.Enabled = false;
                btSide.Enabled = true;
                button1.Enabled = false;
            }

            else if (radioButton7.Checked && a)
            {
                AddFigure(new MyFig(double.Parse(tBx.Text), double.Parse(tBy.Text), double.Parse(tBw.Text), double.Parse(tBh.Text)));
            }
        }

        private void radioButtonClick(object sender, EventArgs e)
        {
            if (radioButton1.Checked || radioButton3.Checked || radioButton7.Checked)
            {
                button1.Enabled = true;

                (btSide.Enabled, BtPoint.Enabled) = (false, false);

                (tBx.Enabled, tBy.Enabled) = (true, true);
                (tBw.Enabled, tBh.Enabled) = (true, true);

                textBox4.Enabled = false;
            }

            else if (radioButton2.Checked || radioButton4.Checked)
            {
                btSide.Enabled = false;
                BtPoint.Enabled = false;
                button1.Enabled = true;

                (tBx.Enabled, tBy.Enabled) = (true, true);
                (tBw.Enabled, tBh.Enabled) = (true, false);

                textBox4.Enabled = false;
            }

            else if (radioButton5.Checked || radioButton6.Checked)
            {
                button1.Enabled = false;

                (tBx.Enabled, tBy.Enabled) = (true, true);
                (tBw.Enabled, tBh.Enabled) = (false, false);

                if (radioButton5.Checked)
                {
                    BtPoint.Enabled = false;
                    btSide.Enabled = true;

                    textBox4.Text = string.Empty;
                    textBox4.Enabled = true;

                    (tBx.Enabled, tBy.Enabled) = (false, false);
                }

                else
                {
                    textBox4.Enabled = false;
                    textBox4.Text = "3";
                    _pointLength = 3;

                    btSide.Enabled = false;
                    BtPoint.Enabled = true;

                    (tBx.Enabled, tBy.Enabled) = (true, true);

                    _pt = new List<Point>(3);
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
            if (int.TryParse(textBox4.Text, out var a))
            {
                _pt = new List<Point>(a);
                _pointLength = a;

                textBox4.Enabled = false;
                btSide.Enabled = false;
                BtPoint.Enabled = true;
                tBx.Enabled = true;
                tBy.Enabled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Check(tBx.Text, tBy.Text) && _pt.Count < _pointLength - 1)
            {
                _pt.Add(new Point(int.Parse(tBx.Text), int.Parse(tBy.Text)));
            }

            else if (_pt.Count == _pointLength - 1)
            {
                _pt.Add(new Point(int.Parse(tBx.Text), int.Parse(tBy.Text)));

                BtPoint.Enabled = false;
                (tBx.Enabled, tBy.Enabled) = (false, false);
                button1.Enabled = true;
            }

            tBy.Text = String.Empty;
            tBx.Text = String.Empty;
        }

        private void btScale_Click(object sender, EventArgs e)
        {
            if (Check(textBox3.Text, textBox7.Text) && comboBox1.Items.Count >= 1)
            {
                Graphics g = Graphics.FromImage(Init.bitmap);
                g.Clear(Color.White);

                _figures[comboBox1.SelectedIndex].Scale(double.Parse(textBox3.Text), double.Parse(textBox7.Text)) ;

                foreach (IFigurable fg in _figures)
                {
                    fg.Draw();
                }
            }
        }
    }
}
