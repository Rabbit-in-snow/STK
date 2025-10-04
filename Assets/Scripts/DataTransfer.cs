using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DataTransfer : MonoBehaviour
{
    [SerializeField] private GameObject Isnew;
    private void Awake()
    {
        if (GameObject.Find("Isnew") == null) 
        {
            DontDestroyOnLoad(this.gameObject);
            Instantiate(Isnew, Vector2.zero,Quaternion.Euler(0,0,0));
            DontDestroyOnLoad(GameObject.Find("Isnew(Clone)"));
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public bool IsFirst = true;
    public float Speed=35;
    public short lv=3;
    public int Health = 5;
    public string xp;
    public float volume = 1;
}
