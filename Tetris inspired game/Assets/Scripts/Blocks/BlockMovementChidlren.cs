using UnityEngine;

public class BlockMovementChidlren : BlockMovement
{
    [SerializeField] private bool movingDebug;

    [SerializeField] protected Vector2 killboxSize;

    [SerializeField] private GameObject bloodExplosion;

    private bool alreadyPlayedAudio = false;

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
        checkForSmashedPlayer();
    }

    private void checkForSmashedPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, killboxSize,0);
        foreach (Collider2D hit in hits) 
            {
                if (hit.CompareTag("player"))
                {
                    AudioManager.playSound(SoundType.death, 1);
                    Debug.Log("kill player");
                    Destroy(hit.gameObject);
                    Instantiate(bloodExplosion, hit.transform.position, Quaternion.identity);
                }
            }

    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.green;

        Gizmos.DrawWireCube(transform.position, killboxSize);
    }

    protected override void detectFloor()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + sizeOffset, Vector2.down, raycastDistance, stopLayer);

        if (hit.collider == null)
        {
            alreadyPlayedAudio = false;
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
            alreadyPlayedAudio = true;

            grid.grid.fullLineCheck(y);



        }

    }

}
