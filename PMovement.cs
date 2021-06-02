//this script is used to allow the player to move 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMovement : MonoBehaviour
{

    //assigning character controller
    CharacterController Controller;

    // used to set the movement features of the character in the inspector
    public float Speed;

    public Transform Cam;

    [SerializeField]
    private float gravity = 5f;
   


    // Start is called before the first frame update
    void Start()
    {

        Controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        //sets the players movement horizontally and vertically so they can move wherever in the world space.
        float Horizontal = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        float Vertical = Input.GetAxis("Vertical") * Speed * Time.deltaTime;

        Vector3 Movement = Cam.transform.right * Horizontal + Cam.transform.forward * Vertical;

        //checks if the player is grounded if yes they can jump if no they cannot jump
       

        Movement.y -= gravity * Time.deltaTime;
        
        Controller.Move(Movement);


        if (Movement.magnitude != 0f)
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Cam.GetComponent<CameraMove>().sensivity * Time.deltaTime);


            Quaternion CamRotation = Cam.rotation;
            CamRotation.x = 0f;
            CamRotation.z = 0f;

            transform.rotation = Quaternion.Lerp(transform.rotation, CamRotation, 0.1f);

        }
    }

}