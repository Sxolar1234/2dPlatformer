using UnityEngine;
using UnityEngine.UI;

public class logicScript : MonoBehaviour
{

    public Text scoreText;
    [SerializeField] private int score;

    void Start()
    {
        
    }

    [ContextMenu("Add Score")]
    public void addScore()
    {
        score++;
        Debug.Log("Score added: " + score);
        scoreText.text = "Score: " + score; // Aktualisiere den Score-Text
    }
}
