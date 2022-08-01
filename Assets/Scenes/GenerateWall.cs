using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWall : MonoBehaviour
{
    public GameObject prefab;
    public Transform field;//родительский объект папка
    public bool[,] Grid = new bool[22,22];
    private float x = -9.5f, y = 9.5f;
    private int a = 1, b = 1;
    private int kas = 0;
    private bool yes = false;
    void Start()
    {
        for(int i = 0; i < Grid.GetLength(0); i++)//задали везде афдыу
            for(int j = 0; j < Grid.GetLength(1); j++)
                Grid[i,j] = false;
        for(int j = 0; j < Grid.GetLength(1); j++) //задали тру по краям
            Grid[0,j] = true;
        for(int j = 0; j < Grid.GetLength(1); j++)
            Grid[21,j] = true;
        for(int i = 0; i < Grid.GetLength(0); i++)
            Grid[i,0] = true;
        for(int i = 0; i < Grid.GetLength(0); i++)
            Grid[i,21] = true;
        Generator2();
        //var cell = Instantiate(prefab, new Vector2(-10.5f,10.5f),Quaternion.identity, field);
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
    void Generator2()
    {
        for (int k = 0; k < 5; k++)//длинна стены
        {
            //var cell = Instantiate(prefab, new Vector2(x,y),Quaternion.identity, field); //первая клетка
            //Grid[a,b] = true;
            yes = false;
            while(!yes){
                int ran1 = Random.Range(-1,2); int ran2 = Random.Range(-1,2); 
                int s = a + ran1; int d = b + ran2; //возможно 0 0 будет херня!!! находим перспективную точку
                if(!Grid[s,d]){
                    for(int i = s - 1; i < s + 2; i++) //цикл проверки окружающих клеток
                        for(int j = d - 1; j < d + 2; j++)
                            if(Grid[i,j]) kas++;
                        
                    if(kas<2) {
                        var cell = Instantiate(prefab, new Vector2(x+ran1,y+ran2),Quaternion.identity, field); //возможно проблема с флоатом
                        Grid[s,d] = true;
                        kas = 0;
                        yes = true;
                        x = x + ran1; y = y + ran2;
                        a = s; b = d;
                    } 
                }
            }
        }
    }
}
