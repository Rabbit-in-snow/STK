using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSetUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        try { GetComponent<AudioSource>().volume = GameObject.Find("DataTransfer").GetComponent<DataTransfer>().volume; }
        catch (NullReferenceException) { GetComponent<AudioSource>().volume = 0.5f; }
    }
}
