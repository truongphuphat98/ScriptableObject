using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float speed;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.forward * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<StatusEffectManager>() != null)
        {
            other.GetComponent<StatusEffectManager>().ApplyMiasma(5);
        }
        Destroy(gameObject);
    }
}
