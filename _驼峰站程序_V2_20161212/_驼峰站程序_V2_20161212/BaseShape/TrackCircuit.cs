using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace _驼峰站程序_V2_20161212
{
    /// <summary>
    ///轨道电路区段 
    /// </summary>
    class TrackCircuit : Shape
    {
        private Point m_Namepos;     //名称坐标
        private Point m_LeftPos; //左端点坐标
        private Point m_RightPos;//右端点坐标

        public TrackCircuit(int type,int Subtype, int ID ,int nextid,string Name,Point pos, Point LeftPos, Point RightPos,int flag, int yan)
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
            m_RightPos = RightPos;
        }
        /// <summary>
        /// 绘制轨道区段
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            Pen pn = new Pen(Color.White, 2);
            Font font = new Font("粗体", 8);
            Brush b = new SolidBrush(Color.White);
          //  g.DrawString(M_Name, font, b, m_Namepos);
           
            switch (M_Flag)
            {
                case 0:
                    g.DrawLine(pn, new Point(m_LeftPos.X, m_LeftPos.Y), new Point(m_RightPos.X, m_RightPos.Y));
                    break;
                case 1:
                    pn = new Pen(Color.Red, 1);
                    g.DrawLine(pn, new Point(m_LeftPos.X, m_LeftPos.Y), new Point(m_RightPos.X, m_RightPos.Y));
                    break;
                default:break;
            }
            
        }
    }
}
