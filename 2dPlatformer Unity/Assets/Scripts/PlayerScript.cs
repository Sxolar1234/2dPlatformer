using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private float jumpForce = 40f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Vector3 movementPlayer;
    public bool isGroundedNigga;
    
    public Animator animator;
    public Rigidbody2D rigidbody2D;
    public Vector2 screenBounce;
    private float playerHalfWidth;
    private float playerHalfHeight;

   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerHalfWidth = GetComponent<SpriteRenderer>().bounds.extents.x; //Halbe Breite des Spielers bekommen
        playerHalfHeight = GetComponent<SpriteRenderer>().bounds.extents.y; //Halbe Höhe des Spielers bekommen
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        isGroundedNigga = isGrounded();
        movement();
        jump();
    }

    public void movement()
    {
       if(Keyboard.current.aKey.isPressed && !Keyboard.current.dKey.isPressed)
       {    
            animator.SetBool("isRunning", true); 
            movementPlayer.x = -speed * Time.deltaTime;
            spriteRenderer.flipX = true; 
       }
       if(Keyboard.current.dKey.isPressed && !Keyboard.current.aKey.isPressed)
       {    
            animator.SetBool("isRunning", true); 
            movementPlayer.x = speed * Time.deltaTime;
            spriteRenderer.flipX = false; 
       }
       
       if(!Keyboard.current.aKey.isPressed && !Keyboard.current.dKey.isPressed)
       {
            spriteRenderer.sprite = spriteRenderer.sprite; 
            movementPlayer.x = 0;
            animator.SetBool("isRunning", false); 
       } 
        transform.Translate(movementPlayer);
    }

    public void jump()
    {
        if(Keyboard.current.spaceKey.isPressed && isGrounded()) // Überprüfen, ob die Leertaste gedrückt wird und der Spieler auf dem Boden ist
        {
            rigidbody2D.linearVelocityY = jumpForce;
        }
    }

    public bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, playerHalfHeight + 0.1f, LayerMask.GetMask("Ground")); 
        return hit.collider != null;
    }
   
}
