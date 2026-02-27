using UnityEngine;

public class SelfDestructEmpty : MonoBehaviour
{
    [SerializeField] protected GridTest grid;



    private void Start()
    {
        grid = GameObject.Find("Grid display").GetComponent<GridTest>();
    }

    // Update is called once per frame
    void Update()
    {
        destoryIfEmpty();
        destroyIfOutBounds();
    }

    private void destoryIfEmpty()
    {
        if (gameObject.transform.childCount == 0)
        {
            Debug.Log("empty");
            Destroy(gameObject);
        }
    }

    private void destroyIfOutBounds()
    {
        int x;
        int y;
        grid.grid.getXY(transform.position, out x, out y);

        if(x >= grid.x || y >= grid.y + 1 || x < 0 || y < 0)
        {
            Debug.Log("out of bounds");
            Destroy(gameObject);
        }

    }

}
