using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerLook : MonoBehaviour
{
    [Header("References")]
    //[SerializeField] WallRun wallRun;

    [SerializeField] private float sensX = 100f;
    [SerializeField] private float sensY = 100f;

    [SerializeField] Transform cam = null;
    [SerializeField] Transform bulletCanon = null;
    [SerializeField] Transform blockCanon = null;
    [SerializeField] Transform orientation = null;

    PhotonView view;
    float mouseX;
    float mouseY;

    float multiplier = 0.01f;

    float xRotation;
    float yRotation;

    private void Awake()
    {
        view = GetComponent<PhotonView>();
    }

    private void Start()
    {
        if (!view.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
            Destroy(GetComponentInChildren<Canvas>().gameObject);
        }
    }

    public void Update()
    {
        if (!drawingMenu.isDrawing)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            mouseX = Input.GetAxisRaw("Mouse X");
            mouseY = Input.GetAxisRaw("Mouse Y");

            yRotation += mouseX * sensX * multiplier;
            xRotation -= mouseY * sensY * multiplier;

            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            cam.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.transform.rotation = Quaternion.Euler(0, yRotation, 0);
            bulletCanon.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            blockCanon.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}