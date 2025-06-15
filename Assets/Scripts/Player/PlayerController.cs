using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 2;
    [SerializeField] Rigidbody2D _rb;

    // Creo le seguenti variabili e le rendo delle properties, in modo tale che posso gestirle dall'esterno
    // senza correre il rischio di modificarne il valore (posso farlo solo da questa classe)
    public Vector2 Dir { get; private set; }

    public float H { get; private set; }
    public float V { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        H = Input.GetAxis("Horizontal"); // <- acquisisco gli input
        V = Input.GetAxis("Vertical");
        
        if (H != 0 || V != 0) // <- gestisco la fisica in FixedUpdate se "h" o "v" variano
        {
            Dir = new Vector2(H, V); // <- creo un vettore direzione

            float length = Dir.magnitude; // <- calcolo la sua lunghezza

            if (length > 1)
            {
                Dir /= length; // <- normalizzo il vettore direzione se la lunghezza è > di 1
                //dir.Normalize(); // <- posso farlo anche tramite metodo o in fase di dichiarazione del vettore tramite ".Normalized"
            }

            _rb.MovePosition(_rb.position + Dir * (_speed * Time.deltaTime)); // <- eseguo il movimento tramite Rigidbody2D
        }
    }
}

