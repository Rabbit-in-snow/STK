using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Duck : MonoBehaviour
{
    private Animator am;
    private bool OnStart = true;
    private GameObject player;
    private bool IsRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        am = transform.parent.GetComponent<Animator>();
        player = GameObject.Find("Player");
    }

    IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && IsRunning==false)
        {
            IsRunning = true;
            yield return new WaitForEndOfFrame();
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            if (OnStart == true)
            {
                player.GetComponent<Rigidbody2D>().MovePosition(new Vector2(transform.position.x - 0.28f, transform.position.y + 0.5f));
                yield return new WaitForFixedUpdate();
                player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                player.transform.SetParent(transform);
                am.Play("move");
                OnStart = false;
                yield return new WaitForSeconds(6.7f);
                player.transform.SetParent(null);
                transform.position = new Vector2(131f, -1.8f);
                player.transform.eulerAngles = new Vector2(0, 0);
            }
            else
            {
                player.GetComponent<Rigidbody2D>().MovePosition(new Vector2(transform.position.x + 0.28f, transform.position.y + 0.5f));
                yield return new WaitForFixedUpdate();
                player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                player.transform.SetParent(transform);
                am.Play("return");
                OnStart = true;
                yield return new WaitForSeconds(6.7f);
                player.transform.SetParent(null);
            }
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            yield return new WaitForSecondsRealtime(3f);
            IsRunning = false;
        }
    }
}
