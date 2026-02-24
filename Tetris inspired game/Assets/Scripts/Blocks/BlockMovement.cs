using NodeCanvas.Framework;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    [SerializeField] private float timeBeforeMovement = 2;
    private float currentTime;
    [SerializeField] private float gridCellSize;
    [SerializeField] private LayerMask stopLayer;
    [SerializeField] private float raycastDistance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        detectFloor();
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
        RaycastHit2D hit;
        
        if(!Physics2D.Raycast(transform.position,Vector2.down,raycastDistance,stopLayer))
        {

            /*
            if (Vector2.Distance(transform.position,hit.transform.position) > 0.5f)
            {
                
            }
            else
            {
                Debug.Log("hit floor or cube");
            }
            */
            moveBlock();
        }
        else
        {
            Debug.Log("hit stop");
        }

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector2.down * raycastDistance);
    }

}
