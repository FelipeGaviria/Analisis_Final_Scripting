using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret10 : MonoBehaviour
{

    [SerializeField] float linearSpeed = 8, speedRot = 180, attackspeed = 3f, bulletSpeed = 1200, ammo = 15f;

    [SerializeField] string horizontal = "Horizontal", vertical = "Vertical", shoot = "Fire1";

    [SerializeField] GameObject originalProjectile;
    
    public AudioSource AudioShoot, NoShoot;
    ParticleSystem ps;

    Transform GenRbody;

    Rigidbody rbody;

    float t = 0;
    void Start()
    {        
        ps = GetComponentInChildren<ParticleSystem>();
        t = attackspeed;
        GenRbody = transform.GetChild(0);
    }
    public void Rotate()
    {
        Vector3 dirRot = new Vector3(0, 1, 0);
        Vector3 speedRotation = speedRot * dirRot * Input.GetAxis(horizontal);

        rbody = GetComponentInParent<Rigidbody>();
        
        transform.eulerAngles += speedRotation * Time.deltaTime;
    }

    public void Shoot()
    {
        if ((Input.GetButtonDown(shoot) && ammo > 0) &&t >= 1.0f/attackspeed )
        {
            t = 0;
            AudioShoot.Play();
            ps.Play();

            GameObject clon = Instantiate(originalProjectile, GenRbody.position, GenRbody.rotation);

            Rigidbody rbClon = clon.GetComponent<Rigidbody>();

            Vector3 force = transform.forward * bulletSpeed;

            rbClon.AddForce(force); //Fuerza clon

            rbody.AddForce(-force); //Retroceso

            ammo--;
        }
        else if(Input.GetButtonDown(shoot) && ammo == 0)
        {
            NoShoot.Play();
        }
        t += Time.deltaTime;
    }
    public void Charge(float load)
    {
        ammo += load;
    }
}
