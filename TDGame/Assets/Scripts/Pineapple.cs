using UnityEngine;

public class Pineapple : MonoBehaviour
{
    [SerializeField] GameObject _enemyCreator;
    [SerializeField] GameObject _endMenu;

    public void OnCollisionEnterSlime()
    {
        _enemyCreator.SetActive(false);
        _endMenu.SetActive(true);
    }
}
