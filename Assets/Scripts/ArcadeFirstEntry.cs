using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ArcadeFirstEntry : MonoBehaviour
{
    [SerializeField]
    public GameObject email;
    public GameObject Form;

    private string Email;

    private string BASE_URL = "https://docs.google.com/forms/u/1/d/e/1FAIpQLScQ9-kAY-mHwgYX4a2H__CrJLCF3gwhUjC7QhSjcDkA1aoHhg/formResponse";

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
