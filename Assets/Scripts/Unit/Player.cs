using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : Unit
{
    [Header("Configs")] [SerializeField] private OverlapConfig overlapConfig;
    
    [Header("Player")]
    [SerializeField] private Transform head;

    private IMoveble _movement;
    private IRotatable _rotate;
    private Rigidbody _rigidbody;
    private OverlapDetector _detector;
    private void Awake()
    {
        Initialize();
    }
    
    private void Update()
    {
        Rotate();
        Interact();
    }
    
    private void FixedUpdate()
    {
        Move();
    }

    private void Interact()
    {
        if (_detector.Detected())
        {
            var interactive = _detector.GetDetectedObject<IInteractive>();
            if(interactive != null)
                interactive.Interact();
        }
    }
    private void Move()
    {
        Vector2 axis = InputService.GetMovementAxis();
        Vector3 direction = new Vector3(axis.x, 0, axis.y);
        _movement.Move(transform.TransformDirection(direction), Config.Speed);
    }

    private void Rotate()
    {
        _rotate.Rotate(InputService.GetCameraRotationAxis(), 1);
    }


    private void Initialize()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _rigidbody = GetComponent<Rigidbody>();
        _movement = new RigidbodyMove(_rigidbody);
        _rotate = new FirstPersonLookRotation(transform, head);
        _detector = new OverlapDetector(overlapConfig, transform);
    }
    
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if(_detector != null)
            _detector.DrawGizmos();
    }
#endif
}
