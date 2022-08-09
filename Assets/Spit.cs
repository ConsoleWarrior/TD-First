using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spit : MonoBehaviour
{
    public float speed;
    public Transform target;
    public float dmg;

    void Update()
    {
        if (target) { 
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
            transform.up = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
        }
        else Destroy(this.gameObject);//Debug.Log("Nedolet");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Destructible a = other.gameObject.GetComponent<Destructible>(); 
        if (a == null) return; 
        if (other == a.body)
        {
            a.hp -= dmg; //Debug.Log("boom");
            Destroy(this.gameObject);
        }
    }
}