using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public float hp;
    //public GameObject gameover;
    public float maxhp;
    public static float repair = 0;
    public Collider2D body, radius;

    void Awake()
    {
        StartCoroutine("Repair");
    }
    void Update()
    {
        //if(hp < maxhp) hp += Time.deltaTime*repair;
        //if (CompareTag("Ship") && hp <= 0) gameover.SetActive(true);
        if (hp <= 0) Destroy(gameObject);

    }
    private IEnumerator Repair()
    {
        while (true)
        {
            if (hp < maxhp) hp += repair;
            yield return new WaitForSeconds(1);
            //Debug.Log(this.gameObject.name);
        }
    }
}
