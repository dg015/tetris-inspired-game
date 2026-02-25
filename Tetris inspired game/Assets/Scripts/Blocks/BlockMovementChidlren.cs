using UnityEngine;

public class BlockMovementChidlren : BlockMovement
{
    [SerializeField] protected BlockMovement childBlockMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        childBlockMovement.enabled = false;
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
