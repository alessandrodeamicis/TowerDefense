using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _shootingPoint;
    [SerializeField] private float _deltaX = 0;
    [SerializeField] private float _deltaZ = 0;
    [SerializeField] private float _spawnFrequency = 2f;
    [SerializeField] private int _enemyNumber = 5;

    private int enemyCounter = 0;

    float shootTimer;

    void Update()
    {
        shootTimer += Time.deltaTime;

        if (shootTimer >= _spawnFrequency && enemyCounter < _enemyNumber)
        {
            Spawn();
            enemyCounter++;
            shootTimer = 0f;
        }
    }

    private void Spawn()
    {
        float varX = UnityEngine.Random.Range(-1f, 1f) * _deltaX;
        float varZ = UnityEngine.Random.Range(0f, 1f) * _deltaZ;
        Vector3 variation = new Vector3 (varX, 0);
        variation.z = varZ;
        GameObject enemy = Instantiate(_enemyPrefab, _shootingPoint.position + variation, Quaternion.identity);
    }
}
