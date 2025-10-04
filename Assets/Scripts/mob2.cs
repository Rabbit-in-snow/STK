using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class mob2 : MonoBehaviour
{
    private GameObject Player;
    [SerializeField] private GameObject fork;
    private Animator am;
    [SerializeField] private short Health = 5;
    [SerializeField] private GameObject Grid;
    [HideInInspector] public bool Isactive = false;
    private bool Isdead = false;
    private bool IsAttacked = false;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        am = GetComponent<Animator>();
        am.Play("flew");
    }
    public IEnumerator Move()
    {
        Isactive = true;
        while (Isactive)
        {
            am.Play("walk");
            yield return new WaitForSeconds(6.5f);
            Instantiate<GameObject>(fork, new Vector2(transform.position.x - 0.6f, transform.position.y - 0.7f), Quaternion.Euler(0, 0, Mathf.Atan2(Player.transform.position.y - transform.position.y - 0.7f, Player.transform.position.x - transform.position.x - 0.6f) * Mathf.Rad2Deg - 0.2f));
            yield return new WaitForSeconds(2.6f);
        }
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
            if (Health <= 0) { Isdead = true; GetComponent<Animator>().Play("Disappear"); Destroy(gameObject, 1.5f); }
        }
    }
}
