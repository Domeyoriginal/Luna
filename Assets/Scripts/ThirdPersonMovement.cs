using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Transform groundCheck;
    public LayerMask groundMask;

    float speed;
    public float initialSpeed = 6f;
    public float runningSpeed = 12f;

    float gravity = -19.62f;
    public float groundDistance = 0.4f;
    Vector3 velocity;
    bool isGrounded;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        speed = initialSpeed;

        
        //LoadPlayerPosition();
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //noramlize = doesnt rely on frames,
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

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
        //start running
        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
        {
            speed = runningSpeed;
        }
        //stop running
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
        }
        #endregion
    }





    //Need to have this on Main Menu
    public void SavePlayerPosition()
    {
        SaveSystem.SavePlayer(this);
    }

    //Need to have this on Main Menu
    void LoadPlayerPosition()
    {
        ThirdPersonData data = SaveSystem.LoadPlayer();
        Vector3 position;

        if (data == null)
        {
            SavePlayerPosition();
        }
        else
        {
            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];

            transform.position = position;
        }
    }
}
