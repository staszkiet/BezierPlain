using System.Numerics;
using System.Reflection;

namespace ComputerGraphics2
{
    public partial class Form1 : Form
    {
        Vector3[,] ControlPoints = new Vector3[4, 4];
        Brush ControlPointBrush = new SolidBrush(Color.Green);
        Pen ControlEdgePen = new Pen(new SolidBrush(Color.Black));
        public Mesh mesh;
        public Vector3 Light = new Vector3(0, 0, 200);
        public Vector3 LightColor = new Vector3(1, 1, 1);
        Vector3 ObjectColor = new Vector3(1, 0, 0);
        public Form1()
        {
            var fileStream = File.OpenRead("C:\\Users\\zaprz\\source\\repos\\ComputerGraphics2\\ComputerGraphics2\\init.txt");
            var streamReader = new StreamReader(fileStream);
            string? pom;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if ((pom = streamReader.ReadLine()) != null)
                    {
                        string[] coords = pom.Split(' ');
                        int x = int.Parse(coords[0]);
                        int y = int.Parse(coords[1]);
                        int z = int.Parse(coords[2]);
                        ControlPoints[i, j] = new Vector3(x, y, z);
                    }
                }
            }
            InitializeComponent();
            mesh = new Mesh(ControlPoints, trackBar1.Value, 0, 0);
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, splitContainer1.Panel1, new object[] { true });
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;
            g.ScaleTransform(1, -1);
            g.TranslateTransform(splitContainer1.Panel1.Width / 2, -splitContainer1.Panel1.Height / 2);
            foreach (var p in ControlPoints)
            {
                e.Graphics.FillRectangle(ControlPointBrush, p.X - 5, p.Y - 5, 10, 10);
            }
            mesh.DrawMesh(g, checkBox1.Checked, (double)trackBarkd.Value / (double)trackBarkd.Maximum, (double)trackBarks.Value / (double)trackBarks.Maximum, trackBarm.Value, LightColor, ObjectColor, Light);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            mesh = new Mesh(ControlPoints, trackBar1.Value, mesh.rotationX, mesh.rotationZ);
            pictureBox1.Invalidate();
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            mesh.RotateZ(trackBar2.Value);
            pictureBox1.Invalidate();
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            mesh.RotateX(trackBar3.Value);
            pictureBox1.Invalidate();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void trackBarkd_ValueChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void trackBarks_ValueChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void trackBarm_ValueChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button1.BackColor = colorDialog1.Color;
                ObjectColor = new Vector3((float)colorDialog1.Color.R / 255, (float)colorDialog1.Color.G / 255, (float)colorDialog1.Color.B / 255);
                pictureBox1.Invalidate();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                button2.BackColor = colorDialog2.Color;
                LightColor = new Vector3((float)colorDialog2.Color.R / 255, (float)colorDialog2.Color.G / 255, (float)colorDialog2.Color.B / 255);
                pictureBox1.Invalidate();
            }
        }
    }
}
