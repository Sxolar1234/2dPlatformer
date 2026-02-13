using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Platform_mov_Tangential : MonoBehaviour
{
     private float startPosX;
     private float startPosY;
    private bool goingTangential = false;
    private bool tax_collected = false;
    public bool unlockedTangential = false;

    [SerializeField] private string platformName = "Platform Tangential";
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
        if (logic.getScore() >= scoreREQ && !unlockedTangential)
        {
            unlockedTangential = true;
            info.text = platformName + " unlocked!";
            spriteRenderer.color = Color.green;
        }
        if (unlockedTangential && tax_collected)
        {
            platform_mov();
        }
    }

    private void platform_mov()
    {
        if (goingTangential)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
           transform.Translate(Vector2.right * speed * Time.deltaTime);

            if (transform.position.x >= startPosX + maxPosX && transform.position.y >= startPosY + maxPosY)
                goingTangential = false;
        }
        else
        {
           transform.Translate(Vector2.down * speed * Time.deltaTime);
           transform.Translate(Vector2.left * speed * Time.deltaTime);


            if (transform.position.x <= startPosX && transform.position.y <= startPosY)
                goingTangential = true;
        }

    }




    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!tax_collected && unlockedTangential && collision.gameObject.CompareTag("player"))
        {
            logic.setScore(logic.getScore() - monster_tax);
            tax_collected = true;
            spriteRenderer.color = Color.white;
            info.text = "You paid the tax of " + monster_tax + " white monsters.";
        }
        else if (!unlockedTangential && collision.gameObject.CompareTag("player"))
        {
            info.text = "You need to gather " + (scoreREQ - logic.getScore()) + " more white monsters to unlocked this platform!";
        }
    }
}
