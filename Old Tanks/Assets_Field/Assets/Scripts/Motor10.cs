using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Motor10 : MonoBehaviour
{
    [SerializeField] float linearSpeed = 8, speedRot = 180;
    [SerializeField] string horizontal = "Horizontal", vertical = "Vertical";
    [SerializeField] AudioClip idle,  driving;

    AudioSource audio;

    Light lightL, lightR;
    void Start(){
        audio = GetComponent<AudioSource>();
        lightL = transform.Find("Left Light").GetComponent<Light>();
        lightR = transform.Find("Right Light").GetComponent<Light>();
    }

    public void Rotate(){
        Vector3 dirRot = new Vector3(0, 1, 0);
        Vector3 speedRotation = speedRot * dirRot * Input.GetAxis(horizontal);

        transform.eulerAngles += speedRotation * Time.deltaTime;
    }
    public void Move(){
        Vector3 dirZ = transform.forward;
        Vector3 SpeedZ = linearSpeed * dirZ * Input.GetAxis(vertical);

        Vector3 movement = SpeedZ * Time.deltaTime;
        transform.position += movement;
    }
    public void Sound(){
        if (Input.GetAxis(vertical) != 0 || Input.GetAxis(horizontal) != 0)
        {
            audio.volume = 0.03f;
            audio.clip = driving;
        }
        else
        {
            audio.volume = 0.03f;
            audio.clip = idle;
        }
        if (!audio.isPlaying) audio.Play();
    }
    public void SetLight(){
        if (Input.GetAxis(vertical) < 0)
        {
            lightL.intensity = 2;
            lightR.intensity = 2;
        }
        else
        {
            if (Input.GetAxis(horizontal) < 0)
            {
                lightL.intensity = 2;
                lightR.intensity = 0;
            }
            else if (Input.GetAxis(horizontal) > 0)
            {
                lightL.intensity = 0;
                lightR.intensity = 2;
            }
            else if (Input.GetAxis(horizontal) == 0)
            {
                lightL.intensity = 0;
                lightR.intensity = 0;
            }
        }
    }
}
