using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimTowardsCursor : MonoBehaviour
{
    [SerializeField] private LayerMask aimColliderMask = new LayerMask();
    [SerializeField] private GameObject cursorMarker;
    private Camera playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenCenterPoint = new Vector2(Screen.width/2, Screen.height/2);

        Ray ray = playerCamera.ScreenPointToRay(screenCenterPoint);
        if(Physics.Raycast(ray, out RaycastHit hit, 999f, aimColliderMask))
        {
            cursorMarker.transform.position = hit.point;
            transform.LookAt(hit.point);
        }
    }
}
