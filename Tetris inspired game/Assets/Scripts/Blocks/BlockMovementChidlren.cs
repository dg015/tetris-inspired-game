using UnityEngine;

public class BlockMovementChidlren : BlockMovement
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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


    protected override void detectFloor()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + sizeOffset, Vector2.down, raycastDistance, stopLayer);

        if (hit.collider == null)
        {
            moveBlock();
        }
        else
        {
            detectedFloor = true;
            ParentBlockMovement.enabled = false;
            grid.grid.setBlockStatus(transform.position, 1);
        }
    }

}
