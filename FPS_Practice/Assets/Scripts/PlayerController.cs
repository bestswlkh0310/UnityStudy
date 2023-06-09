using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static bool isGround;
    private bool isOnePerson;
    public GameObject cam;

    public float speed;

    private Rigidbody rb;
    private float xInput;
    private float zInput;

    private float yRotation;
    private Vector3 ThirdPersonCamOffset;
    private Vector3 OnePersonCamOffset;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ThirdPersonCamOffset = cam.transform.position - transform.position;
        OnePersonCamOffset = new Vector3(0.0f, 0.5f, 0.0f);
        
    }

    void Update()
    {
        GetInput();
        Move();
        RotatePlayer();
        Jump();
        ChangePerson();
    }

    private void Move()
    {
        Vector3 move = transform.forward * zInput + transform.right * xInput;
        
        transform.position += move.normalized * speed * Time.deltaTime;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            isGround = false;
            rb.AddForce(new Vector3(0.0f, 10.0f, 0.0f), ForceMode.Impulse);
        }
    }

    private void ChangePerson()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (isOnePerson)
            {
                cam.transform.localPosition = ThirdPersonCamOffset;
            }
            else
            {
                cam.transform.localPosition = OnePersonCamOffset;
            }

            isOnePerson = !isOnePerson;
        }
    }

    private void RotatePlayer()
    {
        transform.Rotate(new Vector3(0.0f, yRotation * 10, 0.0f));
    }

    private void GetInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        zInput = Input.GetAxisRaw("Vertical");

        yRotation = Input.GetAxisRaw("Mouse X");
        
    }
}

