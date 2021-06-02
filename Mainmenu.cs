// This script is for the UI contaning the main menu
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainmenu : MonoBehaviour
{

    //allows you to set which screen you want for each script
    public GameObject Start;
    public GameObject Load;
    public GameObject escop;

    //checks the state of the selected screens above and changes is depending on if its avtive or unactive.
    bool state;

    public void Update()
    {
        //If you press escape the escape options ui will show on your screen allowing you to quit.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            state = !state;
            Debug.Log("works");
            escop.gameObject.SetActive(state);
        }
    }

    //If you click play game on the start page it will deactivate the start screen showing the loading screen
    public void PlayGame ()
    {
        state = !state;
        StartCoroutine(Loading());
        Start.gameObject.SetActive(state);
        
    }

    //Once Playgame is called the loading screen will appear for 3 seconds then deactivate showing the game and locking the cursor to the screen
    IEnumerator Loading()
    {
        yield return new WaitForSeconds(5f);
        state = !state;
        Load.gameObject.SetActive(state);
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("working");
    }


    //if you click any quit game button it will quit and close the game.
    public void quitgame()
    {
        Application.Quit();
    }


}
