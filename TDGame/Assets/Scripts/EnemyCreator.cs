using System.Collections;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    [SerializeField] Enemy _enemyPrefab;
    [SerializeField] float _timeBetweenSpawn = 5f;
    [SerializeField] Transform[] _waypoints;
    [SerializeField] Resources _resources;


    private void Start()
    {
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        while (true)
        {
            Enemy enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            enemy.Setup(_waypoints, _resources);
            yield return new WaitForSeconds(_timeBetweenSpawn);
        }
    }
}
