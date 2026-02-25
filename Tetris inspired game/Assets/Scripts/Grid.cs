using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Grid : MonoBehaviour
{
    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;
    private int fontSize = 10;
    private int[,] gridArray;
    

    private TextMesh[,] debugTextArray;


    public Grid (int width, int height, float cellSize, Vector3 originPosition)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new int[width, height];
        debugTextArray = new TextMesh[width, height];
       

        


        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {

                debugTextArray[x,y] = UtilsClass.CreateWorldText(gridArray[x,y].ToString(),null, getWorldPosition(x,y) + new Vector3 (cellSize,cellSize) * .5f, fontSize, Color.white,TextAnchor.MiddleCenter);
                Debug.DrawLine(getWorldPosition(x, y), getWorldPosition(x, y  + 1),Color.green,1000f);
                Debug.DrawLine(getWorldPosition(x, y), getWorldPosition(x + 1, y), Color.green, 1000f);

                
            }
        }
        Debug.DrawLine(getWorldPosition(0,height), getWorldPosition(width, height), Color.green, 1000f);
        Debug.DrawLine(getWorldPosition(width, 0), getWorldPosition(width, height), Color.green, 1000f);


        //setValue(1, 1, 56);

        //debugging test

    }

    public Vector3 getWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize + originPosition;
    }


    public void setValue(int x, int y, int value)
    {
        if( x >= 0 && y >= 0 && x < width && y< height)
        {
            gridArray[x, y] = value;
            debugTextArray[x, y].text = gridArray[x, y].ToString();
        }
        
    }

    //get the XY position to something snapped to the grid
    private void getXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);

    }

    //set the value in the cell
    public void setValueWorldPosition(Vector3 worldPosition, int value)
    {
        int x, y;
        getXY(worldPosition, out x, out y);
        setValue(x, y, value);

    }


    public void setBlockStatus(Vector2 position,int status)
    {
        int x;
        int y;
        //get the X and Y snapped to the grid
        getXY(position, out x, out y);
        //set the value there for 0 or 1
        setValue(x, y, status);
        //Vector2 worldPosition = getWorldPosition(x, y);
    }

    public bool fullLineCheck(int Y)
    {
        //checks the whole X line 
        int count = 0;

        for (int x = 0; x < width; x++)
        {
            if (gridArray[x,Y] != 0)
            {
                count++;
            }
        }
        if(count == width)
        {
            Debug.Log("clear line");
            return true;
        }
        else
        {
            return false;
        }
    }

    public void deleteFullLine(int Y, bool lineFormed)
    {
        lineFormed = true;
        for (int x = 0; x < width; x++)
        {
            //reset all of them to 0
            gridArray[x, Y] = 0;

        }
    }


    //get the value atributed to the cell 
    public int getGridValue(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        else
        {
            return 0;
        }
    }

    //returns coordinate of the cell in world position
    public int getGridValueWorldPosition(Vector3 worldPosition)
    {
        int x, y;
        getXY(worldPosition, out x, out y);
        return getGridValue(x, y);
    }

}
