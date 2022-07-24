using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    
    public float delay;
    private IEnumerator corot;
    IEnumerator Creator(float delay){
        while(true){
            Instantiate(Resources.Load("Enemy", typeof(Enemy)), new Vector2(Random.Range(-10,-20),Random.Range(-10,10)), Quaternion.identity);
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
        
    }
}
