using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Animator>().Play("tokendisappear");
            GameObject.Find("Player").GetComponent<player>().xp++;
            Destroy(gameObject,0.65f);
        }
    }
}
