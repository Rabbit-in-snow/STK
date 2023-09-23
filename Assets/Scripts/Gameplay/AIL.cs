using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIL : MonoBehaviour
{
    public int ails;
    public Text ScriptTxt;
    public int coins;
    // Start is called before the first frame update
    void Start()
    {
        ails = 0;
        coins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(ails>10)
        {
            Debug.Log("ails");
            ails = 0;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("ail"))
        {
            ails++;
            if(ails < 1) { ScriptTxt.text = ""; }
            else ScriptTxt.text = Convert.ToString(ails);
        }
        else if (collision.collider.gameObject.CompareTag("coin"))
        {
            coins++;
        }
    }
}
