using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design.Behavior;

namespace ComputerGraphics2
{
    public class Triangle
    {
        Vertex []tab;
        Pen p = new Pen(new SolidBrush(Color.Black));
        Pen fillP = new Pen(new SolidBrush(Color.FromArgb(Helpers.r.Next(255), Helpers.r.Next(255), Helpers.r.Next(255))));
        public bool bmap = true;
        public Triangle(Vertex p1, Vertex p2, Vertex p3, bool bmap)
        {
            tab = new Vertex[3];
            tab[0] = p1;
            tab[1] = p2;
            tab[2] = p3;
            this.bmap = bmap;
        }

        public void Draw(Graphics g, bool mesh, double kd, double ks, double m, Vector3 Il, Vector3 IO, Vector3 Light)
        {
            Fill(g, kd, ks, m, Il, IO, Light);
            if (mesh)
            {
                g.DrawLine(p, (int)tab[0].X, (int)tab[0].Y, (int)tab[1].X, (int)tab[1].Y);
                g.DrawLine(p, (int)tab[2].X, (int)tab[2].Y, (int)tab[1].X, (int)tab[1].Y);
                g.DrawLine(p, (int)tab[0].X, (int)tab[0].Y, (int)tab[2].X, (int)tab[2].Y);
            }
        }

