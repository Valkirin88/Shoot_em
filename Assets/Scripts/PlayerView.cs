using System;
using UnityEngine;

public class PlayerView : MonoBehaviour
{

    private float _movingSpeed = 4f;
    [SerializeField]
    private Animator _animator;

    private Vector3 _direction;
    private bool _isIdle = true;
    private bool _isMoving = false;

    public void SetDirection(Vector2 direction, bool isTouched)
    {

        if (isTouched)
        {
            _isMoving = true;
            _direction.Normalize();
            _animator.SetFloat("Horizontal", direction.x);
            _animator.SetFloat("Vertical", direction.y);
            _direction = direction;
        }
        else
            _isMoving = false;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_direction.x < 0.1f && _direction.y< 0.1f && _direction.x > -0.1f && _direction.y > -0.1f || !_isMoving)
        {
            _isIdle = true;
            _animator.SetBool("IsIdle", _isIdle);
            
        }
        else
        {
            _isIdle = false;
            _animator.SetBool("IsIdle", _isIdle);
            transform.position = transform.position + new Vector3(_direction.x, 0, _direction.y) * _movingSpeed * Time.deltaTime;
        }
        
    }
}
