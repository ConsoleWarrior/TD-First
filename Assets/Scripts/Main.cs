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

    IEnumerator Creator(float delay){
        while(true){
            Instantiate(Resources.Load("Enemy", typeof(Enemy)), new Vector2(UnityEngine.Random.Range(-10,-20), UnityEngine.Random.Range(-10,10)), Quaternion.identity);
            yield return new WaitForSeconds(delay);
        }
    }
    
    
    void Start()
    {
        //Instantiate(Resources.Load("Tower", typeof(Tower)), new Vector2(0,0), Quaternion.identity);
        corot = Creator(delay);
        StartCoroutine(corot);

    }


    void Update()
    {
        kredit += Time.deltaTime * 1f; 
        int a = (int)Math.Round(kredit);
        bitcoin.text = a.ToString();
        
    }
}
