using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    private Texture2D background;

    private static int BUTTON_HEIGHT = 50;
    private int w = Screen.width;
    private int h = Screen.height- BUTTON_HEIGHT;

    private void Awake()
    {
        background = new Texture2D(w,h) ;
        SetTextureWhite(background);
    }


    private void OnGUI()
    {

        if (GUI.Button(new Rect(0, 0, 100, 40), "BresenhamLine"))
        {
            SetTextureWhite(background);
            BresenhanmLineTest();
        }

        if (GUI.Button(new Rect(130, 0, 100, 40), "DDALine"))
        {
            SetTextureWhite(background);
            DDALineTest();
        }

        if (GUI.Button(new Rect(260, 0, 150, 40), "BresenhamCircle"))
        {
            SetTextureWhite(background);
            BresenhamCircleTest();
        }

        //绘制
        Rect rect = new Rect(0, BUTTON_HEIGHT, w,h);
        GUI.DrawTexture(rect, background);   
    }


    private void SetTextureWhite(Texture2D t)
    {
        for(int i = 0; i < w; i++)
        {
            for(int j = 0; j < h; j++)
            {
                t.SetPixel(i,j,Color.white);
            }
        }
        t.Apply();
    }


    private void BresenhanmLineTest()
    {
        //在背景上绘制直线，随机产生5组点
        for (int i = 0; i < 5; i++)
        {
            Point p1 = new Point(Random.Range(0, w), Random.Range(0, h));
            Point p2 = new Point(Random.Range(0, w), Random.Range(0, h));
            Bresenham_Line.Draw(background, p1.x, p1.y, p2.x, p2.y);
        }
    }


    private void DDALineTest()
    {
        for (int i = 0; i < 5; i++)
        {
            Point p1 = new Point(Random.Range(0, w), Random.Range(0, h));
            Point p2 = new Point(Random.Range(0, w), Random.Range(0, h));
            DDA_Line.Draw(background, p1.x, p1.y, p2.x, p2.y);
        }
    }


    private void BresenhamCircleTest()
    {
        for(int i = 0; i < 5; i++)
        {
            Point p=new Point(Random.Range(0, w), Random.Range(0, h));
            int r = Random.Range(1, Mathf.Min(w - p.x, p.x, h - p.y, p.y));
            Bresenham_Circle.Draw(background, r, p.x, p.y);
        }
    }
}



public struct Point
{
    public int x;
    public int y;
    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}