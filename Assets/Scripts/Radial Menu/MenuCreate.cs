using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCreate : MonoBehaviour
{
    public static MenuCreate ins;
    public MenuC menuPrefab;
    void Awake(){
        ins = this;
    }
    public void SpawnMenu(Interactable obj){
        MenuC newMenu = Instantiate(menuPrefab) as MenuC;
        newMenu.transform.SetParent (transform,false);
        newMenu.transform.position = Input.mousePosition;
        newMenu.SpawnButtons(obj);

    }
}
