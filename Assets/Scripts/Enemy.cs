using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target; //цель
    public float hp = 200;
    public int dmg = 10;
    public float attackspeed = 3f;
    private IEnumerator corot;
    /*private Transform waypoints;
    private Transform waypoint;
    private Transform waypoints1;
    private Transform waypoints2;
    private int waypointIndex = -1;*/
    //public float speed;
    public bool activStazis = false;
    //public Transform look;

    void Start()
    {
        /*waypoints1 = GameObject.Find("WayPoints(1)").transform;
        waypoints2 = GameObject.Find("WayPoints(2)").transform;
        if((waypoints1.GetChild(0).position - transform.position).magnitude < (waypoints2.GetChild(0).position - transform.position).magnitude)
        waypoints = waypoints1;
        else waypoints = waypoints2;
        NextWaypoint();*/

        
    }

    

    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position,new Vector2(0,0),Time.deltaTime*1f);     //идем к цели
        if (hp <= 0) { Destroy(this.gameObject); Main.kredit += 1; }

        /*Vector3 dir = (waypoint.transform.position - transform.position);
        
        //look.transform.right = new Vector3(waypoint.transform.position.x,waypoint.transform.position.y, 0f);
        //float _speed = Time.deltaTime * speed;
        //transform.Translate(dir.normalized * _speed);

        transform.position = Vector2.MoveTowards(transform.position, waypoint.transform.position,Time.deltaTime*speed);
              
        

        if (dir.magnitude <= 0.3f)
        NextWaypoint();*/
        //transform.up = new Vector2(target.position.x,target.position.y); 
    }

    /*void NextWaypoint()
    {
       waypointIndex++;

       if (waypointIndex >= waypoints.childCount)
       {
          Destroy(gameObject);
          return;
       }

       waypoint = waypoints.GetChild(waypointIndex);
    }*/

    private void OnCollisionEnter2D(Collision2D other){
        Tower tower = other.gameObject.GetComponent<Tower>();
        if(tower == null) return;
        corot = Damaging(this,tower);
        StartCoroutine(corot);
        
    }
    /*private void OnCollisionEnter2D(Collision2D coll){
        Tower tower = coll.gameObject.GetComponent<Tower>();
        if(tower == null) return;
        GetComponent<Rigidbody2D>().AddForce(tower.transform.position.normalized*-100f);
    }*/
    private void OnCollisionExit2D(Collision2D other){
        Tower tower = other.gameObject.GetComponent<Tower>();
        if(tower == null) return;
        else {StopCoroutine(corot); Debug.Log("Go away");}
    }
    IEnumerator Damaging(Enemy enemy, Tower tower){
        while (tower.hp > 0 )
            {
                
                tower.hp -= enemy.dmg;Debug.Log("Hit Base!");
                yield return new WaitForSeconds(attackspeed);
            }
    }
}

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