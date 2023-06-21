using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addScoreArcade : MonoBehaviour
{
    public Text coinsFound;
    private int coinNum;
    public GameObject formCanvas;

    // Start is called before the first frame update
    void Start()
    {
        coinNum = 0;
        coinsFound.text = coinNum + "/5";
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            coinNum += 1;
            Destroy(other.gameObject);
            coinsFound.text = coinNum + "/5";
        }
        if (coinNum == 5)
        {
            formCanvas.SetActive(true);
            Debug.Log("Found all the coins!");
        }
    }
}