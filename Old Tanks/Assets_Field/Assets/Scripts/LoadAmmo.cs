using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAmmo : MonoBehaviour
{
    [SerializeField] float load;
    public AudioSource Gunload;
    void Start()
    {
        load = Random.Range(5, 15);
        Gunload = GetComponent<AudioSource>();
    }
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 360) * Time.deltaTime); ///Rotator
    }
     void OnCollisionEnter(Collision collision)
    {
        GameObject target = collision.gameObject;
        if (target.CompareTag("Player"))
        {
            Gunload.Play();
            Turret10 player = target.GetComponentInChildren<Turret10>();
            player.Charge(load);
            
            Destroy(gameObject);
        }
    }
}
