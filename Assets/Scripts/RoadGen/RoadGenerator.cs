using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _xRoadPrefab;
    [SerializeField] private GameObject _iRoadPrefab;
    [SerializeField] private List<GameObject> _backyardsPrefabs;

    [SerializeField] private float _roadOffset = 208;
    void Start()
    {
    }

    private GameObject GetRandomBackyard()
    {
        int random = UnityEngine.Random.Range(0, _backyardsPrefabs.Count);
        return _backyardsPrefabs[random];
    }
    [ContextMenu("Generate")]
    private void GenerateRoad()
    {
        for (int x = -5; x < 2; x++)
        {
            for (int y = -2; y < 5; y++)
            {
                Vector3 pos = new Vector3(x * _roadOffset, 0, y * _roadOffset);
                Instantiate(_xRoadPrefab, pos, Quaternion.identity, transform);
                Instantiate(_iRoadPrefab, pos, Quaternion.identity, transform);
                Instantiate(_iRoadPrefab, pos, Quaternion.Euler(Vector3.up * 90), transform);
                Instantiate(GetRandomBackyard(), pos, Quaternion.identity, transform);
            }
        }
    }

    [ContextMenu("Delete")]
    private void DeleteAll()
    {
        int childs = transform.childCount;
        for (int i = childs - 1; i > 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }

    [ContextMenu("Regen")]
    private void Regenerate()
    {
        DeleteAll();
        GenerateRoad();
    }
}
