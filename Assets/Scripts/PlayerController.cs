using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;
    [SerializeField]
    private GameObject head;
    [SerializeField]
    private GameObject pistol;
    [SerializeField, Range(0, 10)]
    private float sensetivity = 1.5f;

    private Rigidbody rb;
    private Vector2 resultMousePosition = Vector2.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        var vector = new Vector3(horizontalInput, 0, verticalInput) * speed;
        rb.velocity = transform.rotation * vector;

        var mouseVectorX = Input.GetAxis("Mouse X");
        var mouseVectorY = Input.GetAxis("Mouse Y");
        var mouseVector = new Vector2(mouseVectorX, mouseVectorY);

        resultMousePosition += mouseVector * sensetivity;
        resultMousePosition.y = Mathf.Clamp(resultMousePosition.y, -89, 89);


        transform.eulerAngles = new Vector3(0, resultMousePosition.x, 0);
        head.transform.localEulerAngles = new Vector3(-resultMousePosition.y, 0, 0);
    }
}
