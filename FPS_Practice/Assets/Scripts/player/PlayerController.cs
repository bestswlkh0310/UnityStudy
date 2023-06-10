using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject cam;
    public GameObject gui;
    public TextMeshProUGUI itemGetterText;

    private Rigidbody rb;

    private Vector3 thirdPersonCamOffset;
    private Vector3 onePersonCamOffset;

    private RaycastHit hit;
    public float itemRayDistance;
    private int itemLayer;

    public static bool IsGround;
    private bool isOnePerson;

    public float speed;

    private float xInput;
    private float zInput;

    private float yRotation;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        thirdPersonCamOffset = cam.transform.position - transform.position;
        onePersonCamOffset = new Vector3(0.0f, 0.5f, 0.0f);
        itemLayer = 1 << 3;
    }

    void Update()
    {
        GetInput();
        Move();
        RotatePlayer();
        Jump();
        ChangePerson();
        RayItem();
    }

    private void Move()
    {
        Vector3 move = transform.forward * zInput + transform.right * xInput;

        transform.position += move.normalized * speed * Time.deltaTime;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGround)
        {
            IsGround = false;
            rb.AddForce(new Vector3(0.0f, 10.0f, 0.0f), ForceMode.Impulse);
        }
    }

    private void ChangePerson()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (isOnePerson)
            {
                cam.transform.localPosition = thirdPersonCamOffset;
                gui.SetActive(false);
            }
            else
            {
                cam.transform.localPosition = onePersonCamOffset;
                gui.SetActive(true);
            }

            isOnePerson = !isOnePerson;
        }
    }

    private void RayItem()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, itemRayDistance, itemLayer))
        {
            // Debug.Log("hit point : " + hit.point + ", distance : " + hit.distance + ", name : " + hit.collider.name);
            // Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
            itemGetterText.gameObject.SetActive(true);
            itemGetterText.text = hit.collider.name + " - [F]";
            if (Input.GetKeyDown(KeyCode.F))
            {
                GetItem();
            }
        }
        else
        {
            itemGetterText.gameObject.SetActive(false);
            // Debug.DrawRay(transform.position, transform.forward * 1000f, Color.red);
        }
    }

    private void GetItem()
    {
        Item itemGetted = new Item(hit.collider.name, hit.collider.name, 1, true);
        bool isAdded = Inventory.AddItem(itemGetted, 1);
        Debug.Log(isAdded);
        Debug.Log(Inventory.toString());
        if (isAdded)
        {
            Destroy(hit.collider.gameObject);
            ItemManager.items.Remove(hit.collider.gameObject.GetComponent<BulletItem>());
            
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