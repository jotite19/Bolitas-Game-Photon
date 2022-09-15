using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Photon.Pun;

public class Shooting : MonoBehaviour
{
    public Transform m_FireTransform;        

    [SerializeField] Transform orientation;
    [SerializeField] KeyCode fireButton = KeyCode.Mouse0;
    Vector3 shootDirection;
    Vector3 moveDirection;

    public int m_PlayerNumber = 1;
    public float shootForce = 150f;
         
    private void Update()
    {
        if (!drawingMenu.isDrawing)
        {
            if (Input.GetKeyDown(fireButton))
            {
                //Fire();
            }
        }
    }

    private void Fire()
    {
        GameObject triangleInstance = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Bullet"), m_FireTransform.position, m_FireTransform.rotation);
        Rigidbody RBbulletInstance = triangleInstance.GetComponent<Rigidbody>();
        shootDirection = orientation.forward * shootForce + moveDirection;
        RBbulletInstance.AddForce(shootDirection, ForceMode.Impulse);
    }

    public void TriangleShooting()
    {
        GameObject triangleInstance = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Triangle"), m_FireTransform.position, m_FireTransform.rotation);
        Rigidbody RBbulletInstance = triangleInstance.GetComponent<Rigidbody>();
        shootDirection = orientation.forward * shootForce + moveDirection;
        RBbulletInstance.AddForce(shootDirection, ForceMode.Impulse);
    }
}