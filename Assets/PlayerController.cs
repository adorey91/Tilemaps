using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D _rb;
    private Vector2 _movement;
    [SerializeField] private Animator _animator;
    [SerializeField] private float lastInputX, lastInputY;

    public void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
    }

    public void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
    }

    public void FixedUpdate()
    {
        HandleMove();
        HandleAnimation();
    }

    private void HandleMove()
    {
        _rb.MovePosition(_rb.position + _movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    private void HandleAnimation()
    {

        if (_movement != Vector2.zero)
        {
            _animator.SetFloat("MoveInputX", _movement.x);
            _animator.SetFloat("MoveInputY", _movement.y);
            _animator.SetBool("Moving", true);

            if (_movement == new Vector2(0, -1))
                _animator.SetFloat("MoveDir", 0);
            if (_movement == new Vector2(0, 1))
                _animator.SetFloat("MoveDir", 1);
            if (_movement == new Vector2(1, 0))
                _animator.SetFloat("MoveDir", 2);
            if (_movement == new Vector2(-1, 0))
                _animator.SetFloat("MoveDir", 3);
            
            
        }
        else
        {
            _animator.SetBool("Moving", false);

        }
       
    }
}
