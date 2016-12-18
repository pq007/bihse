using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _驼峰站程序_V2_20161212
{
    class Sstring : Shape
    {
        private Point m_Namepos;     //名称坐标
        public Sstring(int type, int Subtype, int ID, int nextid, string Name, Point pos, int flag, int yan)
        {
            M_yanhou = yan;
            M_Type = type;
            M_SubType = Subtype;
            M_Id = ID;
            M_NextID = nextid;
            M_Name = Name;
            M_Flag = flag;
            m_Namepos = pos;
        }
        public override void Draw(Graphics g)
        {
            Pen pn = new Pen(Color.Red, 20);
            Font font = new Font("粗体", 10);
            Brush b = new SolidBrush(Color.Yellow);
            g.DrawString(M_Name, font,b, m_Namepos);
        }
    }
}
