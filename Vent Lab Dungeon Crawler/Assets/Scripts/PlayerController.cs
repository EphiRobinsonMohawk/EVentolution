using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField] public SpriteRenderer spriteRenderer { get; private set; }
    [field: SerializeField] public Rigidbody2D rb2d { get; private set; }
    [field: SerializeField] public float moveSpeed { get; private set; } = 10f;
    [field: SerializeField] private bool inInteractRange = false;
    [field: SerializeField] private bool dead = false;
    [field: SerializeField] public AreaInteract interactTarget { get; private set; } = null;
    [field: SerializeField] public Pickup itemHolding = null;

    [field: SerializeField] private Vector2 input;


    private void Awake()
    {
        GameMan.player = this;
    }

    // Runs each frame
    public void Update() //Input goes here
    {
        if (dead) Destroy(gameObject);


        //Movement Logic
        input.x = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            input.x = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            input.x = 1f;
        }

        input.y = 0f;

        if (Input.GetKey(KeyCode.S))
        {
            input.y = -1f;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            input.y = 1f;
        }

        input = input.normalized;



        //Interact Logic
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

    private void FixedUpdate() //Physics go here, runs every physics tick
    {
        rb2d.MovePosition(rb2d.position + input * moveSpeed * Time.fixedDeltaTime);
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
