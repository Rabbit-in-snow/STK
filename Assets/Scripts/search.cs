using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class search : MonoBehaviour
{
    void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.CompareTag("Player") && transform.parent.GetComponent<mob2>().Isactive==false)
        {
            StartCoroutine(transform.parent.GetComponent<mob2>().Move());
        }
    }

    void OnTriggerExit2D(UnityEngine.Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StopCoroutine(transform.parent.GetComponent<mob2>().Move());
            StartCoroutine(transform.parent.GetComponent<mob2>().Stop());
        }
    }
}
