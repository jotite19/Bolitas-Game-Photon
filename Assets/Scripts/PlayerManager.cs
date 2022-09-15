using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManager : MonoBehaviour
{
    PhotonView Pv;
    public Vector3 spawnPos;

    private void Awake()
    {
        Pv = GetComponent<PhotonView>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (Pv.IsMine)
        {
            CreateController();
        }
    }

    // Update is called once per frame
    void CreateController()
    {
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), spawnPos, Quaternion.identity);
    }
}
