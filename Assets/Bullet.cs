using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Transform target;
    public float dmg = 25;
    void Update(){
        if(target)
        transform.position = Vector3.MoveTowards(transform.position,target.position,Time.deltaTime*speed);
        //target.GetComponent<Enemy>().hp -= dmg;
        else {Destroy(this.gameObject);Debug.Log("Nedolet");}
    }

    public void OnTriggerEnter2D(Collider2D other){
        
        Enemy a = other.gameObject.GetComponent<Enemy>();
        if(a == null) return;
        if(a.CompareTag("Enemy")){
        a.hp -= dmg; Debug.Log("boom");
        Destroy(this.gameObject);
        }
    }
}
