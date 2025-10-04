using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class player : MonoBehaviour
{
    public short lv = 1;    
    public int Maxhealth;
    public int CurrentHealth;
    private Vector2 Moving;
    [SerializeField] private GameObject knife;

    public short reallv;
    private bool first = true;
    public float Speed;
    private Rigidbody2D rb;
    private Animator am;
    public uint xp;
    public uint lvupxp;
    private float nohurttime = (float)0.02;
    [SerializeField]private bool IsGround;
    [HideInInspector] public bool attacking;
    [HideInInspector] public bool IsHurt;
    public GameObject Healthbar;
    private GameObject Xpbar;
    private TextMeshProUGUI lvscreen;
    [HideInInspector]public bool Isstop=false;
    private AudioSource au;
    private Transform Spawn;
    [SerializeField]private Audiozone backau;
    [SerializeField] private BoxCollider2D colli;
    [HideInInspector] public float SpeedUp = 0f;
    private bool IsDead=false;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        lv = 2;
        Maxhealth = 4 + lv;
        Speed = 35f;
#else
        DataTransfer dataTransfer = GameObject.Find("DataTransfer").GetComponent<DataTransfer>();
        Maxhealth = dataTransfer.Health;
        lv = dataTransfer.lv;
        Speed = dataTransfer.Speed;
#endif
        CurrentHealth = Maxhealth;
        rb = GetComponent<Rigidbody2D>();
        am = GetComponent<Animator>();
        Healthbar = GameObject.Find("health");
        Healthbar.GetComponent<hp>().UpdateHealthbar();
        Xpbar = GameObject.Find("XP");
        lvscreen = GameObject.Find("LV").GetComponent<TextMeshProUGUI>();
        reallv = lv;
        lvscreen.text = reallv.ToString();
        au = GetComponent<AudioSource>();
        Spawn = GameObject.Find("SpawnPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead == false && CurrentHealth <= 0) { StartCoroutine(Respawn()); }
        if (Input.GetKeyDown(KeyCode.P) && attacking == false)
        {
            StartCoroutine(Attack());
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (IsDead == true) { rb.velocity = Vector2.zero; }
        else if (xp >= lvupxp)
        {
            reallv++;
            lvscreen.text = reallv.ToString();
            if (lv < 3) { lv++; }
            am.Play("lvup");
            xp -= lvupxp;
            nohurttime += 0.015f;
            Maxhealth++;
            CurrentHealth++;
            Speed += 5f;
            lvupxp += 10;
            Xpbar.GetComponent<xp>().Updatexpbar();
            Healthbar.GetComponent<hp>().UpdateHealthbar();
        }
        #region
        else
        {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
            if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow) & IsHurt == true && attacking == false)//hurt
            {
                Moving = new Vector2(-0.1f, 0);
                am.Play("hurt" + lv);
            }
            else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow) && IsHurt == false && attacking == false)//right move
            {
                Moving = Vector2.right;
                am.Play("walk" + lv);
            }
            else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow) && IsHurt == true)//right move and hurt
            {
                Moving = Vector2.right;
                am.Play("walkhurt" + lv);
            }
            else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow) && IsHurt == false && attacking == false && IsGround == true)//right run
            {
                Moving = new Vector2(2, 0);
                am.Play("run" + lv);
            }
            else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow) && IsHurt == true && IsGround == true)//right run and hurt
            {
                Moving = new Vector2(2, 0);
                am.Play("runhurt" + lv);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow) && IsHurt == false && attacking == false)//left move
            {
                Moving = Vector2.left;
                am.Play("walk" + lv);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow) && IsHurt == true)//left move and hurt
            {
                Moving = Vector2.left;
                am.Play("walkhurt" + lv);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow) && IsHurt == false && attacking == false && IsGround == true)//left run
            {
                Moving = new Vector2(-2, 0);
                am.Play("run" + lv);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow) && IsHurt == true && IsGround == true)//left run and hurt
            {
                Moving = new Vector2(-2, 0);
                am.Play("runhurt" + lv);
            }
            else if (IsHurt == false && attacking == true)
            {
                am.Play("attack" + lv);
            }
            else
            {
                Moving = Vector2.zero;
                Speed += SpeedUp;
                SpeedUp = 0;
                am.Play("idle" + lv);
            }
            if (Input.GetKeyDown(KeyCode.Space) && IsGround == true) //jump
            {
                rb.AddForce(0.06f * Speed * Vector2.up, ForceMode2D.Impulse);
                au.Play();
            }
#endif
            rb.AddForce(Moving * Speed);
        }
#endregion
    }

    public IEnumerator hurt(int hurtpower)
    {
            IsHurt = true;
            CurrentHealth -= hurtpower;
            Healthbar.GetComponent<hp>().UpdateHealthbar();
            yield return new WaitForSeconds(nohurttime);
            IsHurt = false;
    }

    private IEnumerator Attack()
    {
        attacking = true;
        if (lv >= 3) 
        {
            if (transform.rotation.y == 0) { Instantiate(knife, new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), Quaternion.Euler(-90, 0, 0)); }
            else { Instantiate(knife, new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z), Quaternion.LookRotation(new Vector3(0,-1,-1))); }
        }
        yield return new WaitForSeconds(0.7f);
        attacking = false;
    }
    private IEnumerator Respawn()
    {
        IsDead = true;
        yield return new WaitForSecondsRealtime(5f);
        IsDead = false;
        transform.position = Spawn.position;
        backau.OnTriggerEnter2D(colli);
        am.Play("lvup");
        CurrentHealth = Maxhealth;
        xp = 0;
        Healthbar.GetComponent<hp>().UpdateHealthbar();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Grid")) //&& collision.contacts[0].normal.y==1)
        {
            IsGround = true;
            if (first==false) { Speed -= 25f; }
            else { first = false; }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("dea")) { CurrentHealth = 0; }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Grid"))
        {
            IsGround = false;
            Speed += 25f;
        }
    }
}