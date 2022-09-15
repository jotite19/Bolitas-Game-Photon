using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Photon.Pun;

public class BlockCasting : MonoBehaviour
{
    public Transform blockTransform;

    public void evoqueBlock()
    {
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Block"), blockTransform.position, blockTransform.rotation);
    }
}
