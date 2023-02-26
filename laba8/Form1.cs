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
            if(radioButton1.Checked == true)
            {
                _figures.Add(new Ellipse());
            }
            else if(radioButton2.Checked == true)
            {
                _figures.Add(new Circle());
            }
            else if(radioButton3.Checked == true)
            {
                _figures.Add(new Rectangle());
            }
            else if(radioButton4.Checked == true)
            {
                _figures.Add(new Square());
            } 
            else if(radioButton5.Checked == true)
            {
                _figures.Add(new Ellipse());
            }
            else if(radioButton6.Checked == true)
            {
                _figures.Add(new Ellipse());
            }
            else if(radioButton7.Checked == true)
            {
                _figures.Add(new Ellipse());
            }
        }
    }
}