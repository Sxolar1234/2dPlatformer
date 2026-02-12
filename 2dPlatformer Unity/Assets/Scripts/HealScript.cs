using UnityEngine;

public class HealScript : MonoBehaviour
{
    public HealthLogic health;
    public logicScript logic;

    void Start()
    {
        health = GameObject.FindWithTag("health").GetComponent<HealthLogic>();
        logic = GameObject.FindWithTag("logic").GetComponent<logicScript>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3) // Überprüfen, ob der Spieler mit dem Heilungsobjekt kollidiert
        {
            health.Heal(20); // Heile den Spieler um 20 Punkte
            logic.addScore(); // Erhöhe die Punktzahl
            Destroy(gameObject); // Zerstöre das Heilungsobjekt
        }
    }
}
