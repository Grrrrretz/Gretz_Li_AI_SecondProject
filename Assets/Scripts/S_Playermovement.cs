using UnityEngine;

public class S_Playermovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float g = -9.81f;

    public float mouseSensitivity = 100f;
    public Transform cameraTransform;

    private CharacterController controller;
    private float xRotation = 0f;
    private Vector3 velocity;

    private float CDtimmer = 0f;
    public float SprintCD;

    public float SprintDuration;


    private bool Sprinted = false;
    private bool Sprinting = false;

    public Camera cam;



    public void Start()
    {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Update()
    {
        MouseLook();
        Move();

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Sprinted = true;
            Sprinting = true;


        }

        if (Sprinted == true)
        {
            CDtimmer += Time.deltaTime;
            if (CDtimmer > SprintCD)
            {
                Sprinted = false;
                CDtimmer = 0f;
            }

        }
        if (Sprinting == true)
        {
            if (CDtimmer < SprintDuration)
            {
                moveSpeed = 10f;
                cam.fieldOfView = Mathf.Lerp(90f,75f,Time.deltaTime);

            }
            else
            {
                moveSpeed = 5f;
                Sprinting = false;
                cam.fieldOfView = Mathf.Lerp(75f, 90f,Time.deltaTime);
            }
        }
    }

    public void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    public void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");   

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * moveSpeed * Time.deltaTime);

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += g * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

      

}
