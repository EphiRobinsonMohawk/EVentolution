using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField] public SpriteRenderer spriteRenderer { get; private set; }
    [field: SerializeField] public Rigidbody2D rb2d { get; private set; }
    [field: SerializeField] public float moveSpeed { get; private set; } = 10f;

    [field: SerializeField] public bool inInteractRange { get; private set; } = false;
    [field: SerializeField] public AreaInteract interactTarget { get; private set; } = null;
    [field: SerializeField] public bool dead = false;

    [field: SerializeField] public Pickup itemHolding = null;

    [field: SerializeField] public Transform respawnPOS;

    [field: SerializeField] private float respawnTimer;

    [field: SerializeField] public float respawnTimerMax;




    // Runs each frame
    public void Update()
    {

        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inInteractRange && interactTarget.GetComponent<Pickup>() != null && itemHolding != null)
            {
                AreaInteract interact = itemHolding.GetComponent<AreaInteract>();
                interact.TriggerSwitch(this);
            }
            else if (inInteractRange && interactTarget!= null)
            {
                interactTarget.TriggerSwitch(this);
            }
            else if (itemHolding != null)
            {
                AreaInteract interact = itemHolding.GetComponent<AreaInteract>();
                interact.TriggerSwitch(this);
            }
        }
    }


    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Death Zone"))
        {
            dead = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            AreaInteract interact = collision.gameObject.GetComponent<AreaInteract>();
            if (interact!= null)
            {
                inInteractRange = true;
                interactTarget = interact;
            }
            
        }
           
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            Debug.Log("Left Interact Range");
            AreaInteract interact = collision.gameObject.GetComponent<AreaInteract>();
            if (interact != null && interact == interactTarget)
            {
                inInteractRange = false;
                interactTarget = null;
            }

        }
    }


}
