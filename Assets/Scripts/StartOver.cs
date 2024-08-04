/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartOver : MonoBehaviour
{
    public GameObject popupCanvas, player; // Assign the popup Canvas in the Inspector
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        popupCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("VR_A_Button") && !isPaused)
        {
            Pause();
        }
        else if (Input.GetButtonDown("VR_A_Button") && isPaused)
        {
            Resume();
        }
    }

    void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f; // Pause the game
        PositionPopup();
        popupCanvas.SetActive(true); // Show the popup
    }

    void PositionPopup()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 forwardDirection = player.transform.forward;
        Vector3 popupPosition = playerPosition + forwardDirection * 1.0f + Vector3.up * 0.8f; // Adjust distance and height as needed
        popupCanvas.transform.position =  new Vector3 (popupPosition.x + 0.4f, popupPosition.y, popupPosition.z);

        // Optionally, you can also make the popup face the player
        popupCanvas.transform.rotation = Quaternion.LookRotation(forwardDirection);
    }

    void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f; // Resume the game
        popupCanvas.SetActive(false); // Hide the popup
    }

    public void Again()
    {
        Time.timeScale = 1f; // Resume the game
        UnityEngine.SceneManagement.SceneManager.LoadScene("Opening");
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartOver : MonoBehaviour
{
    public GameObject popupCanvas; // Assign the popup Canvas in the Inspector
    public Transform cameraTransform;
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        popupCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
        {
            PositionPopup();
        }

        if (Input.GetButtonDown("VR_A_Button") && !isPaused)
        {
            Pause();
        }
        else if (Input.GetButtonDown("VR_A_Button") && isPaused)
        {
            Resume();
        }
    }

    void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f; // Pause the game
        popupCanvas.SetActive(true); // Show the popup
        PositionPopup(); // Position the popup immediately when paused
    }

    void PositionPopup()
    {
        Vector3 playerPosition = cameraTransform.position;
        Vector3 forwardDirection = cameraTransform.forward;
        Vector3 popupPosition = playerPosition + forwardDirection * 1.0f + Vector3.up * 0.2f; // Adjust distance and height as needed
        popupCanvas.transform.position = popupPosition;

        // Make the popup face the player
        popupCanvas.transform.rotation = Quaternion.LookRotation(forwardDirection);
    }

    void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f; // Resume the game
        popupCanvas.SetActive(false); // Hide the popup
    }

    public void Again()
    {
        Time.timeScale = 1f; // Resume the game
        UnityEngine.SceneManagement.SceneManager.LoadScene("Opening");
    }
}
