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
            Vector3 pos = new Vector3(field.transform.position.x, field.transform.position.y, 2f);//Camera.main.ScreenToWorldPoint(Input.mousePosition)
            GameObject c = (GameObject)Object.Instantiate(Resources.Load("Turret 1", typeof(GameObject)), pos, Quaternion.identity);
            c.transform.SetParent(field.transform,true);
            Debug.Log("Turret installed");
            Main.kredit -= 50;
            return c;
        }
        else return null;
    }
    public static GameObject SozdatStazis(GameObject field){
        if (Main.kredit >= 50)
        {
            Vector3 pos = new Vector3(field.transform.position.x, field.transform.position.y, 2f);//Camera.main.ScreenToWorldPoint(Input.mousePosition)
            GameObject c = (GameObject)Object.Instantiate(Resources.Load("Stazis", typeof(GameObject)), pos, Quaternion.identity);
            c.transform.SetParent(field.transform, true);
            Debug.Log("Stazis installed");
            Main.kredit -= 50;
            return c;
        }
        else return null;
        
    }
    public static GameObject SozdatBitcoinMine(GameObject field){
        if (Main.kredit >= 50)
        {
            Vector3 pos = new Vector3(field.transform.position.x, field.transform.position.y, 2f);//Camera.main.ScreenToWorldPoint(Input.mousePosition)
            GameObject c = (GameObject)Object.Instantiate(Resources.Load("BitcoinMine", typeof(GameObject)), pos, Quaternion.identity);
            c.transform.SetParent(field.transform, true);
            Debug.Log("BitcoinMine installed");
            Main.kredit -= 50;
            return c;
        }
        else return null;
    }
    public static GameObject SozdatPlatform(GameObject field)
    {
        if (Main.kredit >= 50)
        {
            Vector3 pos = new Vector3(field.transform.position.x, field.transform.position.y, -1f);//Camera.main.ScreenToWorldPoint(Input.mousePosition)
            GameObject c = (GameObject)Object.Instantiate(Resources.Load("Platform", typeof(GameObject)), pos, Quaternion.identity);
            c.transform.SetParent(field.transform, true);
            Debug.Log("Platform installed");
            Main.kredit -= 50;
            return c;
        }
        else return null;
    }
    public static GameObject SozdatEnergized(GameObject field)
    {
        if (Main.kredit >= 50)
        {
            Vector3 pos = new Vector3(field.transform.position.x, field.transform.position.y, 2f);//Camera.main.ScreenToWorldPoint(Input.mousePosition)
            GameObject c = (GameObject)Object.Instantiate(Resources.Load("Energized", typeof(GameObject)), pos, Quaternion.identity);
            c.transform.SetParent(field.transform, true);
            Debug.Log("Energized installed");
            Main.kredit -= 50;
            return c;
        }
        else return null;
    }
    /*private static bool CheckKredit()
    {
        return true;
    }*/
}
