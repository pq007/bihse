using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace _驼峰站程序_V2_20161212
{
    /// <summary>
    /// 信号机
    /// </summary>
    class Semaphore : Shape
    {
        [DllImport("User32")]
        public extern static bool GetCursorPos(ref Point lpPoint);//用于点击信号机
        private bool m_Direction;//方向
        private bool m_size;//高柱矮柱 

        public Semaphore(int Type, int SubType, int ID, int nextid, string Name, Point Point, bool Direction, int Flag, bool Size, int yan)
        {
            M_yanhou = yan;
            M_Type = Type;
            M_SubType = SubType;
            M_Id = ID;
            M_Name = Name;
            M_Point = Point;
            M_NextID = nextid;
            m_Direction = Direction;
            M_Flag = Flag;
            m_size = Size;
        }
     
        public override void Draw(Graphics g)
        {
            Pen pn = new Pen(Color.White,2);//画笔

            Font font = new Font("粗体", 10);

            switch (M_SubType)
            {
                case 1://驼峰主信号机
                    Rectangle r2 = new Rectangle(M_Point.X - 23, M_Point.Y + 3, 16, 16);
                    g.DrawEllipse(pn, r2);
                    g.DrawLine(pn, new Point(M_Point.X, M_Point.Y + 3), new Point(M_Point.X, M_Point.Y + 19));
                    g.DrawLine(pn, new Point(M_Point.X, M_Point.Y + 11), new Point(M_Point.X - 6, M_Point.Y + 11));
                    switch (M_Flag)//根据不同的信号状态显示不同的颜色
                    {
                        case 0://平时状态--红
                            g.FillEllipse(Brushes.Yellow, r2);
                            break;
                        default: break;
                    }
                    break;

                case 2://驼峰调车信号机
                    if (m_Direction)
                    {
                        Rectangle r1 = new Rectangle(M_Point.X, M_Point.Y - 20, 16, 16);
                        g.DrawEllipse(pn, r1);
                        switch (M_Flag)//根据不同的信号状态显示不同的颜色
                        {
                            case 0://平时状态--红
                                g.FillEllipse(Brushes.Blue, r1);
                                break;
                            default: break;
                        }
                        g.DrawLine(pn, new Point(M_Point.X, M_Point.Y - 3), new Point(M_Point.X, M_Point.Y - 19));
                    }
                    else
                    {
                        Rectangle r1 = new Rectangle(M_Point.X - 17, M_Point.Y + 3 , 16, 16);
                        g.DrawEllipse(pn, r1);
                        switch (M_Flag)//根据不同的信号状态显示不同的颜色
                        {
                            case 0://平时状态--红
                                g.FillEllipse(Brushes.Blue, r1);
                                break;
                            default: break;
                        }
                        g.DrawLine(pn, new Point(M_Point.X, M_Point.Y + 3), new Point(M_Point.X, M_Point.Y + 19));
                    }
                        break;
                case 3://斜放的驼峰调车信号机
                    if (m_Direction)
                    {
                        Rectangle r1 = new Rectangle(M_Point.X+7, M_Point.Y - 9, 16, 16);
                        g.DrawEllipse(pn, r1);
                        switch (M_Flag)//根据不同的信号状态显示不同的颜色
                        {
                            case 0://平时状态--红
                                g.FillEllipse(Brushes.Blue, r1);
                                break;
                            default: break;
                        }
                        g.DrawLine(pn, new Point(M_Point.X+2, M_Point.Y -2), new Point(M_Point.X+13, M_Point.Y - 13));
                    }
                    else
                    {
                        Rectangle r1 = new Rectangle(M_Point.X +7, M_Point.Y-6 , 16, 16);
                        g.DrawEllipse(pn, r1);
                        switch (M_Flag)//根据不同的信号状态显示不同的颜色
                        {
                            case 0://平时状态--红
                                g.FillEllipse(Brushes.Blue, r1);
                                break;
                            default: break;
                        }
                        g.DrawLine(pn, new Point(M_Point.X+2, M_Point.Y+2 ), new Point(M_Point.X+15, M_Point.Y + 15));
                    }
                    break;

            }

        }
        public  void  IsInBox(Point mouse_point,string semaName)
        {
            if (m_Direction)//正向-从左向右
            {
                if (mouse_point.X > M_Point.X && mouse_point.X < M_Point.X + 24 && mouse_point.Y > M_Point.Y - 14 && mouse_point.Y < M_Point.Y)//基点周围的一个正方形
                {
                    MessageBox.Show(semaName);
                }
            }
            else//反向
            {
                if (mouse_point.X > M_Point.X - 14  && mouse_point.X < M_Point.X && mouse_point.Y > M_Point.Y && mouse_point.Y < M_Point.Y + 14)//基点周围的一个正方形
                {
                    MessageBox.Show(semaName);
                }
            }
        }
    }
}
