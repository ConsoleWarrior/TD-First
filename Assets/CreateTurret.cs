using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTurret : MonoBehaviour
{
    //public GameObject turretprefab;
    //private GameObject turret;
    //public GameObject field;

    /*void OnMouseDown(){
        Vector3 pos = new Vector3(transform.position.x, transform.position.y,0f);//Camera.main.ScreenToWorldPoint(Input.mousePosition)
        turret = GameObject.Instantiate(turretprefab,pos,Quaternion.identity);//
        Debug.Log("Turret installed");
    }*/
    public static GameObject SozdatTurret(GameObject field){
       
        Vector3 pos = new Vector3(field.transform.position.x, field.transform.position.y,0f);//Camera.main.ScreenToWorldPoint(Input.mousePosition)
        GameObject c = (GameObject)Object.Instantiate(Resources.Load("Turret 1", typeof(GameObject)), pos, Quaternion.identity);
        Debug.Log("Turret installed");
        return c;
        
    }
    public static GameObject SozdatStazis(GameObject field){
       
        Vector3 pos = new Vector3(field.transform.position.x, field.transform.position.y,0f);//Camera.main.ScreenToWorldPoint(Input.mousePosition)
        GameObject c = (GameObject)Object.Instantiate(Resources.Load("Stazis", typeof(GameObject)), pos, Quaternion.identity);
        Debug.Log("Stazis installed");
        return c;
        
    }
    /*void Awake(){
        field = this.gameObject;
    }*/


}
