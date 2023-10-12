using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIL : MonoBehaviour
{
    public int ails;
    public Text ScriptTxt;
    // Start is called before the first frame update
    void Start()
    {
        ails = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(ails>20)
        {
            GameObject.Find("Player").GetComponent<player>().lv = 4;
            GetComponent<AIL>().enabled = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("ail"))
        {
            ails++;
            if (ails > 0) { ScriptTxt.text = Convert.ToString(ails); }
        }
    }
}
