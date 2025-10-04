using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        player player = GameObject.Find("Player").GetComponent<player>();
        int xp=0;
        if (collision.CompareTag("Player"))
        {
            for (uint i = 0; i < player.reallv; i++) { xp += (int)(20 + 10 * i); }
            xp += (int)player.xp;
            try
            { GameObject.Find("DataTransfer").GetComponent<DataTransfer>().xp = xp.ToString(); }
            catch (NullReferenceException) { }
            GameObject.Find("UI Canvas").transform.Find("Fade").gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("Ending");
        }
    }
}
