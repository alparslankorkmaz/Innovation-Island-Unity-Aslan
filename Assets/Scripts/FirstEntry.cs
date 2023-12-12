using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FirstEntry : MonoBehaviour
{
    [SerializeField]
    public GameObject firstname;
    public GameObject companyName;
    public GameObject Form;

    private string FirstName;
    private string CompanyName;

    private string BASE_URL = "https://docs.google.com/forms/u/1/d/e/1FAIpQLSfNMwwlJOujacQ4I-huUCwoOjUIPEcwwqi-2pn6JXENh7GaUg/formResponse";

    public void Send()
    {
        FirstName = firstname.GetComponent<InputField>().text;
        CompanyName = companyName.GetComponent<InputField>().text;

        if (string.IsNullOrEmpty(FirstName))
        {
            Form.SetActive(true);
        }
        else if (string.IsNullOrEmpty(CompanyName))
        {
            Form.SetActive(true);
        }
        else
        {
            StartCoroutine(Post(FirstName, CompanyName));
            Destroy(Form);
        }
    }

    IEnumerator Post(string firstName, string companyName)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.1743637214", firstName);
        form.AddField("entry.1808386273", companyName);

        UnityWebRequest www = UnityWebRequest.Post(BASE_URL, form);
        yield return www.SendWebRequest();
    }

}
