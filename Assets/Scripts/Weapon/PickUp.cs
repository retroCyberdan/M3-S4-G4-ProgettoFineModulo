using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private Gun _weaponPrefab;
    [SerializeField] private float _distanceFromPlayer = 0.3f; // <- quanto lontano posizionare l'arma

    //private Vector3 _weaponOffset = new Vector3(0.5f, 0.5f, 0f); // <- offset per posizionare l'arma

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController playerController = collision.GetComponent<PlayerController>(); // <- ottieni la direzione attuale del "Player"

            Vector3 _weaponOffset = Vector3.zero;

            if (playerController != null)
            {
                Vector2 dir = playerController.Dir.normalized;
                if (dir.sqrMagnitude > 0.01f)
                {
                    _weaponOffset = (Vector3)dir * _distanceFromPlayer;
                }
                else
                {
                    _weaponOffset = new Vector3(0.5f, 0.5f, 0f); // <- se il "Player" è fermo, metti l’arma leggermente a destra
                }
            }

            // Istanzia l'arma come figlio del Player
            Gun newWeapon = Instantiate(_weaponPrefab, collision.transform);
            newWeapon.transform.localPosition = _weaponOffset;

            Destroy(gameObject); // <- distrugge il pickup
        }
    }
}
