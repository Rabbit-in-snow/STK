using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIL : MonoBehaviour
{
    public uint ails;
    public Text ScriptTxt;
    private player player;
    // Start is called before the first frame update
    void Start()
    {
        ails = 0;
        player = GameObject.Find("Player").GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ails>20)
        {
            player.xp = player.lvupxp;
            ails = 0; 
            //GetComponent<AIL>().enabled = false;
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
