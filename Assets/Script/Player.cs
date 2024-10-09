using System.Collections;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 Moveing;
    [HideInInspector]public bool IsHurt=false;
    [HideInInspector]public bool attacking = false;
    private Rigidbody rb;
    public float Speed = 5f;
    [SerializeField] private bool IsGround;
    private float h=0;    private float v = 0;    private float y = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");
        }
        else if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.W)) { v = 1f; }
            if (Input.GetKey(KeyCode.S)) { v = -1f; }
            if (Input.GetKey(KeyCode.A)) { h = -1f; }
            if (Input.GetKey(KeyCode.D)) { h = 1f; }
        }
        else { h = 0;v = 0; }
        if (IsGround == true && Input.GetKey(KeyCode.Space)) { y = 1;}
        else { y = 0; }

        Moveing = 1000 * Speed * new Vector3(h, y * 3, v);
        rb.AddForce(Moveing * Time.deltaTime);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Grid")) { IsGround = true; }
    }
     void OnCollisionExit(Collision collision)
     {
        if (collision.collider.CompareTag("Grid"))   { IsGround = false; }
     }
}
