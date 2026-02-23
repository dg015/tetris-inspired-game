using UnityEngine;
using CodeMonkey.Utils;

public class GridTest : MonoBehaviour
{
    [SerializeField] private int x;
    [SerializeField] private int y;
    [SerializeField] private float size;
    [SerializeField] private Vector3 originPosition;

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
}
