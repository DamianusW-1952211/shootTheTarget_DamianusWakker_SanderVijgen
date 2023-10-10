using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject GameManager;
    [SerializeField]
    private GameObject Restart;
    [SerializeField]
    private GameObject StartBT;
    [SerializeField]
    private GameObject Back;
    private int wait_periode = 0;
    private string collisionString;
    [SerializeField]
    private GameObject pointer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameManager.GetComponent<TargetManager>().SetMenuActive(true);
        wait_periode++;
        /*
        if (GameManager.GetComponent<TargetManager>().CountdownComplete())
        {
            GameManager.GetComponent<TargetManager>().Back();
            GameManager.GetComponent<TargetManager>().SetMenuActive(false);
            Debug.Log("Back");
            pointer.SetActive(false);
        }
        */
        if (wait_periode > 5)
        { //so that you dont accedently prees the buttons when trying to activate the menu the menu is onresponsive for a couple of tics
            collisionString = pointer.GetComponent<PointerScript>().WatsTheHit(); //gets the name of the button that is hit with the laser beam
            Debug.Log(collisionString);

            if (collisionString == "RestartButton" && OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
            { //checks if the button is hit and if the spray is on
                GameManager.GetComponent<TargetManager>().Restart();
                GameManager.GetComponent<TargetManager>().SetMenuActive(false);
                Debug.Log("Restart");
                pointer.SetActive(false);
            }

            else if (collisionString == "Start" && OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
            {
                GameManager.GetComponent<TargetManager>().Starter();
                GameManager.GetComponent<TargetManager>().SetMenuActive(false);
                Debug.Log("Start");
                pointer.SetActive(false);
            }
            else if (collisionString == "BackButton" && OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
            {
                GameManager.GetComponent<TargetManager>().Back();
                GameManager.GetComponent<TargetManager>().SetMenuActive(false);
                Debug.Log("Back");
                pointer.SetActive(false);
            }
        }
    }
}