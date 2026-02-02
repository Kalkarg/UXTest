using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoaderScript : MonoBehaviour
{
    private bool _isClicked = false; //For starting the game with a click, might not be necessary in the actual UI.
    public GameObject loadingScreen;
    public Image fill; //Special image type that has the image masked a certain amount depending on the value of it's 'fill'. Very helpful for loading bars.
    public TextMeshProUGUI loadingText;
    public Button loadLevelButton;
    [Range(0,1)] //Adds a slider for the inspector, between 0 and 1. For tbe _progress float.
    public float _progress = 0f; //The progress our loading bar uses to determine it's fill.

    public void OnLoadLevelClick(int sceneIndex) //The int declaration here allows me to add in any scene number to the button function!
    {
        loadingScreen.SetActive(true);
        loadLevelButton.interactable = false; //Prevents quick double clicking.
        StartCoroutine(LoadAsync(sceneIndex)); //Starts loading the new scene asynchronously. Loads it while another scene plays.
    }

    IEnumerator LoadAsync(int sceneIndex) //The loading bar functions
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex); //What async is actually supposed to do
        operation.allowSceneActivation = false; //Unity loads in the scene immediately when it's done by default. This disables in when the button is pressed.
        while (_progress < 1f) //Unity measure scene loading from 0 to 1f depending on how loaded it is.
        {
            _progress =  Mathf.Clamp01(operation.progress / 0.9f); //0 - 0.9f for Unity is actually loading the scene, while the last .1f is switching to it. This divides loading bar progress to reflect that, so it doesn't stay at 90% when done. Clamp01 keeps loading number in bounds of 0 and 1.
            fill.fillAmount = _progress; //Fills up the bar depending on the progress value of async.
            loadingText.text = "Loading..." + (int)(_progress * 100f) + "%"; //Tells the loading text how much the _progress value is as a percentage.
            yield return null;
        }
        loadingText.text = "Click anywhere to start!"; //Happens once the loading's done. Might not be necessary in the actual UI.
        while (!_isClicked) //Prevents coroutine from stopping when left clicking.
        {
            yield return null;
        }
        operation.allowSceneActivation = true; //Let unity activate the scene when all of this is done.
    }

    private void Update() //Might not be necessary in the actual UI.
    {
        if(Input.GetMouseButtonUp(0) && _progress == 1f) //If right click is released and the async loading progress has reached 1...
        {
            _isClicked = true;
        }
    }
}
//Lots of comments, first time using Async.