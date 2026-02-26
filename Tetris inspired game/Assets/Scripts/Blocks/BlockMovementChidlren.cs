using UnityEngine;

public class BlockMovementChidlren : BlockMovement
{
    [SerializeField] private bool movingDebug;
    public bool DetectedFloor
    {
        get { return detectedFloor; }
        set { detectedFloor = value; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        grid = GameObject.Find("Grid display").GetComponent<GridTest>();
        detectFloor();
    }

    private void disabledChildScript()
    {
        for (int i = 0; i < childBlockMovement.Count; i++) 
        {
            childBlockMovement[i].enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        /*
        if (!detectedFloor || lineFormed)
        {
            
        }
        else
        {
            Debug.Log("cant move");
        }
        */
        detectFloor();
    }

    protected override void detectFloor()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + sizeOffset, Vector2.down, raycastDistance, stopLayer);

        if (hit.collider == null)
        {
            moveBlock();
            movingDebug = true;
        }
        else
        {
            detectedFloor = true;
            ParentBlockMovement.enabled = false;
            grid.grid.setBlockStatus(transform.position, 1);
            int x;
            int y;
            grid.grid.getXY(transform.position, out x, out y);


            grid.grid.fullLineCheck(y);
        }
    }

}
