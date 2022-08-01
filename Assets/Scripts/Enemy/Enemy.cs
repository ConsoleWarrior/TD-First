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
    public Animator bleed;
    
    void Start()
    {
        bleed = GetComponent<Animator>();
    }
    void Update()
    {
        if (hp <= 0) { Destroy(this.gameObject); Main.kredit += 1; }
        if (bleeding) bleed.SetBool("Bleeding", true);
        if (!bleeding) bleed.SetBool("Bleeding", false);
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