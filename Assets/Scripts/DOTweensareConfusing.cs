using UnityEngine;
using DG.Tweening;
using NUnit.Framework.Constraints;
using System.Collections;
using UnityEngine.UI;

public class DOTweensareConfusing : MonoBehaviour
{
    //public GameObject square;
    public Button thebuttonever;
    public AnimationCurve Weeee;
    public void FunnyButtonAction()
    {
        StartCoroutine(FunnySthuff());
    }

    public void Nomorefunnies()
    {
        StartCoroutine(NoFunAllowed());
    }

    private void SetInteractablesInChildren(bool isActive)
    {
        Button[] buttonsInChildren = GetComponentsInChildren<Button>(); //Any button that's a child of this object is put under the array.
        foreach (Button child in buttonsInChildren)
        {
            child.enabled = isActive; //Makes all button children active.
        }
    }
    IEnumerator FunnySthuff()
    {
        Debug.Log("Activated");
        thebuttonever.interactable = false;
        //transform.DOMove(new Vector2(1000,1000), 1f, false);
        //transform.DOMove(transform.position + new Vector3(500,10,0), 1f).SetEase(Weeee);
        GetComponent<RectTransform>().DOAnchorPos(GetComponent<RectTransform>().anchoredPosition + new Vector2(0,700), 0.2f, false);
        Debug.Log("Moved button");
        yield return new WaitForSeconds(1);
        Debug.Log("waited"); //hi
        thebuttonever.interactable = true;
    }
    IEnumerator NoFunAllowed()
    {
        Debug.Log("aw man");
        GetComponent<RectTransform>().DOAnchorPos(GetComponent<RectTransform>().anchoredPosition + new Vector2(0,-700), 0.2f, false);
        SetInteractablesInChildren(false); //Make the isactive bool in this field false.
        yield return new WaitForSeconds(1);
        Debug.Log("we are so back");
        SetInteractablesInChildren(true);
    }
}
