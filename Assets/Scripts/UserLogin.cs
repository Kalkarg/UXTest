using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UserLogin : MonoBehaviour
{
    [SerializeField] private TMP_Text _textResponse; //For the message that pops up when doing something wrong.
    [SerializeField] private Button _createaccountButton;
    [Space] [Space] //Adds spaces between sections in the inspector
    [SerializeField] private GameObject _loginScreen; //In the example, two parent objects covering both the log in and create account sections are present. this might not be suitable for my project.
    [SerializeField] private TMP_InputField _inputLoginUsername; //Referencing the input fields' text component
    [SerializeField] private TMP_InputField _inputLogInPassword;
    [SerializeField] private Button loginButton;
    [Space] [Space]
    [SerializeField] private GameObject _createaccountScreen;
    [SerializeField] private TMP_InputField _inputCreateUsername; //For the create account screen
    [SerializeField] private TMP_InputField _inputCreatePassword;
    [SerializeField] private Button createaccountButton;
    private string _username; //The actual username and password, assumedly the one that's 'set up' by the user.
    private string _password;

    public void CreateAccountButton() //Triggered when you press the create account button on the log in menu. I'm not sure what system my UI will use yet.
    {
        ShowCreateElements();
        _textResponse.text = "Please create an account";
        Debug.Log("Switched to create account");
    }

    public void OnButtonCreate() //For pressing 'create account'
    {
        if (CheckCreateFields()) //If the fields aren't empty
        {
            _username = _inputCreateUsername.text; //Sets the username string to whatever the user inputted in the fields
            _password = _inputCreatePassword.text;
            _textResponse.text = "Account created! Please log in!";
            ShowLoginElements(); //Not sure if I'll need this or not
            Debug.Log(message:"Username: " + _username + " Password: " + _password);
        }
    }

    public void OnButtonLogin() //For pressing 'log in' on the log in screen.
    {
        if (CheckLoginFields())
        {
            if (VerifyLoginCredentials()) //If the login information matches the ones registered. Seems to read the bool results for what to do in the if statement.
            {
                _textResponse.text = "You are now logged in!";
                Debug.Log("Correct info");
            }
            else
            {
                _textResponse.text = "Username or Password is incorrect";
                Debug.Log("Incorrect info");
            }
        }
    }

    private bool VerifyLoginCredentials() //For checking whether or not the input fields' inputs match the one's registered.
    {
        bool results;
        if (_username == _inputLoginUsername.text && _password == _inputLogInPassword.text)
        {
            results = true; //If the login details match the string, the bool is set to true.
            Debug.Log("Info matches data");
        }
        else
        {
            results = false;
            Debug.Log("Info did not match data");
        }
        return results;
    }

    private bool CheckCreateFields() //Checks requirements for creating username and password.
    {
        bool results;
        if (_inputCreateUsername.text != string.Empty && _inputCreatePassword.text != string.Empty) //If the username and password input fields aren't left empty...
        {
            results = true;
            Debug.Log("Account created!");
        }
        else
        {
            results = false;
            _textResponse.text = "Please fill both fields.";
            Debug.Log("Invalid Account");
        }
        return results;
    }

    private bool CheckLoginFields() //Checks log in username and password.
    {
        bool results;
        if (_inputLoginUsername.text != string.Empty && _inputLogInPassword.text != string.Empty)
        {
            results = true;
            Debug.Log("Login info valid");
        }
        else
        {
            results = false;
            _textResponse.text = "Both fields are required.";
            Debug.Log("Empty field");
        }
        return results;
    }

    private void ShowLoginElements() //For the 'log in instead' button. Might change depending on the UI organisation method used.
    {
        _createaccountScreen.SetActive(false);
        _loginScreen.SetActive(true);
        Debug.Log("Switched to log in screen");
    }

    private void ShowCreateElements()
    {
        _loginScreen.SetActive(false);
        _createaccountScreen.SetActive(true);
        Debug.Log("Switched to create account screen");
    }
}
