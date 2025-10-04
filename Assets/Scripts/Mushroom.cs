using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    private player Player;
    private bool IsEaten = false;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<player>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && IsEaten==false)
        {
            IsEaten=true;
            transform.parent.GetComponent<AudioSource>().Play();
            transform.parent.GetComponent<Animator>().enabled = true;
            Destroy(transform.parent.gameObject, 0.65f);
            Player.SpeedUp=+ 2.5f;
            Player.CurrentHealth--;
            Player.Healthbar.GetComponent<hp>().UpdateHealthbar();
        }
    }
}
