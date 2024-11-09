using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics2
{
    public static class Helpers
    {
        public static Random r = new Random();
        public static int[,] Newton = { { 1, -1, -1, -1, -1 }, { 1, 1, -1, -1, -1 }, { 1, 2, 1, -1, -1 }, {1, 3, 3, 1, -1 }, {1, 4, 6, 4, 1 } };
        public static Vector3 CountI(float X, float Y, float Z, double kd, double ks, double m, Vector3 Il, Vector3 Io, Vector3 Light, Vector3 N)
        {
            Vector3 L = new Vector3(0, 0, 0);
            L.X = Light.X - X;
            L.Y = Light.Y - Y;
            L.Z = Light.Z - Z;
            L = Vector3.Normalize(L);
            Vector3 V = new Vector3(0, 0, 1);
            double pomNL = Vector3.Dot(N, L);
            Vector3 R = new Vector3((float)(2*pomNL * N.X - L.X), (float)(2*pomNL * N.Y - L.Y), (float)(pomNL * 2 * N.Z - L.Z));
            R = Vector3.Normalize(R);
            double pomVR = Vector3.Dot(V, R);
            float x = (float)(kd * Il.X * Io.X * (pomNL >= 0 ? pomNL : 0) + ks*Il.X*Io.X*Math.Pow(pomVR, m));
            float y = (float)(kd * Il.Y * Io.Y * (pomNL >= 0 ? pomNL : 0) + ks * Il.Y * Io.Y * Math.Pow(pomVR, m));
            float z = (float)(kd * Il.Z * Io.Z * (pomNL >= 0 ? pomNL : 0) + ks * Il.Z * Io.Z * Math.Pow(pomVR, m));
            return new Vector3(x*(float)255 > 255 ? 255 : x*255, y*(float)255 > 255 ? 255 : y*255, z*(float)255 > 255 ? 255 : z*255);
        }

        public static Vector3 CalculateBarycentricCoords(Vector2 p, Vector3 a, Vector3 b, Vector3 c)
        {
            float detT = (b.Y - c.Y) * (a.X - c.X) + (c.X - b.X) * (a.Y - c.Y);
            float l1 = ((b.Y - c.Y) * (p.X - c.X) + (c.X - b.X) * (p.Y - c.Y)) / detT;
            float l2 = ((c.Y - a.Y) * (p.X - c.X) + (a.X - c.X) * (p.Y - c.Y)) / detT;
            float l3 = 1 - l1 - l2;

            return new Vector3(l1, l2, l3);
        }
    }
}
