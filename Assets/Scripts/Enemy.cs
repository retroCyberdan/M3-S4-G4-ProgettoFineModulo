using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 1.5f;
    [SerializeField] private PlayerController _player;

    // Creo le seguenti variabili e le rendo delle properties, in modo tale che posso gestirle dall'esterno
    // senza correre il rischio di modificarne il valore (posso farlo solo da questa classe)

    private void Awake()
    {
        GameObject player = GameObject.FindWithTag("Player");
        _player = player.GetComponent<PlayerController>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement(); // <- richiamo il metodo per far muovere automaticamente l'Enemy verso il Player
    }

    private void EnemyMovement()
    {
        transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime); // <- muove l'Enemy verso il Player tramite transform.position
    }

    private void OnCollisionEnter2D(Collision2D collision) // <- questo metodo distrugge ogni collider che sia in possesso della tag "Player"
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
