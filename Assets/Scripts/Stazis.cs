using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stazis : MonoBehaviour
{
    //private List<GameObject> activ;//List<Player> Team2 = new List<Player>();
    //private List<GameObject> default;
    
    
    void OnTriggerStay2D(Collider2D other){
        if(other.CompareTag("Enemy")){
            //activ.Add(other.gameObject); default.Add(other.gameObject);
            Enemy a = other.gameObject.GetComponent<Enemy>();
            if(a.activStazis == false){
            a.speed *= 0.5f;
            SpriteRenderer b  = other.gameObject.GetComponent<SpriteRenderer>();
            b.color = Color.blue;
            a.activStazis = true;
            }
            //target = other.gameObject.transform;
            //curenemy = other.gameObject;

        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Enemy")){
            Enemy a = other.gameObject.GetComponent<Enemy>();
            a.activStazis = false;
            a.speed *= 2f;
            other.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            //b.color = Color.red;SpriteRenderer b  = 

        }
    }
}
