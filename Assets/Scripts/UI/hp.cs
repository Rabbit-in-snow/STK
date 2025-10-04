using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hp : MonoBehaviour
{
    private GameObject player;
    private Slider healthslider;
    void Start()
    {
        player = GameObject.Find("Player");
        healthslider = GetComponent<Slider>();
        UpdateHealthbar();
    }


    public void UpdateHealthbar()
    {
        healthslider.value = player.GetComponent<player>().CurrentHealth;
        healthslider.maxValue = player.GetComponent<player>().Maxhealth;
    }
}
