using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float hp;
    public int dmg;
    public float attackspeed;
    public bool activStazis = false;
    public bool bleeding = false;
    public bool burning = false;
    public Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }
   void Update()
   {
      if (hp <= 0) { Destroy(this.gameObject); Main.kredit += 1; }
      if (bleeding) anim.SetBool("Bleeding", true);
      if (!bleeding) anim.SetBool("Bleeding", false);
      if (burning) {
            if(!anim.GetBool("Burning")) anim.SetBool("Burning", true); 
            hp = hp-Time.deltaTime*30; 
      }
      if(anim.GetBool("Burning")) hp = hp - Time.deltaTime * 10;
        if (!burning && anim.GetBool("Burning"))  Invoke("StopBurn", 5); 
    }
    void StopBurn()
    {
        anim.SetBool("Burning", false);
        
    } 
}
//transform.position = Vector2.MoveTowards(transform.position,new Vector2(0,0),Time.deltaTime*1f);     //идем к цели


/*
private Transform waypoints;
   private Transform waypoint;
   private int waypointIndex = -1;

   void Start()
   {
      waypoints = GameObject.Find("WayPoints").transform;
      NextWaypoint();
   }
   
   void Update()
   {
      Vector3 dir = waypoint.transform.position - transform.position;
      dir.y = 0;

      float _speed = Time.deltaTime * speed;
      transform.Translate(dir.normalized * _speed);

      if (dir.magnitude <= _speed)
         NextWaypoint();
   }

   void NextWaypoint()
   {
      waypointIndex++;

      if (waypointIndex >= waypoints.childCount)
      {
         Destroy(gameObject);
         return;
      }

      waypoint = waypoints.GetChild(waypointIndex);
   }
*/