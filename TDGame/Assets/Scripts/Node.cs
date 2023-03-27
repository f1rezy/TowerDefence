using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] private Color _hoverColor;
    [SerializeField] private Resources _resources;
    [SerializeField] private GameObject _nodesGroup;

    private GameObject _tower;

    private Renderer _rend;
    private Color _startColor;

    private void Start()
    {
        _rend = GetComponent<Renderer>();
        _startColor = _rend.material.color;
    }

    private void OnMouseDown()
    {
        if (_tower != null)
        {
            return;
        }

        if (_resources.Buy(25))
        {
            GameObject towerToBuild = BuildManager._instance.GetTowerToBuild();
            _tower = (GameObject)Instantiate(towerToBuild, transform.position, transform.rotation);
            Destroy(gameObject);
            _nodesGroup.SetActive(false);
        }

        else
        {
            return;
        }
    }

    private void OnMouseEnter()
    {
        _rend.material.color = _hoverColor;
    }

    private void OnMouseExit()
    {
        _rend.material.color = _startColor;
    }
}
