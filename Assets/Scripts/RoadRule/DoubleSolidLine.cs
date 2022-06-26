using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSolidLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        RoadManager.Instance.Violation(this);
    }
}
