using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ovwer : MonoBehaviour
{
    //public GameObject GameOverText;
    //public static GameObject GameOverStatic;

    [SerializeField] public GameObject GanoVerde;
    [SerializeField] public GameObject GanoRojo;

    //void Start()
    //{
    //    Ovwer.GameOverStatic = GameOverText;
    //    Ovwer.GameOverStatic.gameObject.SetActive(false);
    //}
   
    public void show(int player)
    {
        if(player == 1)
        {
            GanoRojo.SetActive(true);
        }
        if (player == 2)
        {
            GanoVerde.SetActive(true);
        }
        
    }
}
