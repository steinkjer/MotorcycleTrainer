using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugExtensions
{
    private Vector3 _baseTransform;

    public DebugExtensions(Transform baseTransform)
    {
        _baseTransform = baseTransform.position;
    }
    public DebugExtensions(Vector3 basePosition)
    {
        _baseTransform = basePosition;
    }

    public void DrawVector(Vector3 vec,float dur = 10f)
    {
        DrawVector(vec,Color.black,dur);
    }

    public void DrawVector(Vector3 vec, Color col, float dur = 10f)
    {
        Debug.DrawLine(_baseTransform,_baseTransform+vec,col,dur);
    }
}