        public void SetPixel(Graphics g, int k, int scanline, double kd, double ks, double m, Vector3 Il, Vector3 Io, Vector3 Light)
        {
            Vector3 pom = Helpers.CalculateBarycentricCoords(new Vector2(k, scanline), tab[0].actualPoint, tab[1].actualPoint, tab[2].actualPoint);
            pom.X = pom.X < 0 ? 0 : pom.X > 1 ? 1 : pom.X;
            pom.Y = pom.Y < 0 ? 0 : pom.Y > 1 ? 1 : pom.Y;
            pom.Z = pom.Z < 0 ? 0 : pom.Z > 1 ? 1 : pom.Z;
            Vector3 N = new Vector3(pom.X * tab[0].N.X + pom.Y * tab[1].N.X + pom.Z * tab[2].N.X, pom.X * tab[0].N.Y + pom.Y * tab[1].N.Y + pom.Z * tab[2].N.Y, pom.X * tab[0].N.Z + pom.Y * tab[1].N.Z + pom.Z * tab[2].N.Z);
            Vector3 color = Helpers.CountI(k, scanline, pom.Z, kd, ks, m, Il, Io, Light, N);
            g.FillRectangle(new SolidBrush(Color.FromArgb((int)color.X, (int)color.Y, (int)color.Z)), k, scanline, 1, 1);
        }
        public void SetPixelFromMesh(Graphics g, int k, int scanline)
        {
            Vector3 pom = Helpers.CalculateBarycentricCoords(new Vector2(k, scanline), tab[0].actualPoint, tab[1].actualPoint, tab[2].actualPoint);
            pom.X = pom.X < 0 ? 0 : pom.X > 1 ? 1 : pom.X;
            pom.Y = pom.Y < 0 ? 0 : pom.Y > 1 ? 1 : pom.Y;
            pom.Z = pom.Z < 0 ? 0 : pom.Z > 1 ? 1 : pom.Z;
            float u = tab[0].u * pom.X + tab[1].u * pom.Y + tab[2].u * pom.Z;
            float v = tab[0].v * pom.X + tab[1].v * pom.Y + tab[2].v * pom.Z;
            u = u < 0 ? 0 : u > 1 ? 1 : u;
            v = v < 0 ? 0 : v > 1 ? 1 : v;
            int bitmapx = (int)(u * (float)Form1.bm.Width);
            int bitmapy = (int)(v * (float)Form1.bm.Height);
            bitmapx = bitmapx < 0 ? 0 : bitmapx >= Form1.bm.Width ? Form1.bm.Width - 1 : bitmapx;
            bitmapy = bitmapy < 0 ? 0 : bitmapy >= Form1.bm.Height ? Form1.bm.Height - 1 : bitmapy;
            int color = Form1.bm.GetPixel(bitmapx, bitmapy).ToArgb();
            g.FillRectangle(new SolidBrush(Color.FromArgb(color)), k, scanline, 1, 1);
        }
        public void Fill(Graphics g, double kd, double ks, double m, Vector3 Il, Vector3 Io, Vector3 Light)
        {
            List<int> idx = new List<int>();
            List<AED>ActiveEdges = new List<AED>();
            idx.Add(0);
            idx.Add(1);
            idx.Add(2);
            idx.Sort((x, y) => (int)tab[x].Y - (int)tab[y].Y != 0 ? (int)tab[x].Y - (int)tab[y].Y : (int)tab[x].X - (int)tab[y].X);
            int scanline = (int)tab[idx[0]].Y;
            int end = (int)tab[idx[2]].Y;
            int i = 0;
            List<int> IdxOnScanline = new List<int>();
            scanline++;
            while (scanline < end)
            {
                if ((int)tab[idx[i]].Y <= scanline - 1)
                {
                    do
                    {
                        IdxOnScanline.Add(idx[i]);
                        i++;
                        if (i != 0 && i % 2 == 0)
                        {
                            for (int k = (int)tab[idx[i-2]].X; k <= (int)tab[idx[i-1]].X; k++)
                            {
                                if (!bmap)
                                {
                                    SetPixel(g, k, scanline-1, kd, ks, m, Il, Io, Light);
                                }
                                else
                                {
                                    SetPixelFromMesh(g, k, scanline-1);
                                }
                            }
                        }
                    } while (i < tab.Count() && (int)tab[idx[i]].Y == (int)tab[idx[i-1]].Y);
                    foreach (int index in IdxOnScanline)
                    {
                        int previdx = index == 0 ? 2 : index - 1;
                        int nextidx = (index + 1) % 3;
                        if ((int)tab[previdx].Y >= (int)tab[index].Y)
                        {
                            if ((int)tab[previdx].Y != (int)tab[index].Y)
                            {
                                AED pom = new AED();
                                int prevX = (int)tab[previdx].X;
                                int X = (int)tab[index].X;
                                int Y = (int)tab[index].Y;
                                int prevY = (int)tab[previdx].Y;
                                pom.ymax = (int)tab[previdx].Y;
                                pom.diff = (float)(prevX - X) / (float)(prevY - Y);
                                pom.x = (int)tab[index].X + pom.diff;
                                pom.higherid = previdx;
                                pom.lowerid = index;
                                ActiveEdges.Add(pom);
                            }
                        }
                        else
                        {
                            ActiveEdges.RemoveAll((x) => x.lowerid == previdx && x.higherid == index);
                        }
                        if ((int)tab[nextidx].Y >= (int)tab[index].Y)
                        {
                            if ((int)tab[nextidx].Y != (int)tab[index].Y)
                            {
                                AED pom = new AED();
                                int nextX = (int)tab[nextidx].X;
                                int X = (int)tab[index].X;
                                int Y = (int)tab[index].Y;
                                int nextY = (int)tab[nextidx].Y;  
                                pom.ymax = (int)tab[nextidx].Y;
                                pom.diff = (float)(nextX - X) / (float)(nextY - Y);
                                pom.x = (int)tab[index].X + pom.diff;
                                pom.higherid = nextidx;
                                pom.lowerid = index;
                                ActiveEdges.Add(pom);
                            }
                        }
                        else
                        {
                            ActiveEdges.RemoveAll((x) => x.lowerid == nextidx && x.higherid == index);
                        }
                    }
                    IdxOnScanline = new List<int>();

                }
                ActiveEdges.Sort((x, y) => (int)x.x - (int)y.x);
                for(int j = 1; j < ActiveEdges.Count; j = j + 2)
                {
                    for (int k = (int)ActiveEdges[j - 1].x; k <= (int)ActiveEdges[j].x; k++)
                    {
                        if (!bmap)
                        {
                            SetPixel(g, k, scanline, kd, ks, m, Il, Io, Light);
                        }
                        else
                        {
                            SetPixelFromMesh(g, k, scanline);
                        }
                    }
                }
                foreach (AED a in ActiveEdges)
                {
                    a.x += a.diff;
                }
                scanline++;
            }

        }
    }

    public class AED
    {
        public float ymax;
        public float x;
        public float diff;
        public int higherid;
        public int lowerid;
    }
}
