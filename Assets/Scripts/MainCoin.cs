using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            transform.GetComponent<MeshCollider>().enabled = true;
            transform.GetComponent<BoxCollider>().enabled = false;
            transform.GetComponent<MainCoin>().enabled = false;
            isCollide = true;

            for (int i = 0; i < coinsList.Count; i++)
            {
                BC.ChildCoinCollide(coinsList[i].gameObject);
            }
        }

        if (other.transform.CompareTag("Stairs"))
        {
            other.transform.GetComponent<Collider>().isTrigger = false;
            transform.position += new Vector3(0, 0.25f, 0);

        }
    }
}
