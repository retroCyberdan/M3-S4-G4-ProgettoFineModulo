using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _lifeSpan = 2f;
    [SerializeField] private float _damage = 1;
    private Rigidbody2D _rb;
    public Vector2 Direction { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _lifeSpan); // <- distrugge il Proiettile dopo (_lifeSpan) secondi che è stato generato
        _rb = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + Direction * (_speed * Time.deltaTime));
    }



    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            collision.collider.GetComponent<EnemyAnimation>().DamageAnimation();
            Destroy(gameObject); // <- distrugge il Proiettile all'impatto
        }

        if (!collision.collider.isTrigger) // <- si distrugge su qualsiasi ostacolo
            Destroy(gameObject);
    }

    public void TakeDamage()
    {

    }
}
