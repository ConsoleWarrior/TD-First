using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletM : Bullet
{
    public override void OnTriggerEnter2D(Collider2D other){
        
        Debug.Log(other.gameObject.name);
        if(other.gameObject.tag == "Wall"){Debug.Log("wall");
        Destroy(this.gameObject);return;}
        Enemy a = other.gameObject.GetComponent<Enemy>();
        if(a == null) return;
        if(a.CompareTag("Enemy"))
        {
            a.hp -= dmg; //Debug.Log("boom");
            Destroy(this.gameObject);
        }
    }
}
