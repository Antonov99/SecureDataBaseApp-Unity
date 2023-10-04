using Firebase.Database;
using Firebase;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DataBase : MonoBehaviour
{
    public GameObject regError;
    public GameObject enterError;

    public GameObject enterPanel;
    public GameObject regPanel;
    public GameObject closeButton;

    public GameObject ChoosePanel;

    public Text dataT;

    private string userID;
    private DatabaseReference dbRef;

    private AES aes;

    void Start()
    {
        userID = SystemInfo.deviceUniqueIdentifier;
        dbRef = FirebaseDatabase.DefaultInstance.RootReference;

        aes = GetComponent<AES>();
    }

    public void SaveData(string log, string pas)
    {
        if (log != "" && pas != "")
        {
            dbRef.Child("users").Child(userID).Child("login").SetValueAsync(log);
            dbRef.Child("users").Child(userID).Child("password").SetValueAsync(pas);
            regPanel.SetActive(false);
            closeButton.SetActive(true);
            ChoosePanel.SetActive(true);
        }
        else
        {
            regError.SetActive(true);
        }
    }

    public IEnumerator Authorization(string Elog, string Epass)
    {
        if (Elog != "" && Epass != "")
        {
            var enter = dbRef.Child("users").Child(userID).GetValueAsync();
            yield return new WaitUntil(predicate: () => enter.IsCompleted);

            if (enter.Exception != null)
            {
                enterError.SetActive(true);
            }
            else
            {
                DataSnapshot snapE = enter.Result;
                string login = snapE.Child("login").Value.ToString();
                string password = snapE.Child("password").Value.ToString();
                if (Elog == login && Epass == password)
                {
                    closeButton.SetActive(true);
                    enterPanel.SetActive(false);
                    ChoosePanel.SetActive(true);
                }
                else
                {
                    enterError.SetActive(true);
                }
            }
        }
        else
        {
            enterError.SetActive(true);
        }

    }

    public void SaveEncData(string key, string data)
    {
        if (key != "" && data != "")
        {
            dbRef.Child("users").Child(userID).Child("Data").Child(key).SetValueAsync(data);
        }
        else
        {
            Debug.Log("пусто");
        }
    }

    public IEnumerator ShowDecData(string key)
    {
        if (key != "")
        {
            var d = dbRef.Child("users").Child(userID).Child("Data").Child(key).GetValueAsync();
            yield return new WaitUntil(predicate: () => d.IsCompleted);

            if (d.Exception != null)
            {
                dataT.text = "ошибка";
            }
            else
            {
                DataSnapshot snapD = d.Result;
                string dat = snapD.Value.ToString();
                dataT.text = aes.RasShifr(dat);

            }
        }
        else
        {
            dataT.text = "ошибка";
        }
    }
}
