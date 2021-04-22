using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class espinhoRed : MonoBehaviour
{
    public GameObject Esp;
    public Transform localEsp;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Esp, localEsp.position,localEsp.rotation);
    }
  

}
