using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private GameObject finishPoint;
    [SerializeField] private GameObject mainCoin;
    [SerializeField] private Slider distanceBar;

    float maxDistance;
    
    void Start()
    {
        maxDistance = GetDistance();
    }

    void Update()
    {
        if (mainCoin.transform.position.y <= maxDistance && mainCoin.transform.position.y <= finishPoint.transform.position.y)
        {
            float distance = 1 - (GetDistance() / maxDistance);
            SetProgress(distance);
        }
    }

    float GetDistance()
    {
        return Vector3.Distance(mainCoin.transform.position, finishPoint.transform.position);
    }

    void SetProgress(float p)
    {
        distanceBar.value = p;
    }
}
