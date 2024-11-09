using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics2
{
    public class Vertex
    {
        
        public Vector3 actualPoint;
        public Vector3 pu;
        public Vector3 pv;
        public Vector3 N;
        public double u;
        public double v;
        public Vector3 I;
        public float X
        {
            get
            {
                return actualPoint.X;
            }
        }
        public float Y
        {
            get
            {
                return actualPoint.Y;
            }
        }
        public float Z
        {
            get
            {
                return actualPoint.Z;
            }
        }
        public Vertex(Vector3 point, Vector3 pu, Vector3 pv ,double u, double v)
        {
            actualPoint = point;
            this.u = u;
            this.v = v;
            this.pu = pu;
            this.pv = pv;
            N = Vector3.Cross(pu, pv);
            N = Vector3.Normalize(N);
        }
    }
}
