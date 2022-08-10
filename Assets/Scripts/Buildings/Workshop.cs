using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workshop : MonoBehaviour
{
    void Awake()
    {
        Destructible.repair += 2;
    }
}
