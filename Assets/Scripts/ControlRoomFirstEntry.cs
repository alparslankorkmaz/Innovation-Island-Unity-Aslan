using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ControlRoomFirstEntry : MonoBehaviour
{
    [SerializeField]
    public GameObject email;
    public GameObject Form;

    private string Email;

    private string BASE_URL = "https://docs.google.com/forms/u/1/d/e/1FAIpQLSeAyWIT7F3tDcKl0aPmAx84WkE7l2kQh9lmInAtl9mMFEdDXA/formResponse";

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
