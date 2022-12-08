using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCoin : MonoBehaviour
{
    [SerializeField] private CoinStack CS;

    private void OnTriggerEnter(Collider other)
    {
        //float randomFallRot = Mathf.Clamp(0, -30, 30);

        if (other.transform.CompareTag("ChildCoin"))
        {
            Debug.Log(other.gameObject.name + " and " + transform.gameObject.name + " collided / -1 Coin");

            ChildCoinCollide(other.gameObject);
        }
    }

    public void ChildCoinCollide(GameObject other)
    {
        Destroy(other.gameObject.GetComponent<EarnCoin>());
        other.gameObject.GetComponent<Collider>().isTrigger = false;
        other.gameObject.GetComponent<Rigidbody>().useGravity = true;
        CS.coinList.Remove(other.gameObject);
        other.gameObject.transform.SetParent(null);
    }
}
