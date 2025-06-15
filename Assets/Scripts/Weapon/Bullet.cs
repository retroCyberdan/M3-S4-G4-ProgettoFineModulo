using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifeSpan = 2f;
    [SerializeField] private int _damage = 1;
    public AudioClip hitSound;


    void Start()
    {
        Destroy(gameObject, _lifeSpan); // <- distrugge il Proiettile dopo tot secondi che è stato generato
    }

    // Start is called before the first frame update
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            LifeController target = collision.collider.GetComponent<LifeController>();
            collision.collider.GetComponent<EnemyAnimator>().DeathAnimation();
            target.TakeDamage(_damage);
            AudioController.Play(hitSound, transform.position, 1);
            Destroy(gameObject); // <- distrugge il Proiettile all'impatto
        }
    }
}
