using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinStack : MonoBehaviour
{
    public List<GameObject> coinList = new List<GameObject>();

    public Text coinCount;

    private Vector3 firstCoinPos;
    private Vector3 currentCoinPos;

    private int coinListIndexCounter = 0;

    private void Update()
    {
        coinCount.text = "Coin Count: " + coinList.Count.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ChildCoin"))
        {
            coinList.Add(other.gameObject);
            Debug.Log("Earned Coin");

            if (coinList.Contains(other.gameObject))
            {
                if (coinList.Count == 1)
                {
                    firstCoinPos = GetComponent<MeshRenderer>().bounds.max;
                    currentCoinPos = new Vector3(other.transform.position.x, firstCoinPos.y - 0.15f, other.transform.position.z);
                    other.gameObject.transform.position = currentCoinPos;
                    currentCoinPos = new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z);
                    other.gameObject.GetComponent<EarnCoin>().UpdateCoinPosition(transform, true);
                }
                else if (coinList.Count > 1)
                {
                    other.gameObject.transform.position = currentCoinPos;
                    currentCoinPos = new Vector3(other.transform.position.x, other.gameObject.transform.position.y, other.transform.position.z + 0.3f);
                    other.gameObject.GetComponent<EarnCoin>().UpdateCoinPosition(coinList[coinListIndexCounter].transform, true);
                    coinListIndexCounter++;
                }
            }
        }
    }
}