using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isLocked = true;
    Material material;
    public Color lockColor = Color.red;
    public Color unlockColor = Color.green;

    private void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        GetComponent<MeshRenderer>().material = material;
        material.color = isLocked ? lockColor : unlockColor;
    }

    public void Unlock()
    {
        isLocked = true;
        material.color = unlockColor;
    }

    public void Open()
    {
        if (isLocked) return;

        //Next Level
        GameManager.Instance.LoadNextLevel();
    }
}
