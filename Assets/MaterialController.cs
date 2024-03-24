using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialController : MonoBehaviour
{
    public Material normalMat;
    public Material scaryMat;
    MeshRenderer mesh;

    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        mesh.material = GameManager.Instance.isScary?scaryMat : normalMat;
    }
}
