using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _驼峰站程序_V2_20161212
{
    public partial class Form1 : Form
    {
        public static List<Shape> list = new List<Shape>();//数据
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ini();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.Black);
            foreach (Shape item in list)
            {
                item.Draw(g);
            }
        }
        public void ini()
        {
            string[] lines = System.IO.File.ReadAllLines(@"ini.txt", Encoding.Default);
            foreach (string line in lines)
            {
                string[] strtArray = line.Split(' ');
                int flag = int.Parse(strtArray[0]);
                switch (flag)
                {
                    case 1://读取信号机
                        Semaphore se = new Semaphore(int.Parse(strtArray[0]), int.Parse(strtArray[1]),
                        int.Parse(strtArray[2]), int.Parse(strtArray[3]), strtArray[4],
                         new Point(int.Parse(strtArray[5]), int.Parse(strtArray[6])),
                         bool.Parse(strtArray[7]), int.Parse(strtArray[8]), bool.Parse(strtArray[9]), int.Parse(strtArray[10]));
                        list.Add(se);
                        break;
                    case 2://读取道岔
                        int[] aa = { int.Parse(strtArray[3]), int.Parse(strtArray[4]) };
                        Turnout tr = new Turnout(int.Parse(strtArray[0]), int.Parse(strtArray[1]),
                        int.Parse(strtArray[2]), aa, strtArray[5],
                        new Point(int.Parse(strtArray[6]), int.Parse(strtArray[7])),
                        int.Parse(strtArray[8]), bool.Parse(strtArray[9]), int.Parse(strtArray[10]), int.Parse(strtArray[11]));
                        list.Add(tr);
                        break;
                    case 3://读取轨道电路
                        TrackCircuit tc = new TrackCircuit(int.Parse(strtArray[0]), int.Parse(strtArray[1]),
                        int.Parse(strtArray[2]), int.Parse(strtArray[3]), strtArray[4],
                        new Point(int.Parse(strtArray[5]), int.Parse(strtArray[6])),
                        new Point(int.Parse(strtArray[7]), int.Parse(strtArray[8])),
                        new Point(int.Parse(strtArray[9]), int.Parse(strtArray[10])), int.Parse(strtArray[11]),
                        int.Parse(strtArray[12]));
                        list.Add(tc);
                        break;
                    case 4://读减速器
                        Reducer re = new Reducer(int.Parse(strtArray[0]), int.Parse(strtArray[1]),
                        int.Parse(strtArray[2]), int.Parse(strtArray[3]), strtArray[4],
                        new Point(int.Parse(strtArray[5]), int.Parse(strtArray[6])),
                        new Point(int.Parse(strtArray[7]), int.Parse(strtArray[8])),
                        int.Parse(strtArray[9]),
                        int.Parse(strtArray[10]));
                        list.Add(re);
                        break;
                    case 5://读字符
                        Sstring te = new Sstring(int.Parse(strtArray[0]), int.Parse(strtArray[1]),
                         int.Parse(strtArray[2]), int.Parse(strtArray[3]), strtArray[4],
                         new Point(int.Parse(strtArray[5]), int.Parse(strtArray[6])),
                         int.Parse(strtArray[7]),
                         int.Parse(strtArray[8]));
                        list.Add(te);
                        break;
                    default:break;
                }
            }
        }
    }

}
