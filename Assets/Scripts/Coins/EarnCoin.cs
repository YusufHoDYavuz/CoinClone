using System.Collections;
using UnityEngine;

public class EarnCoin : MonoBehaviour
{
    [SerializeField] private float followSpeed;

    public void UpdateCoinPosition(Transform followedCoin, bool isFollowStart)
    {
        StartCoroutine(StartFollowingToLastCoinPosition(followedCoin, isFollowStart));
    }


    IEnumerator StartFollowingToLastCoinPosition(Transform followedCoin, bool isFollowStart)
    {
        while (isFollowStart)
        {
            yield return new WaitForEndOfFrame();
                transform.position = new Vector3(Mathf.Lerp(transform.position.x, followedCoin.position.x, followSpeed * Time.deltaTime),
                Mathf.Lerp(transform.position.y, followedCoin.position.y, followSpeed * Time.deltaTime), 
                Mathf.Lerp(transform.position.z, followedCoin.position.z + 0.08f, followSpeed * Time.deltaTime));
        }
    }

    public void UpdateCoinRotation(Transform followedCoin, bool isFollowStart)
    {
        StartCoroutine(StartFollowingToLastCoinRotation(followedCoin, isFollowStart));
    }

    IEnumerator StartFollowingToLastCoinRotation(Transform followedCoin, bool isFollowStart)
    {
        while (isFollowStart)
        {
            yield return new WaitForEndOfFrame();
            transform.rotation = Quaternion.Euler(transform.rotation.x, Mathf.Lerp(transform.rotation.y + 90, followedCoin.rotation.y, 1 * Time.deltaTime), transform.rotation.z);
        }
    }
}
