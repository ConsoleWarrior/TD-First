using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 dot;
    public float speed;
    public Transform target;
    private Animator half;
    private float distance;
    //public float dmg;
    void Start()
    {
        half = GetComponent<Animator>();
        dot = target.position;
        distance = (transform.position - dot).magnitude/2;//Debug.Log(distance);
    }
    void Update()
    {
        transform.up = new Vector2(dot.x - transform.position.x, dot.y - transform.position.y);
        if ((transform.position - dot).magnitude < distance) half.SetBool("half",true);
        transform.position = Vector3.MoveTowards(transform.position, dot, Time.deltaTime * speed);
        if (transform.position == dot)
        {
            Instantiate(Resources.Load("Boom", typeof(GameObject)), dot, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

}
