using UnityEngine;

public class PoisonScript : MonoBehaviour
{
    public HealthLogic health;
    public logicScript logic;
    private float timer = 0f;
    private bool isPoisoned = false;

     void Start()
    {
        health = GameObject.FindWithTag("health").GetComponent<HealthLogic>();
        logic = GameObject.FindWithTag("logic").GetComponent<logicScript>();
    }
    

    void Update()
    {
        timer += Time.deltaTime;
        if((timer > 3f) && isPoisoned) 
        {
            health.TakeDamage(10);  
            timer = 0f; 
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3) 
        {
            isPoisoned = true; 
            health.TakeDamage(10);
            timer = 0f;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3) 
        {
            isPoisoned = false; 
        }
    }
}
