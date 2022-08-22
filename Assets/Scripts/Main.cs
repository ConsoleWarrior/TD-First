using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    [SerializeField] Text bitcoin;
    [SerializeField] Text timerr;
    public static float kredit;
    public GameObject youwin;
    public GameObject gameover;
    public GameObject ship;


    void Start()
    {
        kredit = 250;
        ship = GameObject.Find("Ship");
        youwin.SetActive(false);
        gameover.SetActive(false);
    }

    void Update()
    {
        kredit += Time.deltaTime * 1f; //прирост битков
        int a = (int)Math.Round(kredit);
        bitcoin.text = a.ToString();
        timerr.text = Level1.alltimer.ToString();
        if (!ship) { 
            gameover.SetActive(true); 
            StartCoroutine(LooseDelay());
        }
        if (Level1.win == true)
        {
            youwin.SetActive(true);
            StartCoroutine(WinDelay());
        }
    }

    IEnumerator WinDelay()
    {
        yield return new WaitForSeconds(3f);
        StartMenu.point += 3;
        SceneManager.LoadScene("StartMenu");// SceneManager.GetActiveScene().buildIndex + 1
    }
    IEnumerator LooseDelay()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("StartMenu");
    }
}
