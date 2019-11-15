/*
 * Bresenham画圆算法。参考：https://blog.csdn.net/sinat_41104353/article/details/82961824
*/
using UnityEngine;

public static class Bresenham_Circle {
    
    //以Bresenham做第一象限上1/8圆，其他通过轴对称进行变换得到
    public static void Draw(Texture2D t,int r,int centerX,int centerY)
    {
        //第一点应该是(0,r)，获得判别式初始值p
        int p = 3 - 2 * r;

        int x = 0, y = r;

        for (; x <= y;x++)
        {
            //绘制像素，要考虑轴对称和平移，所以有八个象限，顺时针计
            t.SetPixel(x + centerX, y + centerY, Color.black); //1
            t.SetPixel(x + centerX, -y + centerY, Color.black); //4
            t.SetPixel(-x + centerX, y + centerY, Color.black); //8
            t.SetPixel(-x + centerX, -y + centerY, Color.black); //5
            t.SetPixel(y + centerX, x + centerY, Color.black);//2
            t.SetPixel(y + centerX, -x + centerY, Color.black);//3
            t.SetPixel(-y + centerX, x + centerY, Color.black);//7
            t.SetPixel(-y + centerX, -x + centerY, Color.black);//6

            //通过判别式确定下一步y值，并更新判别式
            if (p >=0) // p=上距离-下距离，因此p>=0，表示要取下方的像素点
            {
                p += (4 * (x - y) + 10);
                y--;
            }
            else
            {
                p += (4 * x + 6);                
            }
        }

        t.Apply();
    }
}
