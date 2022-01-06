using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallMecanics : MonoBehaviour
{
    [SerializeField]
    private Transform _originRayCast;

    [SerializeField]
    private Animator _animator;
    
    void FixedUpdate()
    {
        DetectGroundDistance();
        Debug.DrawLine(_originRayCast.position, Vector3.up, Color.green);
    }

    void DetectGroundDistance()
    {
        RaycastHit hitInt;
        if (Physics.Raycast(_originRayCast.position, Vector3.down, out hitInt, Mathf.Infinity))
        {
            float distance = transform.position.y - hitInt.point.y;
            if (distance > 2f) Fall();
            else if (distance <= 2f) EndFall();
        }
    }

    void Fall()
    {
        _animator.SetFloat("fall", 0f);
    }

    void EndFall()
    {
        _animator.SetFloat("fall", 1f);
    }
}