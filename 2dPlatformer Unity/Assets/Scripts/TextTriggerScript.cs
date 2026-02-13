using UnityEngine;
using UnityEngine.UI;
public class TextTriggerScript : MonoBehaviour
{
    public Text info;
    public BoxCollider2D boxCollider;
    [SerializeField] private string message = "Welcome to the game!";
    //private float timer = 5f;
    //private bool timerStarted = false;
    
    void Start()
    {
        info = GameObject.FindWithTag("info").GetComponent<Text>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
            info.text = message;
            //timerStarted = true;
    }
    /*private void Update()
    {
        if (timerStarted)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                info.text = "";
                timerStarted = false;
            }
        }
    }*/
}
