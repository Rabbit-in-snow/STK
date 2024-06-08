using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mob1 : MonoBehaviour
{
    private GameObject Player;
    [SerializeField]private int hurtpower=1;
    //It called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (Player.GetComponent<player>().attacking==false)
            {
                Player.GetComponent<player>().hurt(hurtpower);
            }
        }
    }
}
