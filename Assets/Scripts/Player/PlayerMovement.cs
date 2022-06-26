using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _motorcycleFork;
    [SerializeField] private float _movementSpeed = 10f;
    [SerializeField] private Joystick _joystick;

    private Vector3 _velocity;
    private Rigidbody _rigidBody;
    private DebugExtensions _vecDebug;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _vecDebug = new DebugExtensions(transform);
    }

    private void Update()
    {
        float verical = Input.GetAxis("Vertical") + _joystick.Direction.y;
        float horizontal = Input.GetAxis("Horizontal") + _joystick.Direction.x;
        DoMove(verical, horizontal);
    }

    public void DoMove(float vertical,float horizontal)
    {
        _velocity += transform.forward * vertical * _movementSpeed * Time.deltaTime;
        _motorcycleFork.localRotation = Quaternion.Lerp(_motorcycleFork.localRotation, Quaternion.Euler(Vector3.up * horizontal * 20), 10 * Time.deltaTime);

        float forwardComponent = Vector3.Dot(_velocity, transform.forward) * 0.99f;
        float rightComponent = Vector3.Dot(_velocity, transform.right) * 0.96f * horizontal;

        _vecDebug.DrawVector(transform.forward * forwardComponent, Color.red);
        _vecDebug.DrawVector(transform.right * rightComponent, Color.cyan);

        _velocity = transform.forward * forwardComponent + transform.right * rightComponent;

        _rigidBody.velocity = _velocity;
        Quaternion dirQ;

        if (forwardComponent < 0)
        {
            dirQ = Quaternion.FromToRotation(transform.forward, transform.right * -horizontal / 5);
        }
        else
        {
            dirQ = Quaternion.FromToRotation(transform.forward, transform.right * horizontal / 5);
        }
        dirQ *= transform.rotation;

        transform.rotation = Quaternion.Lerp(transform.rotation, dirQ, Time.deltaTime * Mathf.Abs(horizontal) * 0.1f * Mathf.Min(5, Mathf.Max(2, _rigidBody.velocity.magnitude)));
    }
}
