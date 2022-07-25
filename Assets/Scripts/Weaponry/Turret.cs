using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject curenemy;
    public bool lockfire = false;
    public GameObject bullet;
    public Transform target;
    public Transform look;
    public float firespeed;
    public bool isshoot = false;

    void OnTriggerStay2D(Collider2D other){
        if(other.CompareTag("Enemy") && !lockfire){
            target = other.gameObject.transform;
            lockfire = true;
            curenemy = other.gameObject;

        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Enemy") && curenemy == other.gameObject){
            lockfire = false;
            StopCoroutine(Fire());
            //curenemy = null;
        }
    }

    void Update(){
        //if(!curenemy)lockfire=false;
        //else 
        if(lockfire && curenemy)
        {
            look.transform.up = new Vector2(target.position.x-look.position.x,target.position.y-look.position.y); //УРРАА, она вращается!))
            if(!isshoot){
                StartCoroutine(Fire());
            }

        }
    }
    IEnumerator Fire()
    {
        isshoot = true;
        yield return new WaitForSeconds(firespeed);
        GameObject b = GameObject.Instantiate(bullet,look.position,Quaternion.identity);
        b.GetComponent<Bullet>().target = target;
        isshoot = false;
    }
}
