using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;
using System.Collections;
using UnityEngine.UI;

public class TweenTest : MonoBehaviour
{
    public Vector3 MoveThing;

    public AnimationCurve EaseCurve;
    public RectTransform RectTransform;
    public Button startbutton;
    public async Task Shake() //Ienumerator
    {
        await RectTransform.DOPunchAnchorPos(new Vector2 (-400,0), 2, 1).AsyncWaitForCompletion(); 
        Debug.Log("Something cool happened");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            //transform.DOMove(transform.position + Vector3.up *500, 0.5f).SetEase(EaseCurve); //Move cube by 50 x, at half speed, with a delay of 1 second.
            //transform.DOLocalMoveY(10f, 1f, true).SetLoops(1, LoopType.Incremental).From(); //Moves objects to a specific y position, defining it's speed and whether or not it should snap to integers.
            //Debug.Log("Moved cube");
            //CoolThing();
            StartCoroutine(CoolerThing());
        }
    }

    public async Task CoolThing() //Async?
    {
            await transform.DOMove(transform.position + Vector3.up *500, 0.5f).SetEase(EaseCurve).AsyncWaitForCompletion(); //Move cube by 50 x, at half speed, with a delay of 1 second.
            //transform.DOLocalMoveY(10f, 1f, true).SetLoops(1, LoopType.Incremental).From(); //Moves objects to a specific y position, defining it's speed and whether or not it should snap to integers.
            Debug.Log("Moved cube");
    }

    IEnumerator CoolerThing()
    {
        Debug.Log("Cooler Thing activated");
        Tween coolthing = transform.DOMove(transform.position + Vector3.right * 100, 0.75f).SetLoops(3, LoopType.Yoyo); //Wait for the loop to complete before executing again?
        startbutton.interactable = false;
        yield return coolthing.WaitForCompletion();
        //Figure out how to disable buttons
        startbutton.interactable = true;
        Debug.Log("Finished coolerthing coroutine");
}
}
