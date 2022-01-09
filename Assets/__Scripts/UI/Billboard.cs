using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = Camera.main;    
    }

    private void LateUpdate()
    {
       transform.LookAt(playerCamera.transform.position);
    }
}
