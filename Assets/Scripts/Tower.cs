using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float hp = 1000;
    public GameObject gameover;
    public float maxhp = 1000;
    public static float repair = 0;

    /*public void SetPosition(Transform obj){
        obj.position = Input.mousePosition;
    }*/


    void Update()
    {
        hp += Time.deltaTime*repair;
        if (CompareTag("Tower") && hp <= 0) gameover.SetActive(true);
        if (hp <= 0) Destroy(gameObject);
        //Debug.Log(repair);
    }
}
