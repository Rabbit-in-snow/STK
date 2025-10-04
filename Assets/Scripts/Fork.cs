using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fork : MonoBehaviour
{
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Player.transform.position.x - transform.position.x, Player.transform.position.y - transform.position.y).normalized * 20f);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (Player.GetComponent<player>().attacking == false)
            {
                StartCoroutine(Player.GetComponent<player>().hurt(1));
            }
        }
        else if (collision.collider.CompareTag("Grid"))
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
            Destroy(gameObject, 30f);
        }
        else if (collision.collider.CompareTag("sward")) { Destroy(gameObject); }
    }
}
