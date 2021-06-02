using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Player_Networking : MonoBehaviour
{
    //Allows you to ignore certain scripts in the inspector so players dont run the same scirpt
    [SerializeField] private MonoBehaviour[] scriptsToIgnore;
    
    //Allows you to specify the players camera
    [SerializeField] private GameObject playerCamera;
    
    private PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {

        //sets it so if the camera that is being used is not yours it will deactivate and then yours will show
        photonView = GetComponent<PhotonView>();
        if (!photonView.IsMine)
        {
            playerCamera.SetActive(false);
            foreach (var scripts in scriptsToIgnore)
            {
                scripts.enabled = false;
            }
        }
        else
        {
            playerCamera.SetActive(true);


        }
    }
}


