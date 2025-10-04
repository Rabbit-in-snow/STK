using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class mob3 : MonoBehaviour
{
    [HideInInspector]public GameObject Player;
    [HideInInspector]public Animator am;
    public short Health = 8;
    [SerializeField] private GameObject Grid;
    [HideInInspector] public bool Isactive = false;
    [HideInInspector]public bool Isdead = false;
    [HideInInspector]public bool IsAttacked = false;
    [SerializeField] private GameObject search;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        am = transform.parent.GetComponent<Animator>();
        am.Play("flew");
    }
    public IEnumerator Stop()
    {
        yield return new WaitForSeconds(5f);
        Isactive = false;
        am.Play("flew");
    }
    IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (IsAttacked == false && Isdead == false)
        {
            if (collision.collider.CompareTag("Player"))
            {
                IsAttacked = true;
                if (Player.GetComponent<player>().attacking == false)
                {
                    StartCoroutine(Player.GetComponent<player>().hurt(1));
                }
                else { Health -= 1; }
                yield return new WaitForSeconds(0.1f);
                IsAttacked = false;
            }
            else if (collision.collider.CompareTag("sward"))
            {
                IsAttacked = true;
                Health -= 1;
                yield return new WaitForSeconds(0.1f);
                IsAttacked = false;
            }
            if (Health <= 0) { Isdead = true; am.Play("Disappear"); Destroy(search); Destroy(transform.parent.gameObject, 1.5f); }
        }
    }
}
