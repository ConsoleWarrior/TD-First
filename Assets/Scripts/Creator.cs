using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{
    //public GameObject turretprefab;
    //private GameObject turret;
    //public GameObject field;

    /*void OnMouseDown(){
        Vector3 pos = new Vector3(transform.position.x, transform.position.y,0f);//Camera.main.ScreenToWorldPoint(Input.mousePosition)
        turret = GameObject.Instantiate(turretprefab,pos,Quaternion.identity);//
        Debug.Log("Turret installed");
    }*/
    public static GameObject CreateCannon(GameObject field){
        if (Main.kredit >= 50)
        {
            Vector3 pos = new Vector3(field.transform.position.x, field.transform.position.y, 2f);//Camera.main.ScreenToWorldPoint(Input.mousePosition)
            GameObject c = (GameObject)Object.Instantiate(Resources.Load("Cannon", typeof(GameObject)), pos, Quaternion.identity);
            c.transform.SetParent(field.transform,true);
            Debug.Log("Cannon installed");
            Main.kredit -= 50;
            return c;
        }
        else return null;
    }
    public static GameObject CreateStazis(GameObject field){
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
    public static GameObject CreateBitcoinMine(GameObject field){
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
    public static GameObject CreatePlatform(GameObject field)
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
    public static GameObject CreateEnergized(GameObject field)
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
    public static GameObject CreateWorkshop(GameObject field)
    {
        if (Main.kredit >= 50)
        {
            Vector3 pos = new Vector3(field.transform.position.x, field.transform.position.y, 2f);//Camera.main.ScreenToWorldPoint(Input.mousePosition)
            GameObject c = (GameObject)Object.Instantiate(Resources.Load("Workshop", typeof(GameObject)), pos, Quaternion.identity);
            c.transform.SetParent(field.transform, true);
            Debug.Log("Workshop installed");
            Main.kredit -= 50;
            return c;
        }
        else return null;
    }
    public static GameObject CreateMachineGun(GameObject field){
        if (Main.kredit >= 50)
        {
            Vector3 pos = new Vector3(field.transform.position.x, field.transform.position.y, 2f);//Camera.main.ScreenToWorldPoint(Input.mousePosition)
            GameObject c = (GameObject)Object.Instantiate(Resources.Load("MachineGun", typeof(GameObject)), pos, Quaternion.identity);
            c.transform.SetParent(field.transform,true);
            Debug.Log("MachineGun installed");
            Main.kredit -= 50;
            return c;
        }
        else return null;
    }
    public static GameObject CreateGaubica(GameObject field)
    {
        if (Main.kredit >= 50)
        {
            Vector3 pos = new Vector3(field.transform.position.x, field.transform.position.y, 2f);//Camera.main.ScreenToWorldPoint(Input.mousePosition)
            GameObject c = (GameObject)Object.Instantiate(Resources.Load("Gaubica", typeof(GameObject)), pos, Quaternion.identity);
            c.transform.SetParent(field.transform, true);
            Debug.Log("Gaubica installed");
            Main.kredit -= 50;
            return c;
        }
        else return null;
    }
    public static GameObject CreateFiregun(GameObject field){
        if (Main.kredit >= 50)
        {
            Vector3 pos = new Vector3(field.transform.position.x, field.transform.position.y, 2f);//Camera.main.ScreenToWorldPoint(Input.mousePosition)
            GameObject c = (GameObject)Object.Instantiate(Resources.Load("Firegun", typeof(GameObject)), pos, Quaternion.identity);
            c.transform.SetParent(field.transform,true);
            Debug.Log("Firegun installed");
            Main.kredit -= 50;
            return c;
        }
        else return null;
    }
}
