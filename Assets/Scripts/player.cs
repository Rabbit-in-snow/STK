using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class player : MonoBehaviour
{
    public short lv = 1;
    public int Maxhealth;
    public int CurrentHealth;
    Vector2 Moveing;
    public float Speed = 2f;
    private Rigidbody2D rb;
    private Animator am;
    public uint xp;
    public uint lvupxp;
    private float nohurttime = (float)0.02;
    public int attackpower = 1;
    private bool IsGround;
    private int CurrentJumpFrame=0;
    [HideInInspector] public bool attacking;
    [HideInInspector] public bool IsHurt;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = Maxhealth;
        rb = GetComponent<Rigidbody2D>();
        am = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            attacking = true;
        }
        else if (!Input.GetKey(KeyCode.P))
        {
            attacking = false;
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
            attackpower++;
            Maxhealth++;
            CurrentHealth++;
            Speed+=0.5f;
        }
        else if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) & IsHurt == true && attacking == false)
        {
            am.Play("hurt" + lv);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow) && IsHurt == false && attacking == false)
        {
            Moveing = new Vector2(1, 0);
            am.Play("walk" + lv);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow) && IsHurt == true)
        {
            Moveing = new Vector2(1, 0);
            am.Play("walkhurt" + lv);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow) && IsHurt == false && attacking == false)
        {
            Moveing = new Vector2(2, 0);
            am.Play("run" + lv);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow) && IsHurt == true)
        {
            Moveing = new Vector2(2, 0);
            am.Play("runhurt" + lv);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow) && IsHurt == false && attacking == false)
        {
            Moveing = new Vector2(-1, 0);
            am.Play("walk" + lv);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow) && IsHurt == true)
        {
            Moveing = new Vector2(-1, 0);
            am.Play("walkhurt" + lv);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow) && IsHurt == false && attacking == false)
        {
            Moveing = new Vector2(-2, 0);
            am.Play("run" + lv);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow) && IsHurt == true)
        {
            Moveing = new Vector2(-2, 0);
            am.Play("runhurt" + lv);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow) && IsHurt == false && attacking == true)
        {
            Moveing = new Vector2(0, 0);
            am.Play("walkattack" + lv);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow) && IsHurt == false && attacking == true)
        {
            Moveing = new Vector2(0, 0);
            am.Play("runattack" + lv);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow) && IsHurt == false && attacking == true)
        {
            Moveing = new Vector2(0, 0);
            am.Play("walkattack" + lv);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow) && IsHurt == false && attacking == true)
        {
            Moveing = new Vector2(0, 0);
            am.Play("runattack" + lv);
        }
        else if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) & IsHurt == false && attacking == true)
        {
            Moveing = new Vector2(0, 0);
            am.Play("attack" + lv);
        }
        else
        {
            Moveing = new Vector2(0, 0);
            am.Play("idle" + lv);
        }
        if (Input.GetKeyDown(KeyCode.Space)&&IsGround==true) //jump
        {
<<<<<<< Updated upstream
            Moveing += new Vector2(0, Speed);
=======
            
            CurrentJumpFrame = 1;
            transform.position = new Vector2(transform.position.x, transform.position.y + Speed / 18 / 60);
        }
        if (CurrentJumpFrame>0&&CurrentJumpFrame<=60&&IsGround==false)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + Speed / 18 / 60);
            CurrentJumpFrame++;
        }
        else if (IsGround == true)
        {
            CurrentJumpFrame = 0;
>>>>>>> Stashed changes
        }

        rb.MovePosition(new Vector2(transform.position.x, transform.position.y) + Speed * Time.deltaTime * Moveing.normalized);
    }

    public IEnumerator hurt(int hurtpower)
    {
        IsHurt = true;
        CurrentHealth -= hurtpower;
        yield return new WaitForSeconds(nohurttime);
        IsHurt = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Grid"))
        {
            IsGround= true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Grid"))
        {
            IsGround= false;
        }
    }
}