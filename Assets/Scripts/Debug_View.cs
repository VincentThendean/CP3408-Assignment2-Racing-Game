using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_View : MonoBehaviour
{
    private MeshRenderer meshRender;
    void Start()
    {
        meshRender = this.GetComponent<MeshRenderer>();
        meshRender.enabled=false;
    }
}
