using UnityEngine;

public class BuyButton : MonoBehaviour
{
    [SerializeField] private Resources _resources;
    [SerializeField] private GameObject _nodesGroup;

    public void EnterBuildMode()
    {
        if (_resources.Coins >= 25)
        {
            _nodesGroup.SetActive(true);
        }
    }
}
