using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Donuts : MonoBehaviour
{
    [SerializeField] GameObject[] Variation;
    // Start is called before the first frame update
    void Start()
    {
        Transform[] child = GetComponentsInChildren<Transform>();
        for (int i = 1; i < child.Length; i++)
        {
            Instantiate(Variation[Random.Range(0, Variation.Length)], child[i].position, child[i].rotation, transform);
            Destroy(child[i].gameObject);
        }
    }
}
