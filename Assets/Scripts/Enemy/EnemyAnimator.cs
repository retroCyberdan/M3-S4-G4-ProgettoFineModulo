using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Animator _animator;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeathAnimation()
    {
        if(isDead) return;

        isDead = true;
        _animator.SetBool("Death", true);

        Invoke("DestroyMe", 1.5f); // <- aspetta 1.5s e poi si distrugge
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}