using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScanner : MonoBehaviour
{
    public Door doorToUnlock;
    public bool cardCollected;

    public void UnlockDoor()
    {
        if (cardCollected && doorToUnlock) doorToUnlock.Unlock();
    }
}
