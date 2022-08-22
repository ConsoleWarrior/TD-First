using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject curenemy;
    public bool lockfire = false;
    public GameObject bullet;
    public Transform target;
    public static float firespeed = 1;
    public bool isshoot = false;
    private List<GameObject> Turn = new List<GameObject>();
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (other == other.GetComponent<Enemy>().body)
            {
                Turn.Add(other.gameObject);
                /*if (!lockfire && other == other.GetComponent<Enemy>().body) //other.CompareTag("Enemy") && && other.GetComponent<Enemy>() 
                {
                    target = other.gameObject.transform;
                    lockfire = true;
                    curenemy = other.gameObject;
                }*/
            }
        }
    }
    void Update()
    {
        if(!lockfire && Turn.Count > 0) //выбераем следующую цель
        {
            target = Turn[0].transform;
            lockfire = true;
            curenemy = Turn[0];
        }
        if(lockfire && curenemy) // целимся и стреляем в цель
        {
            transform.up = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y); //УРРАА, она вращается!))
            if (!isshoot) StartCoroutine(Fire());
        }
        if(!curenemy) // если цели нет - цели нет
        {
            lockfire = false;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        /*if(other.CompareTag("Enemy") && curenemy == other.gameObject && other == other.GetComponent<Enemy>().body)
        {
            lockfire = false;
        }*/
        if (other.CompareTag("Enemy"))
        {
            if (other == other.GetComponent<Enemy>().body)
            {
                Turn.Remove(other.gameObject);
                if(other.gameObject == curenemy)
                {
                    curenemy = null;
                }
            }
        }
    }
    /*void OnTriggerStay2D(Collider2D other){
        if (other.CompareTag("Enemy"))
        {
            if (!lockfire && other == other.GetComponent<Enemy>().body) //other.CompareTag("Enemy") && && other.GetComponent<Enemy>() 
            {
                target = other.gameObject.transform;
                lockfire = true;
                curenemy = other.gameObject;
            }
            if (lockfire && curenemy)
            {
                transform.up = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y); //УРРАА, она вращается!))
                if (!isshoot) StartCoroutine(Fire());
            }
        }
    }*/


    /*void Update(){
        //if(!curenemy)lockfire=false;
        //else 
        if(lockfire && curenemy)
        {
            transform.up = new Vector2(target.position.x- transform.position.x,target.position.y- transform.position.y); //УРРАА, она вращается!))
            if(!isshoot) StartCoroutine(Fire());
        }
    }*/
    public virtual IEnumerator Fire()
    {
        isshoot = true;
        
        GameObject b = GameObject.Instantiate(bullet, transform.position,Quaternion.identity);
        b.GetComponent<Bullet>().target = target;
        yield return new WaitForSeconds(firespeed);
        isshoot = false;
    }
}
