using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    private const float YMin = -50.0f;
    private const float YMax = 50.0f;

    public Transform lookAt;

    public Transform Player;

    public float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    public float sensivity = 50.0f;

    public static KeyCode[] Activate = new KeyCode[] { KeyCode.LeftAlt, KeyCode.Escape };


    // Start is called before the first frame update
    void Start()
    {
        

    }

    
    private void Update()
    {
        //If escape is pressed it unlocks the cursor
        if (Input.GetKey(KeyCode.Escape))    
            Cursor.lockState = CursorLockMode.None;

        //if the cursor is unlocked and you press left click it will lock it again.
        
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
                
        
            
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //allows for control of the camera
        currentX += Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        currentY += Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;

        currentY = Mathf.Clamp(currentY, YMin, YMax);

        //moves the camera along with the player and changes the positin if they roatate or move while also keeping track of the camera movements
        Vector3 Direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = lookAt.position + rotation * Direction;

        //allows you to set where the camera will be focused on the player
        transform.LookAt(lookAt.position);



    }
}



