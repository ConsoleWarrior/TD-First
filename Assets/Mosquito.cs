using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mosquito : Arthropods
{
    private IEnumerator corot;


    private void OnTriggerEnter2D(Collider2D other)
    {
        Destructible dest = other.gameObject.GetComponent<Destructible>();
        
        if (dest == null) return;
        Agent gent = GetComponent<Agent>();
        //gent.agent.SetDestination(this.transform.position);
        gent.target = this.transform;
        Debug.Log("trigger on");
        corot = Damaging(this, dest);
        StartCoroutine(corot);

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Destructible dest = other.gameObject.GetComponent<Destructible>();
        
        if (dest == null) return;
        else StopCoroutine(corot); //Debug.Log("Go away");}
        Debug.Log("trigger off");
    }
    IEnumerator Damaging(Enemy enemy, Destructible dest)
    {
        while (dest.hp > 0)
        {

            dest.hp -= enemy.dmg;Debug.Log("Hit Base!");
            yield return new WaitForSeconds(attackspeed);
        }
    }
}
