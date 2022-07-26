using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energized : MonoBehaviour
{
    public int dmg = 25;
    private IEnumerator corot;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            //activ.Add(other.gameObject); default.Add(other.gameObject);
            Enemy a = other.gameObject.GetComponent<Enemy>();
            if (a == null) return;
            corot = Damaging(a);
            StartCoroutine(corot);
            //target = other.gameObject.transform;
            //curenemy = other.gameObject;

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy == null) return;
        else { StopCoroutine(corot); Debug.Log("Go away from chock"); }
    }
    IEnumerator Damaging(Enemy enemy)
    {
        while (enemy.hp > 0)
        {

            enemy.hp -= dmg; Debug.Log("Electric shock!");
            yield return new WaitForSeconds(enemy.attackspeed);
        }
    }
}
