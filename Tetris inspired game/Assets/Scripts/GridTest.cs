using CodeMonkey.Utils;
using System.Collections.Generic;
using UnityEngine;

public class GridTest : MonoBehaviour
{
    [SerializeField] private int x;
    [SerializeField] private int y;
    [SerializeField] private float size;
    [SerializeField] private Vector3 originPosition;
    private List<bool> occupiedArrays = new List<bool>();


    private Grid grid;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         grid = new Grid(x, y,size, originPosition);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           grid.setValueWorldPosition (UtilsClass.GetMouseWorldPosition(),56);
            
        }
        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.getGridValueWorldPosition(UtilsClass.GetMouseWorldPosition()));

        }
    }


    public void snapObjectToGrid(GameObject obj,int blockHeight)
    {
        obj.transform.position = new Vector2(obj.transform.position.x, 0 + size * blockHeight);
    }

    public void snapToCenterCell(GameObject obj, float worldPosition)
    {
        //convert to grid space, since the grid doesnt start at 0 we need to apply the offset
        float localPositionX = worldPosition - originPosition.x;
        //find closest cell
        int cellIndex = Mathf.RoundToInt(localPositionX / size);
        //return the location of the center of the closest cell
        float newPosition = originPosition.x + (cellIndex * size) + (size / 2);
        obj.transform.position= new Vector2(newPosition, obj.transform.position.y);
    }
}
