using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class end : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(run());
    }

    private IEnumerator run() 
    {
        yield return new WaitForSeconds(20f);
        try
        { GameObject.Find("XP").GetComponent<TextMeshProUGUI>().text = "점수: " + GameObject.Find("DataTransfer").GetComponent<DataTransfer>().xp; }
        catch (NullReferenceException) { GameObject.Find("XP").GetComponent<TextMeshProUGUI>().text = "점수를 불러오지 못함"; }
        yield return new WaitForSeconds(20f);
        Destroy(GameObject.Find("Directional Light/Sound"));
        SceneManager.LoadScene("Loby"); 
    }
}
