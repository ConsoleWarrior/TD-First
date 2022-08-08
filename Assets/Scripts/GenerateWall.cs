using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GenerateWall : MonoBehaviour
{
    public GameObject prefab;
    public Transform field;//родительский объект папка
    public NavMeshSurface2d surfaces;
    public bool[,] Grid = new bool[24,24];
    //private float x = 0.5f, y = 0.5f;
    //private int a = 1, b = 1;
    private int kas = 0;
    private bool yes = false;
    private int countwall = 0;
    void Start()
    {
        for(int i = 0; i < Grid.GetLength(0); i++)//задали везде false
            for(int j = 0; j < Grid.GetLength(1); j++)
                Grid[i,j] = false;

        for(int j = 0; j < Grid.GetLength(1); j++) //задали тру по краям
            Grid[0,j] = true;
        for(int j = 0; j < Grid.GetLength(1); j++)
            Grid[23,j] = true;
        for(int i = 0; i < Grid.GetLength(0); i++)
            Grid[i,0] = true;
        for(int i = 0; i < Grid.GetLength(0); i++)
            Grid[i,23] = true;

        for (int i = 11; i < 14; i++)//задали в центр тру
            for (int j = 11; j < 14; j++)
                Grid[i, j] = true;

        /*Generator(9.5f, 9.5f, 10, 10);
        Generator(11.5f, 11.5f, 12, 12);
        Generator(11.5f, 9.5f, 12, 10);
        Generator(9.5f, 11.5f, 10, 12);
        Generator(10.5f, 8.5f, 11, 9);
        Generator(10.5f, 12.5f, 11, 13);
        Generator(8.5f, 10.5f, 9, 11);
        Generator(12.5f, 10.5f, 13, 11);*/
        KorridorCutter(11,11);
        KorridorCutter(2, 21);
        KorridorCutter(13, 13);
        KorridorCutter(21, 2);
        KorridorCutter(11, 13);
        KorridorCutter(2, 2);
        KorridorCutter(13,11);
        KorridorCutter(21, 21);
        KorridorCutter(11, 2);
        KorridorCutter(12, 21);
        RandomCutter();
        FillGenerator(-1.5f, -1.5f);
        surfaces.BuildNavMesh();

    }
    /*void Generator()
    {
        for (int i = 0; i < 1; i++)
        {
            var cell = Instantiate(prefab, new Vector2(x,y),Quaternion.identity, field);
            cell.transform.position = new Vector2(x+Random.Range(-1,2), y+ Random.Range(-1, 2));
            x += Random.Range(-1, 2);y += Random.Range(-1, 2);
            //if (field.childCount > 0) Debug.Log("EST");
        }
    }*/
    void WallGenerator(float x, float y,int a, int b) // устарел
    {
        //Instantiate(prefab, new Vector2(x, y), Quaternion.identity, field); //первая клетка
        //Grid[a, b] = true;
        for (int k = 0; k < 50; k++)//длинна стены
        {
            //var cell = Instantiate(prefab, new Vector2(x,y),Quaternion.identity, field); //первая клетка
            //Grid[a,b] = true;
            yes = false;int test = 0;
            while(!yes){
                int ran1 = Random.Range(-1,2); int ran2 = Random.Range(-1,2); 
                int s = a + ran1; int d = b + ran2; //возможно 0 0 будет херня!!! находим перспективную точку
                if(!Grid[s,d]){
                    for(int i = s - 1; i < s + 2; i++) //цикл проверки окружающих клеток
                        for(int j = d - 1; j < d + 2; j++)
                            if(Grid[i,j]) kas++;
                    //Debug.Log($"Касаний{s},{d}:{kas}");  
                    if(kas<2) {
                        var cell = Instantiate(prefab, new Vector2(x+ran1,y+ran2),Quaternion.identity, field); //возможно проблема с флоатом
                        Grid[s,d] = true;
                        yes = true;
                        x = x + ran1; y = y + ran2;
                        a = s; b = d;
                        //Debug.Log($"нашел подходящую свободную клетку {a},{b} = {x};{y}");
                        //Debug.Log($"Test {test}");
                        countwall++;
                    } 
                }
                test++;kas = 0;
                //if (test == 10) { yes = true; Debug.Log("Test"); }
                if(test>20) yes = true;
            }
            if (k == 49) { Debug.Log($"Длина стены {countwall}"); countwall = 0; }
        }
    }
    void FillGenerator(float x, float y){ //стартовые координаты - нижний левый угол
        
        for(int i = 2; i < Grid.GetLength(0)-2; i++)//заполняем арену стенами по фалсу
            for(int j = 2; j < Grid.GetLength(1)-2; j++)
                if (!Grid[i,j]){

                    Instantiate(prefab, new Vector3(x + i, y + j, -1), Quaternion.identity, field);
                }
    }
    void KorridorCutter(int a, int b){ //координаты стратовых точек для корридоров
        Grid[a,b] = true;
        bool good = false; int fail = 0;
        for(int i = 0; i < 25; i++){
            while(!good){
                switch(Random.Range(1,5)){ //пробуем прорезать соседа случайного
                    case 1 : if(Try(a, b+1)) {Grid[a,b+1] = true; good = true; b = b+1;} else fail++; break;
                    case 2 : if(Try(a, b-1)) {Grid[a,b-1] = true; good = true; b = b-1;} else fail++; break;
                    case 3 : if(Try(a+1, b)) {Grid[a+1,b] = true; good = true; a = a+1;} else fail++; break;
                    case 4 : if(Try(a-1, b)) {Grid[a-1,b] = true; good = true; a = a-1;} else fail++; break;
                }
                if (fail > 20)
                {
                    switch (Random.Range(1, 5))
                    {
                        case 1: Grid[a, b + 1] = true; break;
                        case 2: Grid[a, b - 1] = true; break;
                        case 3: Grid[a+1, b] = true; break;
                        case 4: Grid[a-1, b] = true; break;
                    }
                    break;
                }
            }
            if (fail > 20) {/*Debug.Log("fail");*/ break;}
            good = false; fail = 0;
        }
    }
    bool Try (int a, int b){ //проверка соседних клеток
        int count = 0;
        if(Grid[a, b+1]) count++;
        if(Grid[a, b-1]) count++;
        if(Grid[a+1, b]) count++;
        if(Grid[a-1, b]) count++;
        
        if(count > 1) return false;
        else return true;
    }
    void RandomCutter()
    {
        for(int i = 0; i < 20; i++)
        {
            Grid[Random.Range(2, 22), Random.Range(2, 22)] = true;
        }
    }
}
