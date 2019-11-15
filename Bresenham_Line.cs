/*
 * Bresenham直线算法。参考：https://blog.csdn.net/kakaxi2222/article/details/50708552
*/
using UnityEngine;

public static class Bresenham_Line {

    public  static void  Draw(Texture2D t, int x0,int y0,int x1,int y1)
    {
        int dx = Mathf.Abs(x1 - x0);
        int dy = Mathf.Abs(y1 - y0);

        int sx = (x1 > x0) ? 1 : -1;
        int sy = (y1 > y0) ? 1 : -1;  //默认(x0,y0)为起点。sx、sy用来标记二三四象限直线

        bool yChange = (dy > dx) ? true : false; //默认绘制0<斜率<1的直线，若不满足，下面进行dx、dy的初始交换，并在后面区别增加x、y值
        if (yChange) { int temp = dy;dy = dx;dx = temp; } //初始p值需要交换(算法要求)

        int p = 2 * dy - dx;
        int x = x0;
        int y = y0;

        for(int i = 1; i <= dx + 1; i++)
        {
            t.SetPixel(x, y, Color.red);

            if (p >= 0)  //0<斜率<1时，p>=0表示下距离>=上距离，应该绘制上面的像素点
            {
                y += sy;
                x += sx;
                p+=(2*dy-2*dx);
            }
            else
            {
                if (yChange)
                {
                    y += sy;
                }
                else
                {
                    x += sx;
                }
                p += 2 * dy;
            }
        }

        t.Apply();
    }


}
