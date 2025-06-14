using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private PlayerController _playerController;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerController.dir != Vector2.zero)
        {
            _animator.SetFloat("hDir", _playerController.h);
            _animator.SetFloat("vDir", _playerController.v);
        }
    }
}
