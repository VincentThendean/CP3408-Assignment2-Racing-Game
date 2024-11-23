using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dynamic_skybox : MonoBehaviour
{
    private MeshRenderer skybox;
    public float rotSpeed;

    // Start is called before the first frame update
    void Start()
    {
        skybox = this.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        skybox.transform.Rotate(rotSpeed,0,0,Space.Self);
            
        
    }
}
