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
    [SerializeField] Text timerr;
    public static float kredit = 250;
    private float timer = 0;
    private float alltimer = 0;
    public GameObject youwin;
    public GameObject gameover;
    private GameObject ship;
    private int b = 1;

    IEnumerator Creator(){
        while(true){
            if (timer > 60 && delay > 1) {delay -= 0.5f; timer = 0;}
            //if(timer >60 && delay > 0.5 && delay <= 1) { delay -= 0.2f; timer = 0; }
            
            Instantiate(Resources.Load("Ant", typeof(Ant)), new Vector3(UnityEngine.Random.Range(-10, 0), UnityEngine.Random.Range(1, 19)), Quaternion.identity);
            Instantiate(Resources.Load("Ant", typeof(Ant)), new Vector2(UnityEngine.Random.Range(20, 30), UnityEngine.Random.Range(1, 19)), Quaternion.identity);
            Instantiate(Resources.Load("Mosquito", typeof(Mosquito)), new Vector2(UnityEngine.Random.Range(-10, 0), UnityEngine.Random.Range(1, 19)), Quaternion.identity);
            Instantiate(Resources.Load("Mosquito", typeof(Mosquito)), new Vector2(UnityEngine.Random.Range(20, 30), UnityEngine.Random.Range(1, 19)), Quaternion.identity);

            if (alltimer > 480f && timer > 30)
            {
                for (int i = 0; i < b; i++)
                {
                    Instantiate(Resources.Load("Crab", typeof(Crab)), new Vector2(UnityEngine.Random.Range(-10, 0), UnityEngine.Random.Range(1, 19)), Quaternion.identity);
                    Instantiate(Resources.Load("Crab", typeof(Crab)), new Vector2(UnityEngine.Random.Range(20, 30), UnityEngine.Random.Range(1, 19)), Quaternion.identity);
                }
                b++; timer = 0;
            }
            yield return new WaitForSeconds(delay);
            timer += delay; alltimer += delay;
        }
    }
    /*IEnumerator CreatorRight() //выключено и объеденено
    {
        while (true)
        {
            //if (timer > 90 && delay > 1) { delay -= 0.5f; timer = 0; }
            Instantiate(Resources.Load("Ant", typeof(Ant)), new Vector2(UnityEngine.Random.Range(10, 20), UnityEngine.Random.Range(-10, 10)), Quaternion.identity);
            yield return new WaitForSeconds(delay);// рандомный спавн UnityEngine.Random.Range(0.1f,4f)
            //timer += delay;
            if (alltimer > 480f && boss == false){
                for(int i = 0; i < 2;i++){
                    Instantiate(Resources.Load("Crab", typeof(Crab)), new Vector2(UnityEngine.Random.Range(10, 20), UnityEngine.Random.Range(-10, 10)), Quaternion.identity);
                    Instantiate(Resources.Load("Crab", typeof(Crab)), new Vector2(UnityEngine.Random.Range(-10, -20), UnityEngine.Random.Range(-10, 10)), Quaternion.identity);
                }
                boss = true;
            }
        }
    }*/


    void Start()
    {
        corot = Creator();
        StartCoroutine(corot);
        //corot = CreatorRight();
        //StartCoroutine(corot);
        ship = GameObject.Find("Ship");
    }


    void Update()
    {
        kredit += Time.deltaTime * 1f; //прирост битков
        int a = (int)Math.Round(kredit);
        bitcoin.text = a.ToString();
        timerr.text = alltimer.ToString();
        if (!ship) { gameover.SetActive(true); StopAllCoroutines();}
        
        if (alltimer >= 600 && ship) StopAllCoroutines();
        if (alltimer >= 629 && ship) youwin.SetActive(true); 
    }
}
