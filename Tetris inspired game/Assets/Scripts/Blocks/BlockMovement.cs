using NodeCanvas.Framework;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    [SerializeField] private float timeBeforeMovement = 2;
    private float currentTime;
    [SerializeField] private float gridCellSize;

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
        if (countUpTime(timeBeforeMovement))
        {
            //calculate new position 
            Vector2 newPosition = new Vector2(transform.position.x , transform.position.y + -1 * gridCellSize);

            //apply position 
            transform.position = newPosition;
        }
    }
}
