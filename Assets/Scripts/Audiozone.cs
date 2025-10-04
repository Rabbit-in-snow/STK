using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiozone : MonoBehaviour
{
    [SerializeField]private AudioClip audioClip;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            transform.parent.GetComponent<AudioSource>().clip = audioClip;
            transform.parent.GetComponent<AudioSource>().Play();
        }
    }
}
