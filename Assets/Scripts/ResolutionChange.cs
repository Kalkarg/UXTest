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

    void ResolutionCheck() //This should occur every time the resolution is changed!
    {
        if (resolutionNumber < 1)
        {
            resolutionNumber = 1; //In case the player keeps going down resolutions, just set it back to 1. Not sure if this'll work.
            Debug.Log("how small???");
        }
        if (resolutionNumber == 1)
        {
            Screen.SetResolution(1280, 720, true); //Not sure if I can get away with not using the fullscreen bool.
            Debug.Log("Resolution is now 1280x720");
            resolutionText.text = "1280 x 720";
        }
        if (resolutionNumber == 2)
        {
            Screen.SetResolution(1366, 768, true); //Also I can't tell if this is actually working or not from the editor!
            Debug.Log("Resolution is now 1366x768");
            resolutionText.text = "1366 x 768";
        }
        if (resolutionNumber == 3)
        {
            Screen.SetResolution(1536, 864, true);
            Debug.Log("Resolution is now 1536x864");
            resolutionText.text = "1536 x 864";
        }
        if (resolutionNumber == 4)
        {
            Screen.SetResolution(1920, 1080, true);
            Debug.Log("Resolution is now 1920x1080");
            resolutionText.text = "1920 x 1080";
        }
        if (resolutionNumber > 4)
        {
            resolutionNumber = 4; //Upper bounds
            Debug.Log("alright future boy");
        }
    } //Resolutions gotten from https://www.browserstack.com/guide/common-screen-resolutions just in case they aren't provided by tutors

    public void MoreResolution()
    {
        resolutionNumber += 1; //Adds 1 to the resolution number.
        Debug.Log("Resolution Number: " + resolutionNumber);
        ResolutionCheck(); //Start the resolution check!
    }
    public void LessResolution()
    {
        resolutionNumber -= 1; //Take away 1 from the resolution number.
        Debug.Log("Resolution Number: " + resolutionNumber);
        ResolutionCheck();
    }
}
//this works??? am i smart????? huh????