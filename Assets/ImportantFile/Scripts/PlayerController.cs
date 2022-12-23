using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Код игрока
public class PlayerController : MonoBehaviour
{
    private float horizontalValue;
    private float verticalValue;
    public float moveSpeed = 1f;


    private int page_unlock;
    private bool Open_Page = false;
    
    private Vector2 movementInput;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Animator animator;


    public GameObject[] pages;
    public GameObject Page;
    public GameObject Logo;
    PopUpManager popup;
    public AnimUiTAB BoxTab;


    public DataForTrigger pageData;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        popup = GameObject.FindGameObjectWithTag("PopUp").GetComponent<PopUpManager>();
    }

    //Открытие книги и Работа с инвентарем
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            BoxTab.CloseBox();
            Logo.SetActive(false);
            if (!Open_Page)
            {
                Page.SetActive(true);
                Open_Page = true;
            }
            else
            {
                Page.SetActive(false);
                Open_Page = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            popup.CallPopUp("Вам сообщили по рации выйти через другую клеть", 3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            popup.CallPopUp("Вы надели респиратор", 3);
        }
    }

    //Анимация и Поворот персонажа влево или права
    private void FixedUpdate()
    {
        ProcessInputs();
        if (movementInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (movementInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        if (movementInput != Vector2.zero)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }

    //Ходьба Персонажа
    void ProcessInputs()
    {

        horizontalValue = Input.GetAxisRaw("Horizontal");
        verticalValue = Input.GetAxisRaw("Vertical");
        movementInput = new Vector2(horizontalValue, verticalValue);
        movementInput.Normalize();
        if (movementInput != Vector2.zero)
        {
            rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
        }
    }

    //Тригер на появление правил на экране и в книге
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Trigger")
        {
            pageData.trig = other.gameObject;
            page_unlock = int.Parse(pageData.trig.name);
            if (pageData.page[page_unlock - 1] == 0)
                StartCoroutine(Rules());
        }
    } 

    public IEnumerator Rules()
    {
        pageData.page[page_unlock - 1] = 1;
        popup.CallPopUp(pageData.QuestionText[page_unlock - 1], 3);
        Logo.SetActive(true);
        yield return new WaitForSeconds(1f);
        //popup.CallPopUp("У вас новое правило!", 3);
    }
}
