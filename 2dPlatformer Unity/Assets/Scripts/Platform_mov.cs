using UnityEngine;
using UnityEngine.UI;

public class Platform_mov : MonoBehaviour
{
    private float startPosY;
    private bool goingUp = false;

    [SerializeField] private float maxPos = 10f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private int scoreREQ = 1;
    //public Text anzahl; 
    public logicScript logic;

    void Start()
    {
        startPosY = transform.position.y;
        //anzahl = GameObject.FindWithTag("whiteMonster").GetComponent<Text>();
        logic = GameObject.FindWithTag("logic").GetComponent<logicScript>();
    }

    void Update()
    { 
        if (logic.getScore() >= scoreREQ)
        { 
        platform_mov();
        }
    }
    
    private void platform_mov()
    {
        if (goingUp)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);

            if (transform.position.y >= startPosY + maxPos)
                goingUp = false;
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);

            if (transform.position.y <= startPosY)
                goingUp = true;
        }
    }
}
