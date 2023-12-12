using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AuditoriumFirstEntry : MonoBehaviour
{
    [SerializeField]
    public GameObject email;
    public GameObject Form;

    private string Email;

    private string BASE_URL = "https://docs.google.com/forms/u/1/d/e/1FAIpQLSfTAgb1Rt-odx5qJbdf-nDdLEyPcMTU_h8NRQoGUz6KoDR5Zg/formResponse";

    public void Send()
    {
        Email = email.GetComponent<InputField>().text;

        if (string.IsNullOrEmpty(Email))
        {
            Form.SetActive(true);
        }
        else
        {
            StartCoroutine(Post(Email));
            Destroy(Form);
        }
    }

    IEnumerator Post(string email)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.1743637214", email);

        UnityWebRequest www = UnityWebRequest.Post(BASE_URL, form);
        yield return www.SendWebRequest();
    }

}
