/*
 * DDA直线算法。参考：https://www.cnblogs.com/asahiLikka/p/11580714.html
*/
using UnityEngine;

public static class DDA_Line {

    public static void Draw(Texture2D t, int x0, int y0, int x1, int y1)
    {
        int dx = x1 - x0;
        int dy = y1 - y0;

        int steps = (Mathf.Abs(dx) >= Mathf.Abs(dy)) ? Mathf.Abs(dx) : Mathf.Abs(dy);

        if (steps == 0) return;

        float deltaX = (float)dx / steps;
        float delatY = (float)dy / steps;

        float x = x0;
        float y = y0;

        for (int i = 1; i <= steps + 1; i++)
        {
            x += deltaX;
            y += delatY;
            t.SetPixel(Mathf.FloorToInt(x),Mathf.FloorToInt(y), Color.blue);
        }

        t.Apply();

    }
	
}
