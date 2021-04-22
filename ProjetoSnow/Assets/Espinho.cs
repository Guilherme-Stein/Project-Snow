using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinho : MonoBehaviour
{
    public float velocidade = 10;
    Vector2 direcao;

    private espinhoRed esp;

    private void Start()
    {
        esp = FindObjectOfType(typeof(espinhoRed)) as espinhoRed;
    }
    private void Update()
    {
        
        direcao = new Vector2(0f, 0.5f);
        transform.Translate(direcao * velocidade * Time.deltaTime);
        if (transform.position.y < -12)
        {
            Destroy(gameObject);
            Instantiate(esp.Esp, esp.localEsp.position, esp.localEsp.rotation);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
           Destroy(gameObject);
           Instantiate(esp.Esp, esp.localEsp.position, esp.localEsp.rotation);
        }
    }


}
