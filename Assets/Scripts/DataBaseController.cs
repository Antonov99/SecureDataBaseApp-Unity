using UnityEngine.UI;
using UnityEngine;

public class DataBaseController : MonoBehaviour
{
    AudioSource aud;
    public AudioClip knopka;

    public InputField regLog;
    public InputField regPass;

    public InputField enterLog;
    public InputField enterPass;

    public InputField dataEnc;
    public InputField keyEnc;

    public InputField keyDec;

    private DataBase db;
    private AES aes;

    void Start()
    {
        aud = GetComponent<AudioSource>();
        db = GetComponent<DataBase>();
        aes = GetComponent<AES>();
    }

    public void BReg()
    {
        db.SaveData(regLog.text, regPass.text);
        aud.PlayOneShot(knopka);
    }
    public void BEnter()
    {
        StartCoroutine(db.Authorization(enterLog.text, enterPass.text));
        aud.PlayOneShot(knopka);
    }

    public void BSaveEncData()
    {
        string a = aes.Shifr(dataEnc.text);
        Debug.Log(a.Length);
        db.SaveEncData(keyEnc.text, a);
    }

    public void BShowDecData()
    {
        StartCoroutine(db.ShowDecData(keyDec.text));
    }
}
