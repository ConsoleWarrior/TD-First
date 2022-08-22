using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    public float delay;
    private float timer;
    public static float alltimer;
    private int b;
    public static bool win;


    void Start()
    {
        timer = 0; alltimer = 0; b = 1; win = false;
        StartCoroutine(Creator());
        StartCoroutine(Timing());
        StartCoroutine(Group());
    }

    void Update()
    {
        if (alltimer >= 600) { StopCoroutine(Creator()); StopCoroutine(Group()); }
        if (alltimer >= 630) { StopCoroutine(Timing()); win = true; }
    }

    IEnumerator Creator()
    {
        while (true)
        {
            if (timer > 45 && delay > 1) { delay -= 0.5f; timer = 0; }

            Instantiate(Resources.Load("Ant", typeof(Ant)), new Vector3(UnityEngine.Random.Range(-10, 0), UnityEngine.Random.Range(1, 19)), Quaternion.identity);
            Instantiate(Resources.Load("Ant", typeof(Ant)), new Vector2(UnityEngine.Random.Range(20, 30), UnityEngine.Random.Range(1, 19)), Quaternion.identity);
            Instantiate(Resources.Load("Mosquito", typeof(Mosquito)), new Vector2(UnityEngine.Random.Range(-10, 0), UnityEngine.Random.Range(1, 19)), Quaternion.identity);
            Instantiate(Resources.Load("Mosquito", typeof(Mosquito)), new Vector2(UnityEngine.Random.Range(20, 30), UnityEngine.Random.Range(1, 19)), Quaternion.identity);

            if (alltimer > 360f && timer > 30)
            {
                for (int i = 0; i < b; i++)
                {
                    Instantiate(Resources.Load("Crab", typeof(Crab)), new Vector2(UnityEngine.Random.Range(-10, 0), UnityEngine.Random.Range(1, 19)), Quaternion.identity);
                    Instantiate(Resources.Load("Crab", typeof(Crab)), new Vector2(UnityEngine.Random.Range(20, 30), UnityEngine.Random.Range(1, 19)), Quaternion.identity);
                }
                b++; timer = 0;
            }

            yield return new WaitForSeconds(delay);
            timer += delay; 
        }
    }

    IEnumerator Timing()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            alltimer += 1f;
        }
    }

    IEnumerator Group()
    {
        int pause = 100; int x;
        while (true)
        {
            x = Random.Range(30, pause);
            yield return new WaitForSeconds(x) ;
            if(pause > 10) pause -= 10;
            if (x % 2 == 1)
                Instantiate(Resources.Load("GroupMosqiute"), new Vector2(UnityEngine.Random.Range(-10, 0), UnityEngine.Random.Range(1, 19)), Quaternion.identity);
            else
                Instantiate(Resources.Load("GroupMosqiute"), new Vector2(UnityEngine.Random.Range(20, 30), UnityEngine.Random.Range(1, 19)), Quaternion.identity);
        }
    }
}
