using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Main : MonoBehaviour
{
    
    public float delay;
    private IEnumerator corot;
    [SerializeField] Text bitcoin;
    public static float kredit = 200;

    IEnumerator Creator(){
        while(true){
            
            Instantiate(Resources.Load("Enemy", typeof(Enemy)), new Vector2(UnityEngine.Random.Range(-10,-20), UnityEngine.Random.Range(-10,10)), Quaternion.identity);
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.1f,4f));// рандомный спавн 0.1f,4f
        }
    }
    
    
    void Start()
    {
        //Instantiate(Resources.Load("Tower", typeof(Tower)), new Vector2(0,0), Quaternion.identity);
        corot = Creator();
        StartCoroutine(corot);

    }


    void Update()
    {
        kredit += Time.deltaTime * 1f; //прирост битков
        int a = (int)Math.Round(kredit);
        bitcoin.text = a.ToString();
        
    }
}
