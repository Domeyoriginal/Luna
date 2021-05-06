using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float initialSpeed = 6f;
    public float speed;
    public float runningSpeed = 12f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private void Start()
    {
        
        Cursor.visible = false;

        speed = initialSpeed;
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //noramlize = doesnt rely on frames,
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        #region Movement
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }
        #endregion

        #region Running
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runningSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
        }
        #endregion
    }
}
