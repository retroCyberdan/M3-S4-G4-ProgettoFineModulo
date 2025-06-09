using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _fireRate = 1f; // <- rateo di fuoco (proiettili al secondo)
    [SerializeField] private float _fireRange = 15f; // <- range di fuoco

    private float _nextFireTime = 0f;

    void Update()
    {
        _nextFireTime -= Time.deltaTime;

        GameObject target = FindEnemyNearest(); // <- cerco il target più vicino tramite il metodo creato prima

        if (target != null && _nextFireTime <= 0f) // <- se non ci sono target nel range di fuoco, non spara
        {
            Shoot(target);
            _nextFireTime = 1f / _fireRate;
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

    private void Shoot(GameObject target)
    {
        Bullet bulletClone = Instantiate(_bulletPrefab, transform.position, _bulletPrefab.transform.rotation); // <- creo un clone del Prefab tramite il metodo "Instantiate" e lo metto in scena
        bulletClone.transform.position = transform.position + Vector3.forward * 1.5f; // <- lo faccio spawnare leggermente avanti al player
        Vector2 bulletDirection = (target.transform.position - transform.position).normalized; // <- creao un Vector2 direzione a cui assegno la differenza tra la posizione del target e la mia (normalizzata)
        Rigidbody2D bulletRb = bulletClone.GetComponent<Rigidbody2D>(); // <- accedo alla componente Rigidbody2D del mio clone

        //bulletRb.AddForce(Vector3.right * 10, ForceMode2D.Impulse); // <- tramite "AddForce()" applico una "schicchera" verso destra, NON SEGUENDO IL TARGET
        //bulletRb.velocity = bulletDirection * 10f; // <- altro modo per muovere il clone, SEGUENDO IL TARGET

        bulletRb.AddForce(bulletDirection * 10f, ForceMode2D.Impulse); // <- tramite "AddForce()" applico una "schicchera" verso destra, SEGUENDO IL TARGET
    }
}
