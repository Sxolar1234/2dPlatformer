using System.Threading;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Platform_mov_Tangential : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    private bool GoingUpOrRight = false;
    private bool tax_collected = false;
    public bool unlocked = false;
    public bool firstMove = false;
    private float time = 10f;
    private bool timerStarted = false;
    private string purpose = "none";
    private bool platformWait = false;

    [SerializeField] private string platformName = "Platform...";
    [SerializeField] private float maxPosX = 10f;
    [SerializeField] private float maxPosY = 10f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private int scoreREQ = 20;
    [SerializeField] private int monster_tax = 1;

    public Text info;
    public logicScript logic;
    public BoxCollider2D boxCollider;
    public SpriteRenderer spriteRenderer;


    void Start()
    {
        startPosX = transform.position.x;
        startPosY = transform.position.y;

        info = GameObject.FindWithTag("info").GetComponent<Text>();
        logic = GameObject.FindWithTag("logic").GetComponent<logicScript>();
    }

    void Update()
    {
        if (logic.getScore() >= scoreREQ && !unlocked)
        {
            unlocked = true;
            info.text = platformName + " unlocked!";
            spriteRenderer.color = Color.green;
        }
        if (unlocked && tax_collected && !platformWait)
        {
            platform_mov();
        }


        allTimers();
    }
    
    private void platform_mov()
    {
        if (GoingUpOrRight)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            if (transform.position.x >= startPosX + maxPosX && transform.position.y >= startPosY + maxPosY)
            {
                GoingUpOrRight = false;
                platformWait = true;
                initTimer(2f, true, "platformWait");
            }
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            transform.Translate(Vector2.left * speed * Time.deltaTime);


            if (transform.position.x <= startPosX && transform.position.y <= startPosY)
            {
                GoingUpOrRight = true;
                if (!firstMove)
                {
                    initTimer(2f, true, "platformWait");
                    platformWait = true;
                }
                firstMove = false;

            }
        }


    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!tax_collected && unlocked && collision.gameObject.CompareTag("player"))
        {
            logic.setScore(logic.getScore() - monster_tax);
            tax_collected = true;
            spriteRenderer.color = Color.white;
            info.text = "-"+monster_tax+" White Monsters";
            firstMove = true;
            initTimer(1f, true, "closeInfo");
        }
        else if (!unlocked && collision.gameObject.CompareTag("player"))
        {
            info.text = "You need " + (scoreREQ - logic.getScore()) + " more";
            initTimer(5f, true, "closeInfo");
        }
    }

    public void allTimers()
    {
        switch (purpose)
        {
            case "closeInfo":
                timerResetInfo();
                break;
            case "platformWait":
                timerWaitPlatform();
                break;
        }
    }

    private void timerResetInfo()
    {
        if (timerStarted)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                timerStarted = false;
                info.text = "";
                purpose = "none";
            }
        }
    }

    private void timerWaitPlatform()
    {
        if (timerStarted)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                timerStarted = false;
                platformWait = false;
                purpose = "none";
            }
        }
    }

    private void initTimer(float pTime, bool pTimerStarted, string pPurpose)
    {
        time = pTime;
        timerStarted = pTimerStarted;
        purpose = pPurpose;
    }

}

