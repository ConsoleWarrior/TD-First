using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : Arthropods
{
    private IEnumerator corot;

    private void OnCollisionEnter2D(Collision2D other){
        Destructible dest = other.gameObject.GetComponent<Destructible>();
        if(dest == null) return;
        corot = Damaging(this,dest);
        StartCoroutine(corot);
        
    }

    private void OnCollisionExit2D(Collision2D other){
        Destructible dest = other.gameObject.GetComponent<Destructible>();
        if(dest == null) return;
        else StopCoroutine(corot); //Debug.Log("Go away");}
    }
    
    IEnumerator Damaging(Enemy enemy, Destructible dest){
        while (dest.hp > 0 )
            {
                
                dest.hp -= enemy.dmg;//Debug.Log("Hit Base!");
                yield return new WaitForSeconds(attackspeed);
            }
    }
}
