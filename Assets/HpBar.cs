using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Image bar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Tower tower = gameObject.GetComponent<Tower>();
        bar.fillAmount = tower.hp/tower.maxhp;
    }
}
