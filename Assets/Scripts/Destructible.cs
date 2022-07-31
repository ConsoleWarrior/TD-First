using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public float hp;
    //public GameObject gameover;
    public float maxhp;
    public static float repair = 0;

    void Update()
    {
        if(hp < maxhp) hp += Time.deltaTime*repair;
        //if (CompareTag("Ship") && hp <= 0) gameover.SetActive(true);
        if (hp <= 0) Destroy(gameObject);

    }
}
