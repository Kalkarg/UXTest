using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class AnotherLoginScript : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public string adminUsername;
    public string adminPassword;
    public GameObject incorrectInfoText;

    private bool usernameCorrect;
    private bool passwordCorrect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        usernameCorrect = false;
        passwordCorrect = false;
    }

    public void OnLoginEnter()
    {
        adminUsername = usernameInput.text; //The string for the username and password is equal to whatever is inputted in the input fields.
        adminPassword = passwordInput.text;
        if (adminUsername == "Conductor") //If the text inputted is "Conductor"...
        {
            Debug.Log("correct!");
            usernameCorrect = true; //Changes the username correct bool to true for the ultimate check on whether or not both the username and password are correct.
        }
        else
        {
            Debug.Log("nope!");
            usernameCorrect = false;
        }
        if (adminPassword == "password123")
        {
            Debug.Log("correct password");
            passwordCorrect = true;
        }
        else
        {
            Debug.Log("X");
            passwordCorrect = false;
        }
        if (usernameCorrect == true && passwordCorrect == true)
        {
            SceneManager.LoadScene("GameMenu"); //Loads into the game menus scene (the ones beyond the log in screen). Because this function is attached to the log in button, it should occur very quickly after being pressed if all turns out right.
            Debug.Log("Check successful");
        }
        else
        {
            StartCoroutine(WrongTextAppears());
            usernameCorrect = false; //Make sure that the user can't input the correct username and password at seperate attempts.
            passwordCorrect = false;
            Debug.Log("Check failed");
        }
    }
    IEnumerator WrongTextAppears()
    {
        Debug.Log("Wrong text appears");
        incorrectInfoText.SetActive(true); //Activates the 'username or password is incorrect' text.
        yield return new WaitForSeconds(4); //Wait for the animation to finish
        incorrectInfoText.SetActive(false); //Should restart the animation if it ever becomes true again.
    }
}
