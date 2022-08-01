using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWall : MonoBehaviour
{
    public GameObject prefab;
    public Transform field;
    public bool[,] Grid = new bool[10,10];
    private float x = 2.5f, y = 0.5f;
    void Start()
    {
        for(int i = 0; i < Grid.GetLength(0); i++)
            for(int j = 0; j < Grid.GetLength(1); j++)
                Grid[i,j] = false;

        Generator();
    }
    void Generator()
    {
        for (int i = 0; i < 1; i++)
        {
            var cell = Instantiate(prefab, new Vector2(x,y),Quaternion.identity, field);
            cell.transform.position = new Vector2(x+Random.Range(-1,2), y+ Random.Range(-1, 2));
            x += Random.Range(-1, 2);y += Random.Range(-1, 2);
            //if (field.childCount > 0) Debug.Log("EST");
        }
    }
}
