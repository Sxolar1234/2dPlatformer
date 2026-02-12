using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    public HealthLogic health;
    public Rigidbody2D playerRigidbody;
    void Start()
    {
       health = GameObject.FindWithTag("health").GetComponent<HealthLogic>(); 
       playerRigidbody = GameObject.FindWithTag("player").GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("player"))
        {
            health.TakeDamage();
            launchPlayer();
        }
    }

    public void launchPlayer()
    {
        playerRigidbody.linearVelocity = new Vector2(0, 10); 
    }
}
