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
    public static float kredit = 10000;
    private float timer = 0;
    private float alltimer = 0;
    public GameObject youwin;
    public GameObject gameover;
    private GameObject ship;
    private bool boss = false;

    IEnumerator CreatorLeft(){
        while(true){
            if (timer > 60 && delay > 1) {delay -= 0.5f; timer = 0;}
            if(timer >60 && delay > 0.5 && delay <= 1) { delay -= 0.2f; timer = 0; }
            Instantiate(Resources.Load("Ant", typeof(Ant)), new Vector3(UnityEngine.Random.Range(-10,-20), UnityEngine.Random.Range(-10,10)), Quaternion.identity);
            yield return new WaitForSeconds(delay);// рандомный спавн UnityEngine.Random.Range(0.1f,4f)
            timer += delay; alltimer += delay;
        }
    }
    IEnumerator CreatorRight()
    {
        while (true)
        {
            //if (timer > 90 && delay > 1) { delay -= 0.5f; timer = 0; }
            Instantiate(Resources.Load("Ant", typeof(Ant)), new Vector2(UnityEngine.Random.Range(10, 20), UnityEngine.Random.Range(-10, 10)), Quaternion.identity);
            yield return new WaitForSeconds(delay);// рандомный спавн UnityEngine.Random.Range(0.1f,4f)
            //timer += delay;
            if (alltimer > 100f && boss == false){
                for(int i = 0; i < 2;i++){
                    Instantiate(Resources.Load("Crab", typeof(Crab)), new Vector2(UnityEngine.Random.Range(10, 20), UnityEngine.Random.Range(-10, 10)), Quaternion.identity);
                    Instantiate(Resources.Load("Crab", typeof(Crab)), new Vector2(UnityEngine.Random.Range(-10, -20), UnityEngine.Random.Range(-10, 10)), Quaternion.identity);
                }
                boss = true;
            }
        }
    }


    void Start()
    {
        corot = CreatorLeft();
        StartCoroutine(corot);
        corot = CreatorRight();
        StartCoroutine(corot);
        ship = GameObject.Find("Ship");
    }


    void Update()
    {
        kredit += Time.deltaTime * 1f; //прирост битков
        int a = (int)Math.Round(kredit);
        bitcoin.text = a.ToString();
        timerr.text = alltimer.ToString();
        if (!ship) { gameover.SetActive(true); StopAllCoroutines();}
        
        if (alltimer >= 180 && ship) { youwin.SetActive(true); StopAllCoroutines();}
    }
}
