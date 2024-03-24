using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLight : MonoBehaviour
{
    public Color lockedColor = Color.red;
    public Color unlockedColor = Color.green;
    Light light;

    public Door doorScript;

    private void Awake()
    {
        doorScript = GetComponentInParent<Door>();
        light = GetComponent<Light>();
    }

    private void Update()
    {
        light.color = doorScript.isLocked ? lockedColor : unlockedColor;
    }
}
