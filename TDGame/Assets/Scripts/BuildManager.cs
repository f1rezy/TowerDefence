using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [SerializeField] private GameObject _towerPrefab;

    public static BuildManager _instance;

    private GameObject _towerToBuild;

    private void Awake()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    private void Start()
    {
        _towerToBuild = _towerPrefab;
    }

    public GameObject GetTowerToBuild()
    {
        return _towerToBuild;
    }
}
