using System;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] private float _moveSpeed = 5f;


    private GameObject _pineapple;
    private Resources _resources;
    private Transform[] _waypoints;
    private int _currentWaypointIndex;
    private int _currentHealthPoints;

    public event Action<int> HealthPointsChanged;

    public void Setup(Transform[] points, Resources resources, GameObject pineapple, int healthPoints)
    {
        _waypoints = points;
        _resources = resources;
        _pineapple = pineapple;
        _currentHealthPoints = healthPoints;
    }

    private void Update()
    {
        Vector2 dir = _pineapple.transform.position - transform.position;
        if (dir.magnitude <= 0.5f)
        {
            _pineapple.GetComponent<Pineapple>().OnCollisionEnterSlime();
            Destroy(gameObject);
        }
    }

    private void LateUpdate()
    {
        if (_currentWaypointIndex == _waypoints.Length)
        {
            return;
        }

        var targetPosition = _waypoints[_currentWaypointIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition,
            _moveSpeed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            _currentWaypointIndex++;
        }
    }

    public void TakeDamage()
    {
        _currentHealthPoints--;
        HealthPointsChanged?.Invoke(_currentHealthPoints);

        if (_currentHealthPoints <= 0)
        {
            _currentHealthPoints = 0;
            _resources.CollectCoins(5, transform.position);
            Destroy(gameObject);

        }
    }
}
