using UnityEngine;

public class KillboxScript : MonoBehaviour
{
    public HealthLogic health;
    public BoxCollider2D boxCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = GameObject.FindWithTag("health").GetComponent<HealthLogic>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
       health.Die();
    }
}
