using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Platform_mov_LeftRight : MonoBehaviour
{
    private float startPosX;
    private bool goingRight = false;
    private bool tax_collected = false;
    public bool unlockedLeftRight = false;

    [SerializeField] private string platformName = "Platform X";
    [SerializeField] private float maxPosX = 10f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private int scoreREQ = 5;
    [SerializeField] private int monster_tax = 1;

    public Text info;
    public logicScript logic;
    public BoxCollider2D boxCollider;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D ridgidbody2D;

    void Start()
    {
        startPosX = transform.position.x;
        info = GameObject.FindWithTag("info").GetComponent<Text>();
        logic = GameObject.FindWithTag("logic").GetComponent<logicScript>();
    }

    void Update()
    {
        if (logic.getScore() >= scoreREQ && !unlockedLeftRight)
        {
            unlockedLeftRight = true;
            info.text = platformName + " unlocked!";
            spriteRenderer.color = Color.green;
        }
        if (unlockedLeftRight && tax_collected)
        {
            platform_mov();
        }
    }

    private void platform_mov()
    {
        if (goingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            if (transform.position.x >= startPosX + maxPosX)
                goingRight = false;
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);

            if (transform.position.x <= startPosX)
                goingRight = true;
        }

    }




    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!tax_collected && unlockedLeftRight && collision.gameObject.CompareTag("player"))
        {
            logic.setScore(logic.getScore() - monster_tax);
            tax_collected = true;
            spriteRenderer.color = Color.white;
            info.text = "You paid the tax of " + monster_tax + " white monsters.";
        }
        else if (!unlockedLeftRight && collision.gameObject.CompareTag("player"))
        {
            info.text = "You need to gather " + (scoreREQ - logic.getScore()) + " more white monsters to unlocked this platform!";
        }
    }
}
