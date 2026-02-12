using UnityEngine;
using UnityEngine.UI;

public class logicScript : MonoBehaviour
{

    public Text scoreText;
    [SerializeField] private int score;

    void Start()
    {
        
    }

    public int getScore()
    {
        return score;
    }

    [ContextMenu("Add Score")]
    public void addScore()
    {
        score++;
        Debug.Log("Score added: " + score);
        scoreText.text = "White Monster: " + score; // Aktualisiere den Score-Text
    }
}
