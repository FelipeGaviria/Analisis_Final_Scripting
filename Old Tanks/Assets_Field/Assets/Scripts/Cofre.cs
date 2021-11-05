using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Cofre : MonoBehaviour
{
    [SerializeField] float health = 50;
    public GameObject[] randomObject;
    public Transform[] objectLocation;
    Collider leCollider;
    Renderer leRenderer;
    float t = 0f;
    private void Start()
    {
        leCollider = GetComponent < Collider>();
        leRenderer = GetComponent<Renderer>();
    }
    public void Romper (float damage)
    {
        health -= damage + 15;        
        if (health <= 0)
        {
            Instantiate(randomObject[Random.Range(0, randomObject.Length)], objectLocation[Random.Range(0, randomObject.Length)]);
            leCollider.enabled = false;
            leRenderer.enabled = false;
        }
    }
}

