using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private float jumpForce = 100f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    public Animator animator;
    public Rigidbody2D ridgidbody2D;
    public Vector2 screenBounce;
    private float playerHalfWidth;
    private float playerHalfHeight;

   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ridgidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        screenBounce = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)); //Größe des Bildschirms bekommen
        playerHalfWidth = GetComponent<SpriteRenderer>().bounds.extents.x; //Halbe Breite des Spielers bekommen
        playerHalfHeight = GetComponent<SpriteRenderer>().bounds.extents.y; //Halbe Höhe des Spielers bekommen
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        movement();
        //ScreenBounce();
        jump();
    }

    public void movement()
    {
       if(Keyboard.current.aKey.isPressed && !Keyboard.current.dKey.isPressed)
       {    
            animator.SetBool("isRunning", true); // Laufanimation starten
            ridgidbody2D.linearVelocity = new Vector3(-speed, ridgidbody2D.linearVelocity.y, 0);
            spriteRenderer.flipX = true; // Spieler nach links drehen
       }
       if(Keyboard.current.dKey.isPressed && !Keyboard.current.aKey.isPressed)
       {    
            animator.SetBool("isRunning", true); // Laufanimation starten
            ridgidbody2D.linearVelocity = new Vector3(speed, ridgidbody2D.linearVelocity.y, 0);
            spriteRenderer.flipX = false; // Spieler nach rechts drehen
       }
       
       if(!Keyboard.current.aKey.isPressed && !Keyboard.current.dKey.isPressed)
       {
            ridgidbody2D.linearVelocity = new Vector2(0, ridgidbody2D.linearVelocity.y);
            spriteRenderer.sprite = spriteRenderer.sprite; 
            animator.SetBool("isRunning", false); // Laufanimation stoppen
       } 
    }

    public void ScreenBounce()
    {
        float clampedX = Mathf.Clamp(transform.position.x, -screenBounce.x + playerHalfWidth, screenBounce.x - playerHalfWidth); //Spieler innerhalb der Bildschirmgrenzen halten
        Vector2 pos = transform.position;
        pos.x = clampedX;
        transform.position = pos;
    }

    public void jump()
    {
        if(Keyboard.current.spaceKey.isPressed && isGrounded()) // Überprüfen, ob die Leertaste gedrückt wird und der Spieler auf dem Boden ist
        {
            ridgidbody2D.linearVelocity = new Vector3(ridgidbody2D.linearVelocity.x, jumpForce,0); // Spieler nach oben springen lassen
        }
    }

    public bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, playerHalfHeight + 0.1f, LayerMask.GetMask("Ground")); 
        return hit.collider != null;
    }
   
}
