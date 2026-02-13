using UnityEngine;

public class FireballTriggerScript : MonoBehaviour
{
    public FireballScript fireball;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fireball = GameObject.FindWithTag("fireball").GetComponent<FireballScript>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        fireball.triggered = true;
    }
}
