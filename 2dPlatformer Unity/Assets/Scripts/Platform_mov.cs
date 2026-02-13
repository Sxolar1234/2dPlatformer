using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Platform_mov : MonoBehaviour
{
    private float startPosY;
    private bool goingUp = false;

    [SerializeField] private float maxPos = 10f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private int scoreREQ = 5;
    [SerializeField] private int monster_tax = 1;
    [SerializeField] private bool tax_collected = false;

    //public Text anzahl;
    public logicScript logic;
    public BoxCollider2D boxCollider;

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


   

   public void OnCollisionEnter2D(Collision2D collision)
   {
      if (collision.gameObject.CompareTag("player") && !tax_collected)
      {
          logic.setScore(logic.getScore() - monster_tax);
          tax_collected = true;
      }
   }
}
