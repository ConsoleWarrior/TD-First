using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mosquito : Arthropods
{
    private IEnumerator corot;
    public GameObject curenemy;
    public bool lockfire = false;
    public GameObject bullet;
    public Transform curetarget;
    public bool isshoot = false;
    private List<GameObject> Turn = new List<GameObject>();

    public override void Update()
    {
        if (hp <= 0) { Destroy(this.gameObject); Main.kredit += 1; }
        BurnCheck();

        if (!lockfire && Turn.Count > 0) //выбераем следующую цель
        {
            curetarget = Turn[0].transform;
            lockfire = true;
            curenemy = Turn[0];
            this.gameObject.GetComponent<Agent>().target = Turn[0].transform;
            this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 0.01f;
        }
        if (lockfire && curenemy) // целимся и стреляем в цель
        {
            transform.up = new Vector2(curetarget.position.x - transform.position.x, curetarget.position.y - transform.position.y); //УРРАА, она вращается!))
            if (!isshoot) StartCoroutine(Fire());
        }
        if (!curenemy) // если цели нет - цели нет
        {
            lockfire = false;
            this.gameObject.GetComponent<Agent>().target = this.target;
            this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 1.2f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Destructible"))
        {
            if (other == other.GetComponent<Destructible>().body)
            {
                Turn.Add(other.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Destructible"))
        {
            if (other == other.GetComponent<Destructible>().body)
            {
                Turn.Remove(other.gameObject); //удаляем из списка если вышел
                if (other.gameObject == curenemy)
                {
                    curenemy = null;
                }
            }
        }
    }

    IEnumerator Fire()
    {
        isshoot = true;
        GameObject b = GameObject.Instantiate(bullet, transform.position, Quaternion.identity);
        b.GetComponent<Spit>().target = curetarget;
        yield return new WaitForSeconds(attackspeed);
        isshoot = false;
    }

}
