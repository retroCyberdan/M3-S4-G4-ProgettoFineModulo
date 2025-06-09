using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target; // <- dichiaro una variabile di tipo "Transform" che sarà il target della videocamera

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = new Vector3(_target.position.x, _target.position.y, transform.position.z); // <- alla posizione passo un nuovo Vector3 che ha come parametri la x e la y del mio target, ma come z la sua stessa
                                                                                                        // (se la settassi ad es. a 0, mi si schiaccerebbe sul target!)
    }
}
