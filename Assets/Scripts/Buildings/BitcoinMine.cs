using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitcoinMine : MonoBehaviour
{


    void Update()
    {
        Main.kredit += Time.deltaTime*0.8f;
    }
}
