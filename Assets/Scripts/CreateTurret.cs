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
        if (Main.kredit >= 50)
        {
            Vector3 pos = new Vector3(field.transform.position.x, field.transform.position.y, 0f);//Camera.main.ScreenToWorldPoint(Input.mousePosition)
            GameObject c = (GameObject)Object.Instantiate(Resources.Load("Turret 1", typeof(GameObject)), pos, Quaternion.identity);
            Debug.Log("Turret installed");
            Main.kredit -= 50;
            return c;
        }
        else return null;
    }
    public static GameObject SozdatStazis(GameObject field){
        if (Main.kredit >= 50)
        {
            Vector3 pos = new Vector3(field.transform.position.x, field.transform.position.y, 0f);//Camera.main.ScreenToWorldPoint(Input.mousePosition)
            GameObject c = (GameObject)Object.Instantiate(Resources.Load("Stazis", typeof(GameObject)), pos, Quaternion.identity);
            Debug.Log("Stazis installed");
            Main.kredit -= 50;
            return c;
        }
        else return null;
        
    }
    public static GameObject SozdatBitcoinMine(GameObject field){
        if (Main.kredit >= 100)
        {
            Vector3 pos = new Vector3(field.transform.position.x, field.transform.position.y, 0f);//Camera.main.ScreenToWorldPoint(Input.mousePosition)
            GameObject c = (GameObject)Object.Instantiate(Resources.Load("BitcoinMine", typeof(GameObject)), pos, Quaternion.identity);
            Debug.Log("BitcoinMine installed");
            Main.kredit -= 100;
            return c;
        }
        else return null;
    }
    private static bool CheckKredit()
    {
        return true;
    }
}
