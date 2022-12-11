using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MainCoin : MonoBehaviour
{
    [SerializeField] private float maxAngle;
    [SerializeField] private float coinsSpeed;
    [SerializeField] private GameObject earnCoinPrefab;
    [SerializeField] private GameObject mainCoinPrefab;
    [SerializeField] private Text stairsEarnCount;
    [SerializeField] private CoinStack CS;
    [SerializeField] private BlockCoin BC;

    private bool isCollide;
    private bool isCollideStairs;
    private int stairsEarnCounter;
    private List<GameObject> coinsList;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        coinsList = CS.coinList;
    }

    void FixedUpdate()
    {
        if (!isCollide)
        {
            transform.localPosition += transform.right * Time.deltaTime * coinsSpeed;
        }

        if (Input.GetKey(KeyCode.A))
         {
            transform.Rotate(new Vector3(0, -45, 0) * Time.deltaTime * maxAngle);
         }

         if (Input.GetKey(KeyCode.D))
         {
            transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime * maxAngle);
         }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Block"))
        {
            Debug.Log(transform.gameObject.name + "and" + other.gameObject.name + "Collide");
            rb.constraints = RigidbodyConstraints.None;
            MainBlockCollider();

            for (int i = 0; i < coinsList.Count; i++)
            {
                BC.ChildCoinCollide(coinsList[i].gameObject);
            }
        }

        if (other.transform.CompareTag("Stairs"))
        {
            other.transform.GetComponent<Collider>().isTrigger = false;
            transform.position += new Vector3(0, 0.25f, 0);

            if (isCollide == false && !isCollideStairs)
            {
                transform.gameObject.GetComponent<MeshRenderer>().enabled = false;
                transform.GetChild(1).gameObject.SetActive(false);
                GameObject newMainCoin = Instantiate(mainCoinPrefab, Vector3.zero, Quaternion.identity);
                newMainCoin.transform.DOMove(new Vector3(other.transform.position.x + 0.5f, other.transform.position.y + 0.15f, other.transform.position.z), 1).SetEase(Ease.InBounce);
                newMainCoin.transform.DORotate(new Vector3(90, 0, 0), 1);
                newMainCoin.transform.GetComponent<MeshRenderer>().enabled = true;
                newMainCoin.transform.GetComponent<MainCoin>().enabled = false;
                newMainCoin.transform.GetComponent<CoinStack>().enabled = false;
                newMainCoin.transform.GetComponent<PlayerController>().enabled = false;
                newMainCoin.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                isCollideStairs = true;
                stairsEarnCounter++;
                stairsEarnCount.text = stairsEarnCounter.ToString();
            }
            else if(coinsList.Count > 0)
            {
                coinsList[coinsList.Count - 1].gameObject.transform.GetComponent<MeshRenderer>().enabled = false;
                BC.ChildCoinCollide(coinsList[coinsList.Count - 1].gameObject);
                GameObject newEarnCoin = Instantiate(earnCoinPrefab, Vector3.zero, Quaternion.identity);
                newEarnCoin.transform.DOMove(new Vector3(other.transform.position.x + 0.5f, other.transform.position.y + 0.15f, other.transform.position.z), 1).SetEase(Ease.InBounce);
                newEarnCoin.transform.DORotate(new Vector3(90, 0, 0), 1);
                stairsEarnCounter++;
                stairsEarnCount.text = stairsEarnCounter.ToString();
            }
            else if (coinsList.Count == 0)
            {
                Time.timeScale = 0;
            }
        }
    }

    void MainBlockCollider()
    {
        transform.GetComponent<MeshCollider>().enabled = true;
        transform.GetComponent<BoxCollider>().enabled = false;
        transform.GetComponent<MainCoin>().enabled = false;
        isCollide = true;
    }
}
