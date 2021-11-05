using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCode : MonoBehaviour
{

    [SerializeField] float DashForce = 5000, cooldown = 5f;
    [SerializeField] public string Jump = "Jump";
    Rigidbody rb;
    float t = 0;

    // Update is called once per frame

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        t = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        Dash();
    }
    void Dash()
    {
        if (Input.GetButtonDown(Jump) && t >= cooldown)
        {
            Vector3 direccion = (transform.forward * 5 + transform.up * 1).normalized;
            Vector3 force = DashForce * direccion * 1;
            rb.AddForce(force);
            t = 0;
        }
        t += Time.deltaTime;
    }
}


