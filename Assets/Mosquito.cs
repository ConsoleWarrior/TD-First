using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mosquito : Arthropods
{
    private IEnumerator corot;
    //private Collider2D cureenemy;
    public GameObject curenemy;
    public bool lockfire = false;
    public GameObject bullet;
    public Transform targ;
    //public float firespeed;
    public bool isshoot = false;


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Destructible>() == null) return;
        if (!lockfire && other == other.gameObject.GetComponent<Destructible>().body)
        {
            targ = other.gameObject.transform;//
            lockfire = true;
            curenemy = other.gameObject;
            this.gameObject.GetComponent<Agent>().target = other.gameObject.transform;
            this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 0.01f;
        }
        if (lockfire && curenemy)
        {
            transform.up = new Vector2(targ.position.x - transform.position.x, targ.position.y - transform.position.y); //УРРАА, она вращается!))
            if (!isshoot) StartCoroutine(Fire());
        }



        /*Destructible dest = other.gameObject.GetComponent<Destructible>();
        
        if (other == dest.body)
        {
            cureenemy = other;
            this.gameObject.GetComponent<Agent>().target = other.gameObject.transform;
            this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 0.01f;
            transform.up = new Vector2(other.gameObject.transform.position.x - this.transform.position.x, other.gameObject.transform.position.y - this.transform.position.y);
            Debug.Log("trigger on");
            corot = Damaging(this, dest);
            StartCoroutine(corot);
        }*/
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //if (other.gameObject.GetComponent<Destructible>() == null) return;
        if (curenemy && other == curenemy.GetComponent<Destructible>().body)
        {
            lockfire = false;
            this.gameObject.GetComponent<Agent>().target = this.target;
            this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 1.2f;
        }

           /* if (cureenemy == other)
        {
            this.gameObject.GetComponent<Agent>().target = this.target;
            this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 1.2f;
            StopCoroutine(corot); //Debug.Log("Go away");}
            Debug.Log("trigger off");
        }*/
    }
    /*IEnumerator Damaging(Enemy enemy, Destructible dest)
    {
        while (dest.hp > 0)
        {

            dest.hp -= enemy.dmg;Debug.Log("Hit");
            yield return new WaitForSeconds(attackspeed);
        }
    }*/
    public virtual IEnumerator Fire()
    {
        isshoot = true;

        GameObject b = GameObject.Instantiate(bullet, transform.position, Quaternion.identity);
        b.GetComponent<Spit>().target = targ;
        yield return new WaitForSeconds(attackspeed);
        isshoot = false;
    }

}
