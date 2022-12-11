using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public GameObject finishGameUI;
    public GameObject failGameUI;
    public GameObject swipeToPlayText;
    public GameObject swipeToPlayPanel;
    public GameObject mainCoin;

    private void Start()
    {
        swipeToPlayText.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.5f).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

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

    public void StartGame()
    {
        swipeToPlayPanel.SetActive(false);
        mainCoin.transform.GetComponent<MainCoin>().enabled = true;
    }

    IEnumerator failUI()
    {
        yield return new WaitForSeconds(2);
        finishGameUI.SetActive(false);
        failGameUI.SetActive(true);
    }
}
