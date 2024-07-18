using System;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private ParticleSystem _shotParticles;

    [SerializeField]
    private GameObject _cube;

    private float _movingSpeed = 4f;
    private Vector3 _direction;


    private bool _isIdle = true;


    public void SetDirection(Vector2 direction, bool isTouched)
    {

        if (isTouched)
        {
            _isIdle = false;
            _direction = new Vector3(direction.x, 0, direction.y);
        }
        else
            _isIdle = true;

        _animator.SetBool("IsIdle", _isIdle);
    }

    private void Update()
    {
        KeepRotation();
        Move();
    }

    private void Move()
    {
        if(!_isIdle) 
        {
            transform.position = transform.position + _direction.normalized * _movingSpeed * Time.deltaTime;
        }
    }

    private void KeepRotation()
    {
            var lookDirection = transform.position + _direction;
            transform.LookAt(lookDirection);
    }

    public void Shot()
    {
        _animator.SetBool("IsShoot", true);
        _shotParticles.Play();
    }
}
