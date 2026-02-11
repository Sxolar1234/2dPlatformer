using UnityEngine;

public class whiteMonsterScript : MonoBehaviour
{

    public logicScript logic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectsWithTag("logic")[0].GetComponent<logicScript>(); // Referenz zum Logic-Skript herstellen
    }

  

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3) // Überprüfen, ob der Spieler mit dem weißen Monster kollidiert
        {
            logic.addScore(); 
            Destroy(gameObject); // Zerstöre das weiße Monster
            
        }
    }
}
