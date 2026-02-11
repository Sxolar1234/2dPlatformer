using UnityEngine;
using UnityEngine.UI;

public class HealthlLogic : MonoBehaviour
{
    private float healthAmount = 100f;
    public Image healthBar;
    

    [ContextMenu("Take Damage")]
    public void TakeDamage()
    {
        healthAmount -= 20; 
        healthBar.fillAmount = healthAmount / 100f; // Aktualisiere die Gesundheitsleiste
        if (healthAmount <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Player died!"); // Hier kannst du weitere Aktionen hinzufügen, z.B. Neustart des Levels
    }

    public void Heal(int healAmount)
    {
        healthAmount += healAmount;
        if (healthAmount > 100)
        {
            healthAmount = 100; // Maximaler Gesundheitswert
        }
        healthBar.fillAmount = healthAmount / 100f; // Aktualisiere die Gesundheitsleiste
    }
}
