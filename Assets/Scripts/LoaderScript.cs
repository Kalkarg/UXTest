using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoaderScript : MonoBehaviour
{
    public GameObject loadingScreen;
    public Image fill;
    public Text text;
    public Button loadLevelButton;
    private float _progress = 0f; //The progress our loading bar uses to determine it's fill.

    public void OnLoadLevelClick(int sceneIndex) //The int declaration here allows me to add in any scene number to the button function!
    {
        StartCoroutine(LoadAsync(sceneIndex)); //Starts loading the new scene asynchronously. Loads it while another scene plays.
    }

    IEnumerator LoadAsync(int sceneIndex) //The loading bar functions
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex); //What async is actually supposed to do
        operation.allowSceneActivation = false; //Unity loads in the scene immediately when it's done by default. This disables in when the button is pressed.
        while (_progress < 1f) //Unity measure scene loading from 0 to 1f depending on how loaded it is.
        {
            _progress =  Mathf.Clamp01(operation.progress / 0.9f); //0 - 0.9f for Unity is actually loading the scene, while the last .1f is switching to it. This divides loading bar progress to reflect that, so it doesn't stay at 90% when done.
            Debug.Log("Loading..." + (int)(_progress * 100f) + "%"); //Tells unity how much the scene is loaded, as a percentage.
            yield return null;
        }
        operation.allowSceneActivation = true; //Let unity activate the scene when all of this is done.
    }
}
//Lots of comments, first time using Async.