using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float _fireRate;
    [Range(1f, 20f)]
    [SerializeField] private float _fireRange;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _followDistance = 0.7f;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    private PlayerController _playerController;
    public AudioClip shootSound;


    private float _nextFireTime = 0f;


    // Start is called before the first frame update
    void Start()
    {
        _playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();

        _nextFireTime -= Time.deltaTime;

        if(_nextFireTime <= 0f)
        {
            Shoot();
            _nextFireTime = 1f / _fireRate;
        }
    }
    private void UpdatePosition()
    {
        if (_playerController == null) return;

        Vector2 direction = _playerController.Dir.normalized;
                
        if (direction.sqrMagnitude > 0.01f) // <- se il "Player" si sta muovendo, segue la direzione
        {
            transform.localPosition = (Vector3)(direction * _followDistance);
        }
        else
        {
            transform.localPosition = new Vector3(0.5f, 0.5f, 0f); // <- se fermo, posizione di default (destra-alto)
        }
    }

    private GameObject FindEnemyNearest()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy = null;
        float startDistance = Mathf.Infinity; // <- setto la distanza minima ad Infinito

        foreach (GameObject enemy in enemies) // <- cerco ogni valore "enemy" nell'Array di GameObjects "enemies"
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position); // <- calcolo la distanza tramite il metodo "Distance"
            if (distance < startDistance && distance <= _fireRange)
            {
                startDistance = distance;
                nearestEnemy = enemy;
            }
        }
        return nearestEnemy;
    }

    private void Shoot()
    {
        GameObject target = FindEnemyNearest(); // <- cerco il target più vicino tramite il metodo creato prima
        if (target == null) return; // <- se non ci sono target nel range, non spara
        
        Bullet bulletClone = Instantiate(_bulletPrefab, transform.position, _bulletPrefab.transform.rotation); // <- creo un clone del Prefab tramite il metodo "Instantiate" e lo metto in scena
        bulletClone.transform.position = transform.position + Vector3.forward * 1.5f; // <- lo faccio spawnare leggermente avanti al player
        Vector2 bulletDirection = (target.transform.position - transform.position).normalized; // <- creao un Vector2 direzione a cui assegno la differenza tra la posizione del target e la mia (normalizzata)
        Rigidbody2D bulletRb = bulletClone.GetComponent<Rigidbody2D>(); // <- accedo alla componente Rigidbody2D del mio clone

        //bulletRb.AddForce(Vector3.right * 10, ForceMode2D.Impulse); // <- tramite "AddForce()" applico una "schicchera" verso destra, NON SEGUENDO IL TARGET
        bulletRb.velocity = bulletDirection * 10f; // <- altro modo per muovere il clone, SEGUENDO IL TARGET

        //bulletRb.AddForce(bulletDirection * 10f, ForceMode2D.Impulse); // <- tramite "AddForce()" applico una "schicchera" verso destra, SEGUENDO IL TARGET
        AudioController.Play(shootSound, transform.position, 1);
    }
}