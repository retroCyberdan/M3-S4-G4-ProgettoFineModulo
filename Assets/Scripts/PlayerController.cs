using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 2;
    [SerializeField] Rigidbody2D _rb;
    private PlayerAnimation _playerAnimation;

    // Creo le seguenti variabili e le rendo delle properties, accessibili in lettura ma non in scrittura
    public Vector2 Direction { get; private set; }

    private float horizontal;
    private float vertical;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal"); // <- acquisisco gli input in Update
        vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0) // <- se "h" o "v" variano:
        {
            Direction = new Vector2(horizontal, vertical); // <- creo un vettore direzione

            float length = Direction.magnitude; // <- calcolo la sua lunghezza

            if (length > 1)
            {
                Direction /= length; // <- normalizzo il vettore direzione se la lunghezza è > di 1
                //dir.Normalize(); // <- posso farlo anche tramite metodo o in fase di dichiarazione del vettore tramite ".Normalized"
            }

            _playerAnimation.UpdateAnimation(Direction);
        }
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + Direction * (_speed * Time.deltaTime)); // <- eseguo il movimento tramite Rigidbody2D
    }
}

