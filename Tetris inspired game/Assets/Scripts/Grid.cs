using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;

public class Grid : MonoBehaviour
{
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private float cellSize;
    [SerializeField] private int fontSize = 10;
    private int[,] gridArray;

    public Grid (int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridArray = new int[width, height];

        Debug.Log(width + " " + height);


        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                
                UtilsClass.CreateWorldText(gridArray[x,y].ToString(),null, getWorldPosition(x,y) + new Vector3 (cellSize,cellSize) * .5f, fontSize, Color.white,TextAnchor.MiddleCenter);
                Debug.DrawLine(getWorldPosition(x, y), getWorldPosition(x, y  + 1),Color.green,1000f);
                Debug.DrawLine(getWorldPosition(x, y), getWorldPosition(x + 1, y), Color.green, 1000f);

            }
        }
        Debug.DrawLine(getWorldPosition(0,height), getWorldPosition(width, height), Color.green, 1000f);
        Debug.DrawLine(getWorldPosition(width, 0), getWorldPosition(width, height), Color.green, 1000f);
    }

    private Vector3 getWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }


}
