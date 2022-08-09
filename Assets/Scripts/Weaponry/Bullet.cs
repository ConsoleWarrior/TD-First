using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Transform target;
    public float dmg;

    void Update(){
        if(target)
        transform.position = Vector3.MoveTowards(transform.position,target.position,Time.deltaTime*speed);
        else Destroy(this.gameObject);//Debug.Log("Nedolet");
    }

    public void OnTriggerEnter2D(Collider2D other){
        
        Enemy a = other.gameObject.GetComponent<Enemy>();
        if(a == null) return;
        if(a.CompareTag("Enemy") && other == a.body)
        {
            a.hp -= dmg; //Debug.Log("boom");
            Destroy(this.gameObject);
        }
    }
}
