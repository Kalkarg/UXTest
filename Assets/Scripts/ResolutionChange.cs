using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResolutionChange : MonoBehaviour
{
    public int resolutionNumber;
    public Image fill; //Not sure if I need this, or if I should use a sort of slider instead.
    public TextMeshProUGUI resolutionText;
    public Button leftResolutionButton;
    public Button rightResolutionButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() //this'll apply itself every frame, this might not be a great place to put it.
    {
        if (resolutionNumber <= 1)
        {
            resolutionNumber = 1; //In case the player keeps going down resolutions, just set it back to 1. Not sure if this'll work.
        }
        if (resolutionNumber == 1)
        {
            Screen.SetResolution(1280, 720, true); //Not sure if I can get away with not using the fullscreen bool.
        }
        if (resolutionNumber == 2)
        {
            Screen.SetResolution(1366, 768, true);
        }
        if (resolutionNumber == 3)
        {
            Screen.SetResolution(1536, 864, true);
        }
        if (resolutionNumber == 4)
        {
            Screen.SetResolution(1920, 1080, true);
        }
        if (resolutionNumber >= 4)
        {
            resolutionNumber = 4; //Upper bounds
        }
    } //Resolutions gotten from https://www.browserstack.com/guide/common-screen-resolutions just in case they aren't provided by tutors

    void MoreResolution()
    {
        resolutionNumber += 1; //Adds 1 to the resolution number.
        Debug.Log("Resolution Number: " + resolutionNumber);
    }
    void LessResolution()
    {
        resolutionNumber -= 1; //Take away 1 from the resolution number.
        Debug.Log("Resolution Number: " + resolutionNumber);
    }
}
