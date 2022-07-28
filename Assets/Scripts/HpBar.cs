using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Image bar;

    void Update()
    {
        Destructible ship = gameObject.GetComponent<Destructible>();
        bar.fillAmount = ship.hp/ship.maxhp;
    }
}
