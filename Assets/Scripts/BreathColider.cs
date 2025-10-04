using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathColider : MonoBehaviour
{
    private mob3 main;
    void Start()
    {
        main = transform.parent.Find("collider").GetComponent<mob3>();
    }
    IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (main.IsAttacked == false && main.Isdead == false)
        {
            if (collision.collider.CompareTag("Player"))
            {
                main.IsAttacked = true;
                if (main.Player.GetComponent<player>().attacking == false)
                {
                    StartCoroutine(main.Player.GetComponent<player>().hurt(1));
                }
                else { main.Health -= 1; }
                yield return new WaitForSeconds(0.1f);
                main.IsAttacked = false;
            }
            if (main.Health <= 0) { main.Isdead = true; main.am.Play("Disappear"); Destroy(transform.parent.gameObject, 1.5f); }
        }
    }
}
