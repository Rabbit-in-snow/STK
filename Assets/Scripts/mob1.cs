using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mob1 : MonoBehaviour
{
    private GameObject Player;
    [SerializeField] private short Health = 2;
    private bool Isdead = false;
    private bool IsAttacked = false;
    //It called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }
    private void Update()
    {
        if (Health <= 0)
        {
            Isdead = true;
            GetComponent<Animator>().Play("Disappear");
            Destroy(gameObject, 1.5f);
        }
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
                IsAttacked=false;
            }
            else if (collision.collider.CompareTag("sward"))
            {
                IsAttacked=true;
                Health -= 1;
                yield return new WaitForSeconds(0.1f);
                IsAttacked = false;
            }
        }
    }
}
