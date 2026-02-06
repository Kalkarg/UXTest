using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening; //For DOTween

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField] int volume;
    public GameObject TitleMenu;
    public GameObject OptionsMenu;
    //public GameObject PauseMenu;
    public GameObject ConfirmationScreen;

    public GameObject MainMenu;
    public GameObject LoginMenu;

    public Vector3 MenuGlideValue;

    public void StartGame()
    {
        //SceneManager.LoadScene("Main Game"); //or whatever the next menu must be
        //Or if you're wanting this in the same scene...
        //TitleMenu.SetActive(false);
        LoginMenu.SetActive(true);
        //LoginMenu.transform.DOMove(LoginMenu.transform.position + MenuGlideValue, 1f); //Asks the DOTween extension to move a set amount. This doesn't move the object correctly for some reason, as it always moves to the exact same spot.
        Debug.Log("Moved menu");
    }

    public void OptionsButton() //I remembered how these work, which I'm happy with myself about
    {
        TitleMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void ResetToDefault()
    {
        //This would tweak all setting values back to their default state, probably through executing each 'public void' the functions to change back to the original fall under.
        ConfirmationScreen.SetActive(true);
        Debug.Log("Haven't figured this out yet!");
    }

    public void LeaveOptionsToTitle() //Can I do the 'back' function for any menu in one function? Does that need an array?
    {
        OptionsMenu.SetActive(false);
        TitleMenu.SetActive(true);
    }

    public void LeaveMainMenuToTitle()
    {
        MainMenu.SetActive(false);
        TitleMenu.SetActive(true);
    }

    public void SaveOptions()
    {
        //something something scriptable object
        Debug.Log("Settings Saved");
    }

    public void YesImSureSetDefaults()
    {
        ConfirmationScreen.SetActive(false);
        Debug.Log("Set to defaults");
    }

    public void NoImNotSureSetDefaults()
    {
        ConfirmationScreen.SetActive(false);
        Debug.Log("Defaults weren't set");
    }

    public void LeaveApplication() //The exit button on the main menu
    {
        Application.Quit();
        Debug.Log("Application Quit!");
    }
}
