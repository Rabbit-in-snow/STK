using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Silder class 사용하기 위해 추가합니다.

public class hp : MonoBehaviour
{
    GameObject obj;
    private int temps;
    void Start()
    {

    }


    void Update()
    {
        temps = GameObject.Find("Player").GetComponent<Health>().currentHP;
        GameObject.Find("slihp").GetComponent<Slider>().value = temps;
    }
}
