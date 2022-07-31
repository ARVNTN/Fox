using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class FoxController: MonoBehaviour
{
    public GameData data;

    private CharacterController _controller;
    private Animator _animator;
    
    private float _timer;
    private Vector3 _direction = Vector3.zero;
    private readonly float _rotationSpeed = 500f;
    
    private static readonly int IsWalking = Animator.StringToHash("isWalking");
    private static readonly int IsSleeping = Animator.StringToHash("isSleeping");

    public bool obstacle;
    
    public void MoveTowards(Vector3 objectToFollow)
    {
        _animator.SetBool(IsWalking,true);
        _direction = objectToFollow - transform.position;
        _direction.y = 0f;
        _direction.Normalize();
        _controller.SimpleMove(_direction * data.foxSpeed);
    }
    

    void ResetTimer()
    {
        _timer = data.changeDirectionTimer;
    }

    void RandomizeDirection()
    {
        _direction.z = Random.Range(-1,2);
        _direction.x = Random.Range(-1,2);
        _direction.Normalize();
    }

    public void Wander()
    {
        if (_timer < 0)
        {
            RandomizeDirection();
            ResetTimer();
        }

        if (_direction == Vector3.zero)
        {
            SetWalking(false);
        }
        else
        {
            SetWalking(true);
            _controller.SimpleMove(_direction * data.foxSpeed);
        }
    }

    public void SetWalking(bool isWalking)
    {
        _animator.SetBool(IsWalking, isWalking);
        _animator.SetBool(IsSleeping,!isWalking);
    }

    public void SetSleeping(bool isSleeping)
    {
        _animator.SetBool(IsSleeping,isSleeping);
        _animator.SetBool(IsWalking, !isSleeping);
    }

    private void Awake()
    {
        RandomizeDirection();
        ResetTimer();
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
        
        RandomizeDirection();
    }


    private void Update()
    {
        _timer -= Time.deltaTime;
        
        Quaternion toRotation = Quaternion.LookRotation(_direction, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed*Time.deltaTime);
    }

}