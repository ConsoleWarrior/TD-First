using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float hp = 1000;
    public float maxhp = 1000;

    public void SetPosition(Transform obj){
        obj.position = Input.mousePosition;
    }


    void Start()
    {
        
    }


    void Update()
    {
        if (hp<=0)Destroy(gameObject);
    }
}
