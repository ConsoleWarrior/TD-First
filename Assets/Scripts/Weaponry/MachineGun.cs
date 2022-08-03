using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour

{
    public Enemy curenemy;
    public bool lockfire = false;
    //public GameObject bullet;
    //public Transform target;
    //public Transform look;
    public float firespeed;
    public bool isshoot = false;
    private Animator fire;
    public float dmg;

    private void Start()
    {
        fire = GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.CompareTag("Enemy") && !lockfire){
            //target = other.gameObject.transform;
            lockfire = true;
            curenemy = other.gameObject.GetComponent<Enemy>();
            fire.SetBool("Fire", true);
            //StartCoroutine(Fire());
            

        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Enemy") && curenemy == other.gameObject.GetComponent<Enemy>()){
            lockfire = false;
            StopCoroutine(Fire());
            curenemy.bleeding = false;
            fire.SetBool("Fire", false);
            //curenemy = null;
        }
    }

    void Update(){
        //if(!curenemy)lockfire=false;
        //else 
        if(lockfire && curenemy)
        {
            //transform.up = new Vector2(target.position.x-transform.position.x,target.position.y-transform.position.y); //УРРАА, она вращается!))
            if(!isshoot){
                StartCoroutine(Fire());
                curenemy.bleeding = true;
            }

        }
    }
    IEnumerator Fire()
    {
        //Enemy enemy = curenemy.GetComponent<Enemy>();
        curenemy.hp -= dmg;
        
        isshoot = true;
        yield return new WaitForSeconds(firespeed);
        //GameObject b = GameObject.Instantiate(bullet,transform.position,Quaternion.identity);
        //b.GetComponent<Bullet>().target = target;
        isshoot = false;
        

    }
}
