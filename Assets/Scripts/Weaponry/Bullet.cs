using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Transform target;
    public static float dmg = 25;

    void Update(){
        if(target)
        transform.position = Vector3.MoveTowards(transform.position,target.position,Time.deltaTime*speed);
        else Destroy(this.gameObject);//Debug.Log("Nedolet");
    }

    /*public void OnTriggerEnter2D(Collider2D other){
        
        Enemy a = other.gameObject.GetComponent<Enemy>();
        if(a == null) return;
        if(a.CompareTag("Enemy") && other == a.body)
        {
            a.hp -= dmg; //Debug.Log("boom");
            Destroy(this.gameObject);
        }
    }*/
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if(other == other.gameObject.GetComponent<Enemy>().body)
            {
                other.gameObject.GetComponent<Enemy>().hp -= dmg;
                Destroy(this.gameObject);
            }
        }
    }
}
