using UnityEngine;

public class FireballScript : MonoBehaviour
{

    public HealthLogic health;
    public logicScript logic;
    [SerializeField]private float speed = 35f;
    public bool triggered = false;

    void Awake()
    {
        health = GameObject.FindWithTag("health").GetComponent<HealthLogic>();
        logic = GameObject.FindWithTag("logic").GetComponent<logicScript>();
    }


    // Update is called once per frame
    void Update()
    {
        if (triggered) { transform.Translate(Vector2.left * Time.deltaTime * speed); }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            health.TakeDamage(20);
            Destroy(gameObject);
        }
    }
}
