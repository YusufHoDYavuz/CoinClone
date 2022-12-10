using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainCoin : MonoBehaviour
{
    [SerializeField] private float maxAngle;
    [SerializeField] private float coinsSpeed;
    [SerializeField] private CoinStack CS;
    [SerializeField] private BlockCoin BC;

    private bool isCollide;
    private List<GameObject> coinsList;

    private void Start()
    {
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

            if (coinsList.Count == 0)
            {
                MainBlockCollider();
                transform.DOMove(new Vector3(other.transform.position.x + 0.5f, other.transform.position.y + 0.2f, other.transform.position.z),1);
                transform.DORotate(new Vector3(90, 0, 0), 1);
            }
            /* else
            {
                 BC.ChildCoinCollide(coinsList[coinsList.Count].gameObject);
                 coinsList[coinsList.Count].transform.DOMove(new Vector3(other.transform.position.x + 0.5f, other.transform.position.y + 0.2f, other.transform.position.z), 1);
                 coinsList[coinsList.Count].transform.DORotate(new Vector3(90, 0, 0), 1);
            } */
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
