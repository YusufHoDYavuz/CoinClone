using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BlocksController : MonoBehaviour
{
    [Header("Stick")]
    [SerializeField] private float stickTurnSpeed;
    [SerializeField] private List<GameObject> sticks = new List<GameObject>();

    [Space]
    [Header("Axe")]
    [SerializeField] private List<GameObject> axes = new List<GameObject>();

    [Space]
    [Header("Door")]
    [SerializeField] private List<GameObject> door = new List<GameObject>();

    [Space]
    [Header("OpenAndCloseRoad")]
    [SerializeField] private List<GameObject> leftBlocks = new List<GameObject>();
    [SerializeField] private List<GameObject> rightBlocks = new List<GameObject>();

    private void Start()
    {
        InvokeRepeating("RepeatMovement", 1, 2);
        InvokeRepeating("OpenAndCloseRoadDelay", 0.01f, 6);
    }

    void FixedUpdate()
    {
        for (int i = 0; i < sticks.Count; i++)
        {
            sticks[i].transform.Rotate(new Vector3(0, 0, 30) * Time.deltaTime * stickTurnSpeed);
        }

        
    }

    void OpenAndCloseRoadDelay()
    {
        StartCoroutine(OpenAndCloseRoad());
    }

    void RepeatMovement()
    {
        
        StartCoroutine(axeMovement());
        StartCoroutine(doorMovement());
    }

    IEnumerator axeMovement()
    {
        for (int i = 0; i < axes.Count; i++)
        {
            axes[i].transform.DORotate(new Vector3(-20, 90, 0), 1).SetEase(Ease.OutBounce);
            yield return new WaitForSeconds(1);
            axes[i].transform.DORotate(new Vector3(-90, 90, 0), 1).SetEase(Ease.InSine);
        }
    }

    IEnumerator doorMovement()
    {
        for (int i = 0; i < door.Count; i++)
        {
            door[i].transform.DOLocalMove(new Vector3(0, -1f, 0), 1).SetEase(Ease.OutBounce);
            yield return new WaitForSeconds(1);
            door[i].transform.DOLocalMove(new Vector3(0, -0.25f, 0), 1).SetEase(Ease.InSine);
        }
    }

    IEnumerator OpenAndCloseRoad()
    {
        for (int i = 0; i < leftBlocks.Count; i++)
        {
            leftBlocks[i].transform.DORotate(new Vector3(0, 0, 405), 3).SetEase(Ease.InBack);
            yield return new WaitForSeconds(3);
            leftBlocks[i].transform.DORotate(new Vector3(0, 0, 315), 3).SetEase(Ease.InBack);
        }

        for (int i = 0; i < rightBlocks.Count; i++)
        {
            rightBlocks[i].transform.DORotate(new Vector3(0, 0, 315), 3).SetEase(Ease.InBack);
            yield return new WaitForSeconds(3);
            rightBlocks[i].transform.DORotate(new Vector3(0, 0, 405), 3).SetEase(Ease.InBack);
        }
    }
}
