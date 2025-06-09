using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private Gun _weaponPrefab; // <- prefab dell'arma da assegnare
    [SerializeField] private Vector3 _weaponSpawnPoint = Vector3.zero; // <- coordinate per il posizionamento dell'arma

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Transform player = collision.transform;

            // Istanzia l'arma come figlio del player
            Gun weapon = Instantiate(_weaponPrefab, player.position + _weaponSpawnPoint, Quaternion.identity);
            weapon.transform.SetParent(player);

            Destroy(gameObject); // <- distrugge il pickup
        }
    }
}
