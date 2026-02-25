using NodeCanvas.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    [Header("Timer")]
    [SerializeField] protected float timeBeforeMovement = 2;
    protected float currentTime;

    [Header("Grid Data")]
    [SerializeField] protected float gridCellSize;
    [SerializeField] protected GridTest grid;

    [Header("Collision")]
    [SerializeField] protected LayerMask stopLayer;
    [SerializeField] protected float raycastDistance;
    [SerializeField] protected Vector3 sizeOffset;

    [Header("movement management")]
    [SerializeField] protected bool detectedFloor = false;
    [SerializeField] protected bool lineFormed = false;
    [SerializeField] protected BlockMovement ParentBlockMovement;
    [SerializeField] protected List<BlockMovement> childBlockMovement;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        grid = GameObject.Find("Grid display").GetComponent<GridTest>();
    }

    protected virtual bool countUpTime(float maxTime)
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



    private void setChildrenScriptActive()
    {
        foreach(BlockMovement child in childBlockMovement)
        {
            child.enabled = true;   
            child.detectedFloor = true;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(!detectedFloor || lineFormed)
        {
            detectFloor();
        }
        else
        {
            Debug.Log("cant move");
        }
    }

    protected virtual void moveBlock()
    {
        if (countUpTime(timeBeforeMovement))
        {
            //calculate new position 
            Vector2 newPosition = new Vector2(transform.position.x, transform.position.y + -1 * gridCellSize);

            //apply position 
            transform.position = newPosition;
        }
    }


    private bool checkChildrenFloor()
    {
       for (int i = 0; i<transform.parent.childCount; i++) 
       {
           BlockMovement childBlockMovement = transform.parent.GetChild(i).GetComponent<BlockMovement>();
            if (childBlockMovement.lineFormed == true)
            {
                return true;
            }
     
       }
       return false;
    }


    protected virtual void detectFloor()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + sizeOffset, Vector2.down, raycastDistance, stopLayer);
        
        if(hit.collider == null)  
        {
            moveBlock();
        }
        else
        {
            
            detectedFloor = true;
            ParentBlockMovement.enabled = false;
            setChildrenScriptActive();
            for (int i = 0; i < transform.childCount; i++)
            {
                grid.grid.setBlockStatus(transform.GetChild(i).transform.position, 1);
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        
        Gizmos.DrawRay(transform.position + sizeOffset, Vector2.down * raycastDistance);
    }

}
