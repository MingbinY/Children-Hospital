using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isLocked = true;

    public void Unlock()
    {
        isLocked = false;
    }

    public void Open()
    {
        if (isLocked) return;

        //Next Level
        GameManager.Instance.LoadNextLevel();
    }
}
