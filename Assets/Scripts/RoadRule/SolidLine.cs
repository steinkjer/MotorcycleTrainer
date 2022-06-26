using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        RoadManager.Instance.Violation(this);
    }
}
