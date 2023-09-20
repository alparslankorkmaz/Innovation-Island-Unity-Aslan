using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AuditoriumEntries : MonoBehaviour
{
    [SerializeField]
    public GameObject firstname;
    public GameObject lastname;
    public GameObject email;
    public GameObject phone;
    public GameObject jobtitle;
    public GameObject companyName;
    public GameObject Form;

    private string FirstName;
    private string LastName;
    private string Email;
    private string Phone;
    private string JobTitle;
    private string CompanyName;

    private string BASE_URL = "https://docs.google.com/forms/u/1/d/e/1FAIpQLSfkPlMDY3blNPKGUFXIP0twiCdyU41MHsfJVgLcuqLEAs0PKw/formResponse";

    public void Send()
    {
        FirstName = firstname.GetComponent<InputField>().text;
        LastName = lastname.GetComponent<InputField>().text;
        Email = email.GetComponent<InputField>().text;
        Phone = phone.GetComponent<InputField>().text;
        JobTitle = jobtitle.GetComponent<InputField>().text;
        CompanyName = companyName.GetComponent<InputField>().text;

        if (string.IsNullOrEmpty(FirstName))
        {
            Form.SetActive(true);
        }
        else if (string.IsNullOrEmpty(LastName))
        {
            Form.SetActive(true);
        }
        else if (string.IsNullOrEmpty(Email))
        {
            Form.SetActive(true);
        }
        else if (string.IsNullOrEmpty(JobTitle))
        {
            Form.SetActive(true);
        }
        else if (string.IsNullOrEmpty(CompanyName))
        {
            Form.SetActive(true);
        }
        else
        {
            StartCoroutine(Post(FirstName, LastName, Email, Phone, JobTitle, CompanyName));
            Destroy(Form);
        }
    }

    IEnumerator Post(string firstName, string lastName, string email, string phone, string jobTitle, string companyName)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.384421127", firstName);
        form.AddField("entry.579336435", lastName);
        form.AddField("entry.500422346", email);
        form.AddField("entry.71162977", phone);
        form.AddField("entry.813213346", jobTitle);
        form.AddField("entry.881594956", companyName);

        UnityWebRequest www = UnityWebRequest.Post(BASE_URL, form);
        yield return www.SendWebRequest();
    }

}
