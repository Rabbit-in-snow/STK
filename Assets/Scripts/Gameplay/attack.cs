using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    public int strong = 1;
    public bool attacking = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightShift) == true)
        {
            attacking = true;
        }
        else if (Input.GetKey(KeyCode.RightShift) == false) { attacking = false; }
    }
}
