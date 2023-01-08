using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.Interaction.Toolkit.AR;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{

    public ARCameraManager cameraManager;
    public ARPlaneManager planeManager;
    public GameObject moveDeviceAnimation;

    // Toggle to enable or disable plane Manager
    private bool scanActive;

    // Display state of plane manager
    [SerializeField]
    Text scanActiveText;

    private bool showingMoveDevice;

    void Start() {
        moveDeviceAnimation.SetActive(true);
        showingMoveDevice = true;
        planeManager.enabled = true;
        scanActive = planeManager.isActiveAndEnabled;
    }


    void OnEnable() 
    {
        cameraManager.frameReceived += FrameChanged;
    }

    void OnDisable() 
    {
        cameraManager.frameReceived -= FrameChanged;
    }


    // Turn off Animation once area of plane scanned is of sufficient area
    void FrameChanged(ARCameraFrameEventArgs args)
    {
        if (planeManager.trackables.count > 0 && showingMoveDevice && HasBigEnoughPlane())
        {
            moveDeviceAnimation.SetActive(false);
            showingMoveDevice = false;
        }
    }

    bool HasBigEnoughPlane() {
        foreach (var plane in planeManager.trackables) {
            if (plane.size.x >= 0.1f && plane.size.y >= 0.1f) return true;
        }
        return false;
    }


    // Reset Application
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Quit Application
    public void Quit()
    {
        Application.Quit();
    }

    //Toggle to enable or disable plane manager
    public void ToggleScan()
    {
        scanActive = planeManager.isActiveAndEnabled;
        planeManager.enabled = !scanActive;

        // Check and return status of plane manager in Text
        if (planeManager.isActiveAndEnabled)
        {
            scanActiveText.text = "Toggle Scan \n ON";
            scanActiveText.color = Color.green;
        }

        else
        {
            scanActiveText.text = "Toggle Scan \n OFF";
            scanActiveText.color = Color.red;
        }
    }

}