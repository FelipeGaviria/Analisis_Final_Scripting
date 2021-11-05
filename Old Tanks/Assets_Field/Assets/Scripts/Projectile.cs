using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float duration = 5f, damage = 30f;
    [SerializeField] bool trueDamage = false;
    float t = 0;
    void Start()
    {
    }
    void Update()
    {
        if (t >= 5f)        
            Destroy(gameObject);        
        t += Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject target = collision.gameObject;
        if (target.CompareTag("Player"))
        {
            PlayerController player = target.GetComponent<PlayerController>();
            player.Hit(damage);
            Destroy(gameObject);
        }
    }
}