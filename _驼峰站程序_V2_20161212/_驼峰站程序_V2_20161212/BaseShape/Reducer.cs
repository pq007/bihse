using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _驼峰站程序_V2_20161212
{
    /// <summary>
    /// 减速器
    /// </summary>
    class Reducer : Shape
    {
        private Point m_Namepos;     //名称坐标
        private Point m_LeftPos; //左下端点坐标

        public Reducer(int type, int Subtype, int ID, int nextid, string Name, Point pos, Point LeftPos, int flag, int yan)
        {
            M_yanhou = yan;
            M_Type = type;
            M_SubType = Subtype;
            M_Id = ID;
            M_NextID = nextid;
            M_Name = Name;
            M_Flag = flag;
            m_Namepos = pos;
            m_LeftPos = LeftPos;
        }
        public override void Draw(Graphics g)
        {
            Pen pn = new Pen(Color.Red, 2);
            Font font = new Font("粗体", 8);
            Brush b = new SolidBrush(Color.White);
            switch (M_Flag)
            {
                case 0:
                    g.DrawRectangle(pn, new Rectangle(m_LeftPos.X, m_LeftPos.Y-7, 32, 12));
                    g.DrawLine(pn, new Point(m_LeftPos.X+16, m_LeftPos.Y-6), new Point(m_LeftPos.X+16, m_LeftPos.Y+6));
                    break;
                case 1:
                    pn = new Pen(Color.Red, 1);
                    break;
                default: break;
            }
        }
    }
}
