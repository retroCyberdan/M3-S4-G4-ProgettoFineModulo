using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private PlayerController _playerController;

    // Start is called before the first frame update
    void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateAnimation(Vector2 direction)
    {
        if (_playerController.Direction != Vector2.zero)
        {
            _animator.SetFloat("hDir", direction.x);
            _animator.SetFloat("vDir", direction.y);
        }
    }
}
