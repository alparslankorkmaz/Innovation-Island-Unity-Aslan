using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SendToGoogle : MonoBehaviour
{
    public GameObject participantName;
    public GameObject email;
    public GameObject phone;
    public GameObject Form;

    private string Name;
    private string Email;
    private string Phone;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSfpdp47dTpu_Z0r3szSmZvNJPXYi_8ccKur9ASrXjidSiMPew/formResponse";

    public void Send()
    {
        Name = participantName.GetComponent<InputField>().text;
        Email = email.GetComponent<InputField>().text;
        Phone = phone.GetComponent<InputField>().text;

        StartCoroutine(Post(Name, Email, Phone));
        Form.SetActive(false);
    }

    IEnumerator Post(string name, string email, string phone)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.1765455829", name);
        form.AddField("entry.1880065985", email);
        form.AddField("entry.382419404", phone);

        UnityWebRequest www = UnityWebRequest.Post(BASE_URL, form);
        yield return www.SendWebRequest();
    }

}
