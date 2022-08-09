using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firegun : MonoBehaviour
{
    public Animator anim;
    void Start(){
        anim = GetComponent<Animator>();
    }
    void OnTriggerStay2D(Collider2D other){
        Enemy c = other.gameObject.GetComponent<Enemy>();
        if (c == null) return;
        if (other == c.body)
        {
            c.burning = true;
            anim.SetBool("Burning", true);
        }
    }
    void OnTriggerExit2D(Collider2D other){
        Enemy c = other.gameObject.GetComponent<Enemy>();
        if (c == null) return;
        if (other == c.body)
        {
            c.burning = false;
            anim.SetBool("Burning", false);
        }
    }
}
