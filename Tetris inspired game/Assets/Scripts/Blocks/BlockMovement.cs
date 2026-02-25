using NodeCanvas.Framework;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    [Header("Timer")]
    [SerializeField] private float timeBeforeMovement = 2;
    private float currentTime;

    [Header("Grid Data")]
    [SerializeField] private float gridCellSize;
    [SerializeField] private GridTest grid;

    [Header("Collision")]
    [SerializeField] private LayerMask stopLayer;
    [SerializeField] private float raycastDistance;
    [SerializeField] private Vector3 sizeOffset;

    [Header("movement management")]
    [SerializeField] private bool detectedFloor = false;
    [SerializeField] private bool lineFormed = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        grid = GameObject.Find("Grid display").GetComponent<GridTest>();
    }

    private bool countUpTime(float maxTime)
    {
        currentTime += Time.deltaTime;
        //Mathf.Clamp(currentTime.value, 0, maxTime);


        if (currentTime >= maxTime)
        {
            currentTime = 0;
            return true;
        }
        else
        {
            return false;
        }
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if(!detectedFloor || lineFormed)
        {
            detectFloor();
        }
    }

    private void moveBlock()
    {
        if (countUpTime(timeBeforeMovement))
        {
            //calculate new position 
            Vector2 newPosition = new Vector2(transform.position.x, transform.position.y + -1 * gridCellSize);

            //apply position 
            transform.position = newPosition;
        }
    }


    private void detectFloor()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + sizeOffset, Vector2.down, raycastDistance, stopLayer);
        
        if(hit.collider == null || hit.transform.IsChildOf(this.transform))  
        {
            moveBlock();
        }
        else
        {
            detectedFloor = true;
            Debug.Log("hit stop");

            //run to check if the children blocks are occupied
            for (int i = 0; i < transform.childCount; i++)
            {
                grid.grid.setBlockStatus(transform.GetChild(i).transform.position,1);
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        
        Gizmos.DrawRay(transform.position + sizeOffset, Vector2.down * raycastDistance);
    }

}
