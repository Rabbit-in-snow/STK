using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knifecollider : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Grid")) { transform.parent.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic; Destroy(transform.parent.gameObject, 5f); }
        else { GetComponent<BoxCollider2D>().isTrigger = true; Destroy(transform.parent.gameObject, 5f); }
    }
}
