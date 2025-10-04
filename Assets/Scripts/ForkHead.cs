using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkHead : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (GameObject.Find("Player").GetComponent<player>().attacking == false)
            {
                StartCoroutine(GameObject.Find("Player").GetComponent<player>().hurt(2));
            }
        }
        else if (collision.collider.CompareTag("sward")) { Destroy(transform.parent.gameObject); }
    }
}
