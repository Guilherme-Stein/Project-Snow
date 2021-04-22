using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumirPlat1 : MonoBehaviour
{
    public GameObject PlatSumir;
    public Sprite GeloTrink;
    public SpriteRenderer sprite;
    public float TempoPlatSumir;

  
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlatQuebrar();
        }
    }
    void PlatQuebrar()
    {
        TempoPlatSumir -= Time.deltaTime; 
        if (TempoPlatSumir < 2f)
        {
            sprite.sprite = GeloTrink;
            if (TempoPlatSumir <= 0)
            {
                Destroy(PlatSumir);
            }
        }
    }
}
