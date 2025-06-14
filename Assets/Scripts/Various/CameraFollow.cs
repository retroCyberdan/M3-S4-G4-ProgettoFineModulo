using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target; // <- assegnare il "Player"

    void LateUpdate()
    {
        transform.position = new Vector3(_target.position.x, _target.position.y, transform.position.z); // <- segue il movimento del "Player"
    }
}
