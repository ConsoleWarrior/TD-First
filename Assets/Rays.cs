using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rays : MonoBehaviour
{
    void Update()
    {
       Ray r = new Ray(transform.position, transform.forward);
       
    }
}
