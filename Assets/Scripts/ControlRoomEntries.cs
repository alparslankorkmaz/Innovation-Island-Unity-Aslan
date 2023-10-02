using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ControlRoomEntries : MonoBehaviour
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

    private string BASE_URL = "https://docs.google.com/forms/u/4/d/e/1FAIpQLSdHEphnAzLrrHBfrndpKKl6-UlEXeTqdv6ULILGBjSU61td6g/formResponse";

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
        form.AddField("entry.970297979", firstName);
        form.AddField("entry.1514677201", lastName);
        form.AddField("entry.1424899601", email);
        form.AddField("entry.1665152882", phone);
        form.AddField("entry.1888072721", jobTitle);
        form.AddField("entry.1253999080", companyName);

        UnityWebRequest www = UnityWebRequest.Post(BASE_URL, form);
        yield return www.SendWebRequest();
    }

}
