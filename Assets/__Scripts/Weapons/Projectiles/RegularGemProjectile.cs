using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularGemProjectile : NetworkBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        transform.position += transform.forward * (speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
