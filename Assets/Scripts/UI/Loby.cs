using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loby : MonoBehaviour
{
    [SerializeField] private GameObject howto;
    // Start is called before the first frame update
    void Start()
    {
        DataTransfer dataTransfer=GameObject.Find("DataTransfer").GetComponent<DataTransfer>();
        if (dataTransfer.IsFirst==false){ howto.SetActive(false); }
        else { dataTransfer.IsFirst = false; }
    }
    
}
