using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ComputerGraphics2
{
    public class Mesh
    {
        Vector3[,] ControlPoints;
        public List<List<Vertex>> MeshPoints = new List<List<Vertex>>();
        public List<Triangle> Triangles = new List<Triangle>();
        public double rotationX;
        public double rotationZ;
        public Mesh(Vector3 [,] ControlPoints, int interval, double rotationX, double rotationZ)
        {
            this.ControlPoints = ControlPoints;
            this.rotationX = 0;
            this.rotationZ = 0;
            for (int i = 0; i <= interval; i++)
            {
                MeshPoints.Add(new List<Vertex>());
                for (int j = 0; j <= interval; j++)
                {
                    double u = (double)i/(double)interval;
                    double v = (double)j/(double)interval;
                    Vector3 pom = FindBezierpoint(u, v);
                    Vector3 pu = Vector3.Normalize(FindVectorPu(u, v));
                    Vector3 pv = Vector3.Normalize(FindVectorPv(u, v));
                    MeshPoints[i].Add(new Vertex(pom, pu, pv, u, v));
                }
            }
            RotateZ(rotationZ);
            RotateX(rotationX);
            for (int i = 1; i < MeshPoints.Count; i++)
            {
                for (int j = 0; j < MeshPoints[i].Count - 1; j++)
                {
                    Triangles.Add(new Triangle(MeshPoints[i][j], MeshPoints[i - 1][j], MeshPoints[i - 1][j + 1]));
                    Triangles.Add(new Triangle(MeshPoints[i][j], MeshPoints[i][j + 1], MeshPoints[i - 1][j + 1]));
                }
            }
        }
        public void DrawMesh(Graphics g, bool mesh, double kd, double ks, double m, Vector3 Il, Vector3 IO, Vector3 Light)
        {
            foreach(Triangle triangle in Triangles)
            {
                triangle.Draw(g, mesh, kd, ks, m, Il, IO, Light);
            }
        }
        Vector3 FindBezierpoint(double u, double v)
        {
            Vector3 ret = new Vector3(0, 0, 0);
            for(int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    double pom = Helpers.Newton[3, i] * Math.Pow(u, i) * Math.Pow(1 - u, 3 - i) * Helpers.Newton[3, j] * Math.Pow(v, j) * Math.Pow(1 - v, 3 - j);
                    ret.X += ControlPoints[i, j].X * (float)pom;
                    ret.Y += ControlPoints[i, j].Y * (float)pom;
                    ret.Z += ControlPoints[i, j].Z * (float)pom;
                }
            }
            return ret;
        }
        Vector3 FindVectorPu(double u, double v)
        {
            Vector3 ret = new Vector3(0, 0, 0);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    double pom = Helpers.Newton[2, i] * Math.Pow(u, i) * Math.Pow(1 - u, 2 - i) * Helpers.Newton[3, j] * Math.Pow(v, j) * Math.Pow(1 - v, 3 - j);
                    ret.X += (ControlPoints[i+1, j].X - ControlPoints[i, j].X) * (float)pom;
                    ret.Y += (ControlPoints[i + 1, j].Y - ControlPoints[i, j].Y) * (float)pom;
                    ret.Z += (ControlPoints[i + 1, j].Z - ControlPoints[i, j].Z) * (float)pom;
                }
            }
            ret.X *= 3;
            ret.Y *= 3;
            ret.Z *= 3;
            return ret;
        }

        Vector3 FindVectorPv(double u, double v)
        {
            Vector3 ret = new Vector3(0, 0, 0);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    double pom = Helpers.Newton[3, i] * Math.Pow(u, i) * Math.Pow(1 - u, 3 - i) * Helpers.Newton[2, j] * Math.Pow(v, j) * Math.Pow(1 - v, 2 - j);
                    ret.X += (ControlPoints[i, j + 1].X - ControlPoints[i, j].X) * (float)pom;
                    ret.Y += (ControlPoints[i, j + 1].Y - ControlPoints[i, j].Y) * (float)pom;
                    ret.Z += (ControlPoints[i, j + 1].Z - ControlPoints[i, j].Z) * (float)pom;
                }
            }
            ret.X *= 3;
            ret.Y *= 3;
            ret.Z *= 3;
            return ret;
        }

        public void UpdateVectorPuandPv()
        {
            for (int i = 0; i < MeshPoints.Count; i++)
            {
                for (int j = 0; j < MeshPoints[i].Count; j++)
                {
                    MeshPoints[i][j].pu = Vector3.Normalize(FindVectorPu(MeshPoints[i][j].u, MeshPoints[i][j].v));
                    MeshPoints[i][j].pv = Vector3.Normalize(FindVectorPv(MeshPoints[i][j].u, MeshPoints[i][j].v));
                    MeshPoints[i][j].N = Vector3.Cross(MeshPoints[i][j].pu, MeshPoints[i][j].pv);
                    MeshPoints[i][j].N = Vector3.Normalize(MeshPoints[i][j].N);
                }
            }
        }
        public void RotateZ(double theta)
        {
            double rad = Math.PI * (theta - rotationZ) / 180.0d;
            rotationZ = theta;
            for(int i = 0; i < MeshPoints.Count; i++)
            {
                for (int j = 0; j < MeshPoints[i].Count; j++)
                {
                    Vector3 newPos = new Vector3((float)(MeshPoints[i][j].X * Math.Cos(rad) - MeshPoints[i][j].Y * Math.Sin(rad)),
                        (float)( MeshPoints[i][j].X * Math.Sin(rad) + MeshPoints[i][j].Y * Math.Cos(rad)), MeshPoints[i][j].Z);
                    MeshPoints[i][j].actualPoint = newPos;
                }
            }
            UpdateVectorPuandPv();
        }
        public void RotateX(double theta)
        {
            double rad = Math.PI * (theta - rotationX) / 180.0d;
            rotationX = theta;
            for (int i = 0; i < MeshPoints.Count; i++)
            {
                for (int j = 0; j < MeshPoints[i].Count; j++)
                {
                    Vector3 newPos = new Vector3(MeshPoints[i][j].X,
                        (float)(MeshPoints[i][j].Y * Math.Cos(rad) - MeshPoints[i][j].Z * Math.Sin(rad)),
                        (float)(MeshPoints[i][j].Y*Math.Sin(rad) + MeshPoints[i][j].Z*Math.Cos(rad)));
                    MeshPoints[i][j].actualPoint = newPos;
                }
            }
            UpdateVectorPuandPv();
        }

    }
}
