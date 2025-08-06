using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
     private Transform _spawnTarget;

    private GameObject _gameObjectTarget;
    [SerializeField] GameObject[] _gameObjects;

    [SerializeField] private float _spawnTime;
    
   [SerializeField] private bool _isSpawning;

    private void Start() => StartCoroutine(nameof(TimeOfSpawn));

    private IEnumerator TimeOfSpawn()
    {
        while (_isSpawning)
        {
            yield return new WaitForSeconds(_spawnTime);
            Spawn();
        }
    }
    private void Spawn()
    {
        _spawnTarget = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
        _gameObjectTarget = _gameObjects[Random.Range(0, _gameObjects.Length)];

        Instantiate(_gameObjectTarget, _spawnTarget.position, _gameObjectTarget.transform.rotation);
    }
}
