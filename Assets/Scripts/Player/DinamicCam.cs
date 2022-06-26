using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class DinamicCam : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offSets;
    [SerializeField] private float _speed;
    private void Update()
    {
        Vector3 targetPos = _target.position;
        Quaternion targetRot = _target.rotation;

        transform.position = Vector3.Lerp(transform.position, targetPos, _speed * 0.1f);
        transform.rotation = Quaternion.Slerp(transform.rotation,targetRot, _speed * 0.01f);
    }
}   
