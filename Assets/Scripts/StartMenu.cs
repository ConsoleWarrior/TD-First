using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StartMenu : MonoBehaviour
{
    public static int point = 2;
    [SerializeField] Text points;
    //private int sceneNumber = 0;
    
    void Start()
    {
        points.text = point.ToString();
    }

    public void StartLevel()
    {
        SceneManager.LoadScene(1); //SceneManager.GetActiveScene().buildIndex
    }
    public void UpCannonDmg()
    {
        if(point > 0)
        {
            Bullet.dmg += Bullet.dmg * 0.25f;
            point -= 1;
            points.text = point.ToString();
        }
    }
    public void UpCannonAtSpeed()
    {
        if (point > 0)
        {
            Cannon.firespeed -= Cannon.firespeed * 0.25f;
            point -= 1;
            points.text = point.ToString();
        }
    }
    public void Exitgame()
    {
        Application.Quit();
    }
}
