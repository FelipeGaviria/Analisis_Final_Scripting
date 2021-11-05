using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] int player; //1=verde // 2 = rojo//
    Ovwer gameover;
   
    [SerializeField] int state = 0;  //0 = Normal //1 = Stun //2 = Root//3 = Blind//
    Motor10 motor;
    Turret10[] turrets;
    [SerializeField] float armor = 20;

    public AudioSource Explaudio;

    //float HealAmplifier = 1f;

    [SerializeField] Slider healthBar;
    
    public void Hit(float damage)
    {
        float damageMultier = 100f / (100 + armor);

        health -= damage * damageMultier;
        healthBar.value = health;
        
        if (health <= 0)
        {
            Explaudio.Play();
            gameover.show(player);
            Destroy(gameObject);
        }
    }
    public void Heal(float heal)
    {
        health += heal; //* (1 + HealAmplifier);
        healthBar.value = health;
    }
    void Start() {
        motor = GetComponent<Motor10>();
        turrets = GetComponentsInChildren<Turret10>();
        gameover = FindObjectOfType<Ovwer>();


    }

    void Update() {
        

        if (state == 0)
        {
            motor.Rotate();
            motor.Move();
            motor.Sound();
            motor.SetLight();

            for (int i = 0; i < turrets.Length; i++)
            {
                turrets[i].Rotate();
                turrets[i].Shoot();
            }
        } 
        
        
       /* else if (state ==1) { }
        else if (state == 2)
        {
            turret.Rotate();
            turret.Shoot();
        }
        else if (state == 3)
        {
            motor.Rotate();
            motor.Move();
            motor.Sound();
            motor.SetLight();

            turret.Rotate();
        }*/
    }
   
}

