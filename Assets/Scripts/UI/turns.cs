using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class turns : MonoBehaviour
{
    [SerializeField] private GameObject lv;
    [SerializeField] private GameObject health;
    [SerializeField] private GameObject speed;
    [SerializeField] private GameObject volume;

    // Start is called before the first frame update
    void Start()
    {
        DataTransfer dataTransfer = GameObject.Find("DataTransfer").GetComponent<DataTransfer>();
        dataTransfer.volume = volume.GetComponent<Slider>().value;
        dataTransfer.lv = (short)(lv.GetComponent<TMP_Dropdown>().value + 1);
        try { dataTransfer.Health = int.Parse(health.GetComponent<TMP_InputField>().text); }
        catch (FormatException) { dataTransfer.Health = 5; }
        try { dataTransfer.Speed = float.Parse(speed.GetComponent<TMP_InputField>().text); }
        catch (FormatException) { dataTransfer.Speed = 35f; }
        StartCoroutine(run());
    }

    private IEnumerator run() { yield return new WaitForSeconds(1f); SceneManager.LoadScene("SampleScene"); }
}
