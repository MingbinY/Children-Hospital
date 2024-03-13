using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public Door doorToUnlock;

    public void UnlockDoor()
    {
        if (doorToUnlock) doorToUnlock.Unlock();
    }
}
