using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _驼峰站程序_V2_20161212
{
    abstract public class Shape
    {

        public int M_Type;//类型码
        public int M_SubType;//子类型码
        public int M_Id;//ID号
        public String M_Name;//名称
        public Point M_Point;//画图点
        public int M_NextID;//下一个
        public int M_Flag;//颜色标志
        public int M_yanhou;//咽喉区判断
        public abstract void Draw(Graphics g);//绘图方法
    }
}
