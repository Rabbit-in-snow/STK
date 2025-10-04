using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class xp : MonoBehaviour
{
    private player player;
    private Slider xpslider;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<player>();
        xpslider = GetComponent<Slider>();
    }

    private void Update()
    {
        xpslider.value = player.xp;
    }

    public void Updatexpbar()
    {
        xpslider.maxValue = player.GetComponent<player>().lvupxp;
    }
}
