using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public int dmg;
    void Start()
    {
        Invoke("InvDest", 1);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Enemy c = other.gameObject.GetComponent<Enemy>();
        if (c == null) return;
        if (other = c.body)
        c.hp -= dmg;
        
    }
    void InvDest()
    {
        Destroy(this.gameObject);
    }
}
