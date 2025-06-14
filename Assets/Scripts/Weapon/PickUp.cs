using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private Gun _weaponPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Istanzia l'arma come figlio del Player
            Instantiate(_weaponPrefab, collision.transform.position, Quaternion.identity, collision.transform);
            Destroy(gameObject); // distrugge il pickup
        }
    }
}
