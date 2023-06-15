using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objPopup : MonoBehaviour
{
    public GameObject ObjectPopup;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ObjectPopup.SetActive(true);
        }
    }
}
