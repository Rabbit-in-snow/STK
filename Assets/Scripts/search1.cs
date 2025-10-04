using UnityEngine;

public class search1 : MonoBehaviour
{
    [SerializeField]private mob3 mob3;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && mob3.Isactive==false)
        {
            mob3.Isactive = true;
            mob3.am.Play("Attack");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(mob3.Stop());
        }
    }
}
