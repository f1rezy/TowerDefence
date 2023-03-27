using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private int _healthPoints = 3;

    private Resources _resources;
    private Transform[] _waypoints;
    private int _currentWaypointIndex;

    public event Action<int> HealthPointsChanged;

    public void Setup(Transform[] points, Resources resources)
    {
        _waypoints = points;
        _resources = resources;
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
        _healthPoints--;
        HealthPointsChanged?.Invoke(_healthPoints);

        if (_healthPoints <= 0)
        {
            _healthPoints = 0;
            _resources.CollectCoins(1, transform.position);
            Destroy(gameObject);

        }
    }
}
