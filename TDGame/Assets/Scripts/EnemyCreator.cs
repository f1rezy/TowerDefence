using System.Collections;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    [SerializeField] Enemy _enemyPrefab;
    [SerializeField] float _timeBetweenSpawn = 5f;
    [SerializeField] int _healthPoints = 3;
    [SerializeField] Transform[] _waypoints;
    [SerializeField] Resources _resources;
    [SerializeField] GameObject _pineapple;

    private int _counter = 0;

    private void Start()
    {
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeBetweenSpawn);
            Enemy enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            enemy.Setup(_waypoints, _resources, _pineapple, _healthPoints);
            _counter += 1;
            if (_counter % 5 == 0)
                _healthPoints += 1;
        }
    }
}
