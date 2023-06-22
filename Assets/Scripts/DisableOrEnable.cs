using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOrEnable : MonoBehaviour
{
    public GameObject disableorenable;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void whenButtonClicked()
    {
        if (disableorenable.activeInHierarchy == true)
        {
            disableorenable.SetActive(false);
        }
        else
        {
            disableorenable.SetActive(true);
        }

    }
}
