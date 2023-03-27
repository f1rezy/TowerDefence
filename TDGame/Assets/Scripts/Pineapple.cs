using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pineapple : MonoBehaviour
{
    [SerializeField] GameObject _enemyCreator;

    private void OnCollisionEnter2D(Collision2D other)
    {
        _enemyCreator.SetActive(false);
    }
}
