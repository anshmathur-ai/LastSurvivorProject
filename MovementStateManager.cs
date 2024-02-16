/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateManager : MonoBehaviour
{
    public float moveSpeed = 3; 
    float hzInput, vInput; 
    [HideInI]
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class MovementStateManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 3; 
    float hzInput, vInput; 
    [HideInInspector] public Vector3 dir; 

    CharacterController controller; 

    void Start()
    {
        controller = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        GetDirectionAndMove(); 
    }

    void GetDirectionAndMove()
    {
        hzInput = Input.GetAxis("Horizontal"); 
        vInput = Input.GetAxis("Vertical"); 
        dir = transform.forward * vInput + transform.right * hzInput; 
        controller.Move(dir * moveSpeed * Time.deltaTime); 
    }
}
*/ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateManager : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotationSpeed = 2f;

    CharacterController controller;
    Camera playerCamera;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        HandleMovementInput();
        HandleMouseLook();
    }

    void HandleMovementInput()
    {
        float hzInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        Vector3 dir = transform.forward * vInput + transform.right * hzInput;
        controller.SimpleMove(dir * moveSpeed);
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Rotate the player (character controller) based on mouse input
        transform.Rotate(Vector3.up * mouseX * rotationSpeed);

        // Rotate the camera (only on the X-axis) based on mouse input
        Vector3 currentRotation = playerCamera.transform.localRotation.eulerAngles;
        float newRotationX = currentRotation.x - mouseY * rotationSpeed;
        newRotationX = Mathf.Clamp(newRotationX, -90f, 90f); // Limit vertical rotation
        playerCamera.transform.localRotation = Quaternion.Euler(newRotationX, 0f, 0f);
    }
}
