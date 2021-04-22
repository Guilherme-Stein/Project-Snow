using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AtivarNeblinaFixa : MonoBehaviour
{
    private D2FogsPE d2;
    private AtivarNeblina ativarNeblina;
    // Start is called before the first frame update
    void Start()
    {
        ativarNeblina = FindObjectOfType(typeof(AtivarNeblina)) as AtivarNeblina;
        d2 = FindObjectOfType(typeof(D2FogsPE)) as D2FogsPE;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Neblina")
        {
            d2.Density = 1.5f;
            d2.HorizontalSpeed = 0.7F;
            ativarNeblina.enabled = false;
        }

        if (collision.gameObject.tag == "DesabNevoa")
        {
            d2.Density = 0.4f;
            d2.HorizontalSpeed = 0.2F;
            ativarNeblina.enabled = true;
        }
    }

}
