using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AtivarNeblina : MonoBehaviour
{
    private D2FogsPE d2;
    public float tempNeb; //Tempo de neblina
    bool tempAtiv = false;
    // Start is called before the first frame update
    void Start()
    {
        d2 = FindObjectOfType(typeof(D2FogsPE)) as D2FogsPE;
    }

    // Update is called once per frame
    void Update()
    {

        if (tempAtiv == true)
        {
            d2.Density = tempNeb -= Time.deltaTime;
            if (tempNeb <=0f)
            {
                tempAtiv = false;
                //d2.Density = 0.5f;
               // d2.HorizontalSpeed = 0.2F;
                tempNeb = 0f;
            }

        }
        else
        {
            d2.Density = tempNeb += Time.deltaTime;
            if (tempNeb >= 2f)
            {
                tempAtiv = true;
                //d2.Density = 0.5f;
                // d2.HorizontalSpeed = 0.2F;
                tempNeb = 2f;
            }
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Neblina")
    //    {
    //        d2.Density = 2.5f;
    //        d2.HorizontalSpeed = 0.7F;
    //        tempAtiv = true;
    //    }

    //    if (collision.gameObject.tag == "DesabNevoa")
    //    {
    //        d2.Density = 0.4f;
    //        d2.HorizontalSpeed = 0.2F;
            
    //    }

    //}

}
