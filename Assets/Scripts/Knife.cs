using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Knife : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (transform.rotation.y==0) { GetComponent<Rigidbody2D>().AddForce(Vector2Int.right * 20); }
        else { GetComponent<Rigidbody2D>().AddForce(Vector2Int.left * 20); }
    }
}
