using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] private Collider2D doorCollider;
    public bool gameEnd;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorCollider = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player") == true)
        {
            Debug.Log("wong the game");
            gameEnd = true;
        }
    }

}
