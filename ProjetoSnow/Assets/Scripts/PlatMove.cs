using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatMove : MonoBehaviour
{
    public float p1,p2,speed,mover = 1f;
    Vector2 Direcao;
    public Transform playerTrans;
    public GameObject player;

  
 

    // Update is called once per frame
    void Update()
    {
        Direcao = new Vector2(0f, speed * mover);
        transform.Translate(Direcao * speed * Time.deltaTime);
        if (transform.position.y > p2)
        {
            mover = -1f;
        }
        else if (transform.position.y < p1)
        {
            mover = 1f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.transform.parent = playerTrans.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.transform.parent = null;
        }
    }

}
