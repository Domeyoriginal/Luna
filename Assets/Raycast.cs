using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public float lineMaxLength = 5f;

    public GameObject face;
    public Collider BrewingStation;

    Vector3 rayOrigin;
    RaycastHit raycastHit;

    public bool hitSomething;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootRaycast(this.transform.position, rayOrigin, lineMaxLength);

            if (BrewingStation == raycastHit.collider.GetComponent<Collider>())
            {
                hitSomething = true;
            }
        }
    }

    void ShootRaycast(Vector3 targetPosition, Vector3 direction, float length)
    {
        rayOrigin = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

        Vector3 endPosition = targetPosition + (length * direction);

        if (Physics.Raycast(rayOrigin, Camera.main.transform.forward , out raycastHit))
        {
            endPosition = raycastHit.point;
        }

        Debug.DrawLine(targetPosition, endPosition, Color.red, 10);
        
    }
}
