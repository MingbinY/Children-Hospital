using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public Door doorToUnlock;
    public CardScanner scanner;
    public GameObject keyObj;
    public float rotSpeed = 1.0f;

    public void UnlockDoor()
    {
        if (doorToUnlock) doorToUnlock.Unlock();
    }

    public void CardCollected()
    {
        scanner.cardCollected = true;
        Destroy(gameObject);
    }

    private void Update()
    {
        Quaternion rot = keyObj.transform.rotation;
        rot.y += Time.deltaTime * rotSpeed;
        keyObj.transform.rotation = rot;
    }
}
