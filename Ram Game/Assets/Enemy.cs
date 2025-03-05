using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Transform pointA;
    public Transform pointB;
    bool goA = true;
    float speed = 1f;
    bool followPlayer = false;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        pointA.parent = null;
        pointB.parent = null;
        pointA.GetComponent<SpriteRenderer>().enabled = false;
        pointB.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!followPlayer) {
            if (goA)
            {
                Debug.DrawLine(transform.position, pointA.position, Color.red);
                if (Vector2.Distance(transform.position, pointA.position) > 0.1f)
                    transform.Translate((pointA.position - transform.position).normalized * Time.deltaTime * speed, Space.World);
                else goA = false;

            }
            else
            {
                Debug.DrawLine(transform.position, pointB.position, Color.green);
                if (Vector2.Distance(transform.position, pointB.position) > 0.1f)
                    transform.Translate((pointB.position - transform.position).normalized * Time.deltaTime * speed, Space.World);
                else goA = true;
            }
        }
        else
        {
            transform.Translate((player.position - transform.position) * Time.deltaTime * speed * 10, Space.World);
          
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player = collision.transform;
            followPlayer = true;
            player.GetComponent<PlayerController>().GameOver();
        }
    }
}
