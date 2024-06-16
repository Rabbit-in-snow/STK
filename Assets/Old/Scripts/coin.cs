using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.R))
    //    {
    //        GetComponent<Animation>().Stop("tokenidle");
    //        GetComponent<Animation>().Play("tokendisappear");
    //        GameObject.Find("Player").GetComponent<player>().xp++;
    //        gameObject.SetActive(false);
    //    }
    //}
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GetComponent<Animator>().Play("tokendisappear");
            GameObject.Find("Player").GetComponent<player>().xp++;
            gameObject.SetActive(false);
        }
    }
}
