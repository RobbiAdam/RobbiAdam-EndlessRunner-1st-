using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject[] _objectPrefabs;
    [SerializeField] private Transform _spawnPos;
    private PlayerController _player;
    private float _startDelay = 2f;
    private float _spawnInterval = 2f;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObject", _startDelay, _spawnInterval);
    }

    void SpawnObject()
    {
        if (_player._isGameOver == false)
        {
            int objectIndex = Random.Range(0, _objectPrefabs.Length);
            GameObject spawnedObject = Instantiate(_objectPrefabs[objectIndex], _spawnPos.position, _objectPrefabs[objectIndex].transform.rotation);

        }

    }
}
