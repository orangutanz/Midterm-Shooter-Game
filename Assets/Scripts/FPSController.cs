using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    public GameObject weapon1;
    public GameObject weapon2;


    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
    private GameObject currentWeapon;


    [HideInInspector]
    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        currentWeapon = weapon1;
        currentWeapon.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        MovementControl();
        WeaponControl();


    }
    void WeaponControl()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = weapon1;
            currentWeapon.SetActive(true);
            weapon2.SetActive(false);
            currentWeapon.GetComponent<Weapon>().player = this.GetComponent<FPSController>();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = weapon2;
            currentWeapon.SetActive(true);
            weapon1.SetActive(false);
            currentWeapon.GetComponent<Weapon>().player = this.GetComponent<FPSController>();
        }
        if(Input.GetMouseButtonDown(0))
        {
            currentWeapon.GetComponent<Weapon>().Fire();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(currentWeapon.GetComponent<Weapon>().Reload());
        }
    }

    void MovementControl()
    {
        Vector3 forwad = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forwad * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        characterController.Move(moveDirection * Time.deltaTime);
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

    }
}
