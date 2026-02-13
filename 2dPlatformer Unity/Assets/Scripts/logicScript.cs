using UnityEngine;
using UnityEngine.UI;

public class logicScript : MonoBehaviour
{

    public Text scoreText;
    [SerializeField] private int score;

    void Start()
    {
        
    }
    
    void Update()
    {
        scoreText.text = "White Monster: " + score;
    }

    public int getScore()
    {
        return score;
    }

    public void setScore(int pScore)
    {
        score = pScore;
    }


    [ContextMenu("Add Score")]
    public void addScore()
    {
        score++;
    }
}
