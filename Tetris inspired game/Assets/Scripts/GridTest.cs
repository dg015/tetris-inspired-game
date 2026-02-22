using UnityEngine;

public class GridTest : MonoBehaviour
{
    [SerializeField] private int x;
    [SerializeField] private int y;
    [SerializeField] private float size;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Grid grid = new Grid(x, y,size);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
