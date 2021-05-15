using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ComGrafLab3
{
    class Point3
    {
        public int x; 
        public int y; 
        public int z;
        public Point3 (int tx, int ty, int tz)
        {
            x = tx; y = ty; z = tz;
        }
        public Point3()
        {
            x = 0; y = 0; z = 0;
        }
    }

    class Cube
    {
        public List<Point3> pnts3= new List<Point3>();
        public Point3 C;
        public Cube()
        {
            pnts3.Add(new Point3(100, -100, -100));
            pnts3.Add(new Point3(-100, -100, -100));
            pnts3.Add(new Point3(-100, 100, -100));
            pnts3.Add(new Point3(100, 100, -100));

            pnts3.Add(new Point3(100, -100, 100));
            pnts3.Add(new Point3(-100, -100, 100));
            pnts3.Add(new Point3(-100, 100, 100));
            pnts3.Add(new Point3(100, 100, 100));
            C = new Point3(0, 0, 0);
        }
        public void Rotx(int angel)
        {
            int ty = 0, tz = 0;
            foreach (var item in pnts3)
            {
                ty += item.y;
                tz += item.z;
            }
            C = new Point3(0, ty/pnts3.Count,tz/pnts3.Count);
            foreach (var item in pnts3)
            {
                ty = item.y; tz = item.z;
                item.y = (int)(C.y + (ty - C.y) * Math.Cos(Math.PI * angel / 180) - (tz - C.z) * Math.Sin(Math.PI * angel / 180));
                item.z = (int)(C.z + (ty - C.y) * Math.Sin(Math.PI * angel / 180) + (tz - C.z) * Math.Cos(Math.PI * angel / 180));
            }
        }

        public void Roty(int angel)
        {
            int tx = 0, tz = 0;
            foreach (var item in pnts3)
            {
                tx += item.x;
                tz += item.z;
            }
            C = new Point3(tx / pnts3.Count, 0, tz / pnts3.Count);
            foreach (var item in pnts3)
            {
                tx = item.x; tz = item.z;
                item.x = (int)(C.x + (tx - C.x) * Math.Cos(Math.PI * angel / 180) - (tz - C.z) * Math.Sin(Math.PI * angel / 180));
                item.z = (int)(C.z + (tx - C.x) * Math.Sin(Math.PI * angel / 180) + (tz - C.z) * Math.Cos(Math.PI * angel / 180));
            }
        }

        public void Rotz(int angel)
        {
            int tx = 0, ty = 0;
            foreach (var item in pnts3)
            {
                tx += item.x;
                ty += item.y;
            }
            C = new Point3(tx / pnts3.Count, ty / pnts3.Count, 0);
            foreach (var item in pnts3)
            {
                tx = item.x; ty = item.y;
                item.x = (int)(C.x + (tx - C.x) * Math.Cos(Math.PI * angel / 180) - (ty - C.y) * Math.Sin(Math.PI * angel / 180));
                item.y = (int)(C.x + (tx - C.x) * Math.Sin(Math.PI * angel / 180) + (ty - C.y) * Math.Cos(Math.PI * angel / 180));
            }
        }
        //scale move dx dy 0z

        public void Scale(double zoom)
        {
            int tx = 0, ty = 0, tz = 0;
            foreach (var item in pnts3)
            {
                tx += item.x;
                ty += item.y;
                tz += item.z;
            }
            C = new Point3(tx / pnts3.Count, ty / pnts3.Count, 0);
            foreach (var item in pnts3)
            {
                tx = item.x; ty = item.y; tz = item.z;
                item.x = (int)(C.x + zoom * (tx - C.x));
                item.y = (int)(C.y + zoom * (tx - C.y));
                item.z = (int)(C.z + zoom * (tx - C.z));
            }
        }

        private List<Point> Point3to2(int x, int y)
        {   
            List<Point> points = new List<Point>();
            foreach (var item in pnts3)
            {
                points.Add(new Point((int)(x-item.x+item.y/(2*Math.Sqrt(2))), (int)(y-item.z + item.y / (2 * Math.Sqrt(2)))));
            }
            return points;
        }

        public void Draw(Graphics gh, Pen pen, int height, int width)
        {
            List<Point> pnts = Point3to2(width/2, height/2);

            gh.DrawLine(pen, pnts[0], pnts[1]);
            gh.DrawLine(pen, pnts[1], pnts[2]);
            gh.DrawLine(pen, pnts[2], pnts[3]);
            gh.DrawLine(pen, pnts[3], pnts[0]);
            
            gh.DrawLine(pen, pnts[4], pnts[5]);
            gh.DrawLine(pen, pnts[5], pnts[6]);
            gh.DrawLine(pen, pnts[6], pnts[7]);
            gh.DrawLine(pen, pnts[7], pnts[4]);
            
            gh.DrawLine(pen, pnts[0], pnts[4]);
            gh.DrawLine(pen, pnts[1], pnts[5]);
            gh.DrawLine(pen, pnts[2], pnts[6]);
            gh.DrawLine(pen, pnts[3], pnts[7]);
        }


    }
}
