using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donut : MonoBehaviour
{
    private player Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<player>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Animator>().enabled = true;
            Destroy(gameObject, 0.65f);
            Player.CurrentHealth++;
            Player.Healthbar.GetComponent<hp>().UpdateHealthbar();
        }
    }
}
