using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour
{
    [SerializeField] float heal = 20f;

    void Update()
    {
        transform.Rotate(new Vector3(360, 360, 360) * Time.deltaTime); ///Rotator
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject target = collision.gameObject;
        if (target.CompareTag("Player"))
        {
            PlayerController player = target.GetComponent<PlayerController>();
            player.Heal(heal);

            Destroy(gameObject);
        }
    }
}
