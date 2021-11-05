using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ovwer : MonoBehaviour
{
    [SerializeField] public GameObject GanoVerde;
    [SerializeField] public GameObject GanoRojo;
    public void show(int player)
    {
        if(player == 1)
            GanoRojo.SetActive(true);
        if (player == 2)
            GanoVerde.SetActive(true);
    }
}
