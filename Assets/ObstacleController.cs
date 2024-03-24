using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public GameObject normal;
    public GameObject scary;

    private void Update()
    {
        normal.SetActive(GameManager.Instance.isScary ? false : true);
        scary.SetActive(GameManager.Instance.isScary ? true : false);
    }
}
