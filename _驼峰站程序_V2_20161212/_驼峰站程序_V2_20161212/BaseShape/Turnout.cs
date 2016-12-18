using System.Drawing;

namespace _驼峰站程序_V2_20161212
{
    /// <summary>
    /// 道岔
    /// </summary>
    class Turnout : Shape
    {
        private int m_Direction;//岔尖方向
        private bool m_state;//定反位--可变
        public int[] nextid;

        public int Direction
        {
            get
            {
                return m_Direction;
            }

            set
            {
                m_Direction = value;
            }
        }

        public Turnout(int Type, int SubType, int ID, int[] nextid, string Name, Point Point, int Direction,bool State, int Flag,int yan)
        {
            this.nextid = nextid;
            M_yanhou = yan;
            M_Type = Type;
            M_SubType = SubType;
            M_Id = ID;
            M_Name = Name;
            M_Point = Point;
            this.Direction = Direction;
            m_state = State;
            if (State)
            {
                M_NextID = nextid[0];
            }
            else
            {
                M_NextID = nextid[1];
            }
            M_Flag = Flag;
        }
        public override void Draw(Graphics g)
        {
            if (m_state)
            {
                M_NextID = nextid[0];
            }
            else
            {
                this.M_NextID = nextid[1];
            }
            Pen pn = new Pen(Color.Green,2);//画笔

            Font font = new Font("粗体", 10);

            Brush b = new SolidBrush(Color.Black);//画刷
            
            switch (M_SubType)
            {
                case 1://单动道岔
                    if (m_state)//定位
                    {
                        switch (m_Direction)
                        {
                            case 1://岔开方向左上
                                g.DrawLine(new Pen(Color.Blue,2), M_Point, new Point(M_Point.X - 20, M_Point.Y - 20));
                                break;
                            case 2://岔开方向右下
                                g.DrawLine(new Pen(Color.Blue,2), M_Point, new Point(M_Point.X - 20, M_Point.Y + 20));
                                break;
                        }
                        g.DrawLine(pn, new Point(M_Point.X - 20, M_Point.Y), new Point(M_Point.X + 20, M_Point.Y));
                    }
                    else
                    {
                        g.DrawLine(new Pen(Color.Blue, 2), new Point(M_Point.X - 20, M_Point.Y), new Point(M_Point.X , M_Point.Y));
                        switch (m_Direction)
                        {
                            case 1://岔开方向左上
                                g.DrawLines(pn,new Point[3] { new Point(M_Point.X +20, M_Point.Y ), new Point(M_Point.X , M_Point.Y) , new Point(M_Point.X - 20, M_Point.Y-20) });
                                break;
                            case 2://岔开方向右下
                                g.DrawLines(pn, new Point[3] { new Point(M_Point.X + 20, M_Point.Y), new Point(M_Point.X, M_Point.Y), new Point(M_Point.X - 20, M_Point.Y + 20) });
                                break;
                        }
                    }
                    break;
                case 2://双动道岔
                    string[] strtArray = M_Name.Split(',');
                    string M_Name_f = strtArray[0];
                    string M_Name_s = strtArray[1];
                    switch (Direction)
                    {
                        case 1://叉尖左下角
                            g.DrawString(M_Name_f, font, Brushes.White, new PointF(M_Point.X - 2, M_Point.Y - 13));
                            g.DrawString(M_Name_s, font, Brushes.White, new PointF(M_Point.X + 50, M_Point.Y - 63));
                            g.DrawLine(pn, new Point(M_Point.X - 20, M_Point.Y), new Point(M_Point.X + 70, M_Point.Y));
                            g.DrawLines(pn, new Point[4] { new Point(M_Point.X - 20, M_Point.Y), M_Point, new Point(M_Point.X + 50, M_Point.Y - 50), new Point(M_Point.X + 90, M_Point.Y - 50) });
                            if (M_Flag==1)//接车
                            {
                                g.DrawLine(new Pen(Color.Red), new Point(M_Point.X - 20, M_Point.Y), new Point(M_Point.X + 70, M_Point.Y));
                                g.DrawLines(new Pen(Color.Red), new Point[4] { new Point(M_Point.X - 20, M_Point.Y), M_Point, new Point(M_Point.X + 50, M_Point.Y - 50), new Point(M_Point.X + 90, M_Point.Y - 50) });
                            }
                            if (M_Flag == 2)//发车
                            {
                                g.DrawLine(new Pen(Color.Yellow), new Point(M_Point.X - 20, M_Point.Y), new Point(M_Point.X + 70, M_Point.Y));
                                g.DrawLines(new Pen(Color.Yellow), new Point[4] { new Point(M_Point.X - 20, M_Point.Y), M_Point, new Point(M_Point.X + 50, M_Point.Y - 50), new Point(M_Point.X + 90, M_Point.Y - 50) });
                            }
                            if (M_Flag == 3)//调车
                            {
                                g.DrawLine(new Pen(Color.Green), new Point(M_Point.X - 20, M_Point.Y), new Point(M_Point.X + 70, M_Point.Y));
                                g.DrawLines(new Pen(Color.Green), new Point[4] { new Point(M_Point.X - 20, M_Point.Y), M_Point, new Point(M_Point.X + 50, M_Point.Y - 50), new Point(M_Point.X + 90, M_Point.Y - 50) });
                            }
                            break;
                        case 2://叉尖左上角
                            g.DrawString(M_Name_f, font, Brushes.White, new PointF(M_Point.X - 2, M_Point.Y - 13));
                            g.DrawString(M_Name_s, font, Brushes.White, new PointF(M_Point.X + 50, M_Point.Y + 37));
                            g.DrawLine(pn, new Point(M_Point.X - 20, M_Point.Y), new Point(M_Point.X + 30, M_Point.Y));
                            g.DrawLines(pn, new Point[4] { new Point(M_Point.X - 20, M_Point.Y), M_Point, new Point(M_Point.X + 50, M_Point.Y + 50), new Point(M_Point.X + 80, M_Point.Y + 50) });
                            if (M_Flag == 1)//定位
                            {
                                g.DrawLine(new Pen(Color.Red), new Point(M_Point.X - 20, M_Point.Y), new Point(M_Point.X + 30, M_Point.Y));
                                g.DrawLines(new Pen(Color.Red), new Point[4] { new Point(M_Point.X - 20, M_Point.Y), M_Point, new Point(M_Point.X + 50, M_Point.Y + 50), new Point(M_Point.X + 80, M_Point.Y + 50) });
                            }
                            if (M_Flag == 2)//定位
                            {
                                g.DrawLine(new Pen(Color.Yellow), new Point(M_Point.X - 20, M_Point.Y), new Point(M_Point.X + 30, M_Point.Y));
                                g.DrawLines(new Pen(Color.Yellow), new Point[4] { new Point(M_Point.X - 20, M_Point.Y), M_Point, new Point(M_Point.X + 50, M_Point.Y + 50), new Point(M_Point.X + 80, M_Point.Y + 50) });
                            }
                            if (M_Flag == 3)//定位
                            {
                                g.DrawLine(new Pen(Color.Green), new Point(M_Point.X - 20, M_Point.Y), new Point(M_Point.X + 30, M_Point.Y));
                                g.DrawLines(new Pen(Color.Green), new Point[4] { new Point(M_Point.X - 20, M_Point.Y), M_Point, new Point(M_Point.X + 50, M_Point.Y + 50), new Point(M_Point.X + 80, M_Point.Y + 50) });
                            }
                            break;
                        case 3://叉尖右上角
                            g.DrawString(M_Name_f, font, Brushes.White, new PointF(M_Point.X - 2, M_Point.Y - 13));
                            g.DrawString(M_Name_s, font, Brushes.White, new PointF(M_Point.X + 50, M_Point.Y - 63));
                            g.DrawLine(new Pen(Color.White), new Point(M_Point.X - 30, M_Point.Y), new Point(M_Point.X + 20, M_Point.Y));
                            g.DrawLines(new Pen(Color.White), new Point[4] { new Point(M_Point.X - 30, M_Point.Y), M_Point, new Point(M_Point.X + 50, M_Point.Y - 50), new Point(M_Point.X + 80, M_Point.Y - 50) });
                            if (M_Flag == 1)//定位
                            {
                                g.DrawLine(new Pen(Color.Red), new Point(M_Point.X - 20, M_Point.Y), new Point(M_Point.X + 30, M_Point.Y));
                                g.DrawLines(new Pen(Color.Red), new Point[4] { new Point(M_Point.X - 20, M_Point.Y), M_Point, new Point(M_Point.X + 50, M_Point.Y + 50), new Point(M_Point.X + 80, M_Point.Y + 50) });
                            }
                            if (M_Flag == 2)//定位
                            {
                                g.DrawLine(new Pen(Color.Yellow), new Point(M_Point.X - 20, M_Point.Y), new Point(M_Point.X + 30, M_Point.Y));
                                g.DrawLines(new Pen(Color.Yellow), new Point[4] { new Point(M_Point.X - 20, M_Point.Y), M_Point, new Point(M_Point.X + 50, M_Point.Y + 50), new Point(M_Point.X + 80, M_Point.Y + 50) });
                            }
                            if (M_Flag == 3)//定位
                            {
                                g.DrawLine(new Pen(Color.Green), new Point(M_Point.X - 20, M_Point.Y), new Point(M_Point.X + 30, M_Point.Y));
                                g.DrawLines(new Pen(Color.Green), new Point[4] { new Point(M_Point.X - 20, M_Point.Y), M_Point, new Point(M_Point.X + 50, M_Point.Y + 50), new Point(M_Point.X + 80, M_Point.Y + 50) });
                            }
                            break;
                        case 4://叉尖右上角
                            g.DrawString(M_Name_f, font, Brushes.White, new PointF(M_Point.X - 2, M_Point.Y - 13));
                            g.DrawString(M_Name_s, font, Brushes.White, new PointF(M_Point.X + 50, M_Point.Y + 37));
                            g.DrawLine(new Pen(Color.White), new Point(M_Point.X - 30, M_Point.Y), new Point(M_Point.X + 30, M_Point.Y));
                            g.DrawLines(new Pen(Color.White), new Point[4] { new Point(M_Point.X - 30, M_Point.Y), M_Point, new Point(M_Point.X + 50, M_Point.Y + 50), new Point(M_Point.X + 80, M_Point.Y + 50) });

                            break;
                    }
                    break;
            }
        }
    }
}
