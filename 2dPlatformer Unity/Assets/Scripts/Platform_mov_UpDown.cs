using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Platform_mov : MonoBehaviour
{
    private float startPosY;
    private bool goingUp = false;
    private bool tax_collected = false;
    public bool unlockedUpDown = false;

    [SerializeField] private string platformName = "Platform Y";
    [SerializeField] private float maxPosY = 10f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private int scoreREQ = 10;
    [SerializeField] private int monster_tax = 1;
    
    public Text info;
    public logicScript logic;
    public BoxCollider2D boxCollider;
    public SpriteRenderer spriteRenderer;


    void Start()
    {
        startPosY = transform.position.y;
        info = GameObject.FindWithTag("info").GetComponent<Text>();
        logic = GameObject.FindWithTag("logic").GetComponent<logicScript>();
    }

    void Update()
    {
        if (logic.getScore() >= scoreREQ && !unlockedUpDown)
        {
            unlockedUpDown = true;
            info.text = platformName + " unlocked!";
            spriteRenderer.color = Color.green;
        }
        if (unlockedUpDown && tax_collected)
        {
            platform_mov();
        }
    }

    private void platform_mov()
    {
        if (goingUp)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);

            if (transform.position.y >= startPosY + maxPosY)
                goingUp = false;
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);

            if (transform.position.y <= startPosY)
                goingUp = true;
        }

    }




    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!tax_collected && unlockedUpDown && collision.gameObject.CompareTag("player"))
        {
            logic.setScore(logic.getScore() - monster_tax);
            tax_collected = true;
            spriteRenderer.color = Color.white;
            info.text = "You paid the tax of " + monster_tax + " white monsters.";
        }
        else if (!unlockedUpDown && collision.gameObject.CompareTag("player"))
        {
            info.text = "You need to gather " + (scoreREQ - logic.getScore()) + " more white monsters to unlocked this platform!";
        }
    }
}
