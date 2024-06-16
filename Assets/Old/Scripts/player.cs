using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public short lv = 1;    
    public int Maxhealth;
    public int CurrentHealth;
    private Vector2 Moveing;

    public float Speed = 80f;
    private Rigidbody2D rb;
    private Animator am;
    public uint xp;
    public uint lvupxp;
    private float nohurttime = (float)0.02;
    private bool IsGround;
    [HideInInspector] public bool attacking;
    [HideInInspector] public bool IsHurt;
    private GameObject Healthbar;
    [HideInInspector]public bool Isstop=false;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = Maxhealth;
        rb = GetComponent<Rigidbody2D>();
        am = GetComponent<Animator>();
        Healthbar = GameObject.Find("health");
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth == 0)
        {
            transform.position = Vector2.zero;
            am.Play("lvup");
            CurrentHealth = Maxhealth;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (xp >= lvupxp)
        {
            am.Play("lvup");
            lv++;
            xp = 0;
            nohurttime += 0.015f;
            Maxhealth++;
            CurrentHealth++;
            Speed += 0.5f;
        }
        else if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) & IsHurt == true && attacking == false)//hurt
        {
            Moveing = new Vector2(-0.1f, 0);
            am.Play("hurt" + lv);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow) && IsHurt == false && attacking == false)//right move
        {
            Moveing = Vector2.right;
            am.Play("walk" + lv);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow) && IsHurt == true)//right move and hurt
        {
            Moveing = Vector2.right;
            am.Play("walkhurt" + lv);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow) && IsHurt == false && attacking == false)//right run
        {
            Moveing = new Vector2(2, 0);
            am.Play("run" + lv);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow) && IsHurt == true)//right run and hurt
        {
            Moveing = new Vector2(2, 0);
            am.Play("runhurt" + lv);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow) && IsHurt == false && attacking == false)//left move
        {
            Moveing = Vector2.left;
            am.Play("walk" + lv);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow) && IsHurt == true)//left move and hurt
        {
            Moveing = Vector2.left;
            am.Play("walkhurt" + lv);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow) && IsHurt == false && attacking == false)//left run
        {
            Moveing = new Vector2(-2, 0);
            am.Play("run" + lv);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow) && IsHurt == true)//left run and hurt
        {
            Moveing = new Vector2(-2, 0);
            am.Play("runhurt" + lv);
        }
        else if (IsHurt == false && attacking == true)
        {
            Moveing = Vector2.zero;
            am.Play("attack" + lv);
        }
        else
        {
           // StartCoroutine(stopm());
           // if (Isstop == false)
            //{
               // for(int i = 0; i < 2; i++)
              //  {
                    Moveing = Vector2.zero;
                    am.Play("idle" + lv);
               // }
              // }
            
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsGround == true) //jump
        {
            //Moveing = Vector2.up;
            rb.AddForce(0.03f * Speed * Vector2.up.normalized,ForceMode2D.Impulse);
        }

        //rb.AddForce(Moveing, ForceMode2D.Impulse);
        //rb.MovePosition(Moveing*Speed * Time.deltaTime + new Vector2(transform.position.x, transform.position.y));
        rb.AddForce(Moveing.normalized*Speed);
    }

    public IEnumerator stopm()
    {
        Isstop = true;
        yield return new WaitForFixedUpdate();
        yield return new WaitForEndOfFrame();

        Isstop = false;

    }
    public IEnumerator hurt(int hurtpower)
    {
            IsHurt = true;
            CurrentHealth -= hurtpower;
            yield return new WaitForSeconds(nohurttime);
            IsHurt = false;
    }

    private IEnumerable Attack()
    {
        attacking = true;
        yield return new WaitForSeconds(0.7f);
        attacking = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Grid"))
        {
            IsGround = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Grid"))
        {
            IsGround = false;
        }
    }
}