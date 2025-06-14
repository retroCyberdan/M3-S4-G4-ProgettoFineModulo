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
        LifeController target = collision.collider.GetComponent<LifeController>();
        if (collision.collider.CompareTag("Enemy"))
        {            
            collision.collider.GetComponent<EnemyAnimator>().DeathAnimation();
            target.TakeDamage(_damage);
            AudioController.Play(hitSound, transform.position, 1);
            Destroy(gameObject); // <- distrugge il Proiettile all'impatto
        }
    }
}
