using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject finishGameUI;
    public GameObject failGameUI;

    public void openFinishGameUI()
    {
        finishGameUI.SetActive(true);
        failGameUI.SetActive(false);
    }

    public void openFailGameUI()
    {
        StartCoroutine(failUI());
    }

    public void closeAllUI()
    {
        finishGameUI.SetActive(false);
        failGameUI.SetActive(false);
    }

    IEnumerator failUI()
    {
        yield return new WaitForSeconds(2);
        finishGameUI.SetActive(false);
        failGameUI.SetActive(true);
    }
}
