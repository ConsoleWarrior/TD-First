using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [System.Serializable]
    public class Action{
        public Color color;
        public Sprite sprite;
        public string title;
        
    }
    public Action[] options;

    public static GameObject field;
    public bool empty = true;
    public GameObject turel;



    void OnMouseDown(){
        //говорим канвасу вызвать меню
        MenuCreate.ins.SpawnMenu(this);
        field = this.gameObject;
    }
}
