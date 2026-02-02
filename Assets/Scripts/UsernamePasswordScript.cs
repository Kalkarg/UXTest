using UnityEngine;
using TMPro;

public class UsernamePasswordScript : MonoBehaviour
{
    [SerializeField] TMP_InputField _usernameInputField, _passwordInputField; //For attaching Unity's input fields to the script.
    [SerializeField] GameObject _loginCanvas;
    [SerializeField] GameObject _accountcreationCanvas;
    [SerializeField] TMP_Text _debugText; //For pop ups relating to informing the user of status.
    private string _username = null;
    private string _password = null;
    private void Start()
    {
        DebugTextPrompt(""); //Debug text value is empty until we input something.
        //_accountcreationCanvas.SetActive(false); //The log in screen needs to show up first!
    }

    public void CreateAccountButton()
    {
        ChangePlaceHolderText("Create Username...", "Create Password..."); //Swaps whatever placeholder text is in the input fields to this. I think the UI has a seperate menu for this, so this isn't needed.
        _loginCanvas.SetActive(false);
        _accountcreationCanvas.SetActive(true);
        DebugTextPrompt(""); //Make sure the debug text says nothing yet.
        ResetTextInput(); //Cleans the input fields on any inputs.
        _username = null;
        _password = null;
    }

    private void ChangePlaceHolderText(string username, string password) //For changing and editing the default text inside the input fields.
    {
        var _usernamePlaceHolder = _usernameInputField.placeholder; //Create a new variable for using the input field's placeholders.
        var _passwordPlaceHolder = _passwordInputField.placeholder;
        _usernamePlaceHolder.gameObject.GetComponent<TextMeshProUGUI>().text = username; //What string username is.
        _passwordPlaceHolder.gameObject.GetComponent<TextMeshProUGUI>().text = password;
    }

    private void DebugTextPrompt(string text)
    {
        _debugText.text = text; //For clarifying what the string of debug text is?
    }

    public void GetUsername()
    {
        _username = _usernameInputField.text; //Connects the username string to the username input field.
    }

    public void GetPassword()
    {
        _password = _passwordInputField.text;
    }

    public void LogIn()
    {
        string tempUsername = _usernameInputField.text; //Assumedly declares the temporary usernames and passwords you enter in.
        string tempPassword = _passwordInputField.text; 

        if(tempPassword.Equals(_password) && tempUsername.Equals(_username)) //If the password typed in match the username and password strings saved...
        {
            DebugTextPrompt("Successful Login");
            Debug.Log("log in"); //Doesn't work :(
        }
        else
        {
            ResetTextInput();
            DebugTextPrompt("Incorect Username or Password");
        }
    }

    public void ConfirmAccountCreation()
    {
        if (_username.Length < 3)
        {
            DebugTextPrompt("Username is too short!");
            ResetTextInput();
            _username = null; //I'm assuming these are the strings that handle usernames. Clearing it to null means clearing any input for it to be used again.
            Debug.Log("Username too short");
        }
        else if (_username != null && _password !=null) //if both input fields are filled, and the previous if isn't triggered...
        {
            DebugTextPrompt("Account Created Successfully!");
            ChangePlaceHolderText("Enter Username...", "Enter Password...");
            ResetTextInput();
            Debug.Log($"{_username},{_password}"); //Shows us the username and password creating inside the debug logs.
            _loginCanvas.SetActive(true);
            _accountcreationCanvas.SetActive(false);
        }
    }

    public void CancelSignUpButton() //For going back to the log in screen.
    {
        ChangePlaceHolderText("Enter Username...", "Enter Password...");
        ResetTextInput();
        _loginCanvas.SetActive(true);
        _accountcreationCanvas.SetActive(false);
    }

    private void ResetTextInput() //Function for, well, resetting the text inputs.
    {
        _usernameInputField.text = "";
        _passwordInputField.text = "";
    }
}

