using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    AudioSource aud;
    public AudioClip knopka;
    public GameObject enterPanel;
    public GameObject regPanel;
    public GameObject closeButton;
    public GameObject openButton;
    public GameObject regButton;
    public GameObject panelSC;
    public GameObject panelSD;

    public GameObject CipherPanel;
    public GameObject DecPanel;
    public GameObject ChoosePanel;

    public GameObject enterButton;

    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    public void Open()
    {
        aud.PlayOneShot(knopka);
        enterPanel.SetActive(true);
        openButton.SetActive(false);
        regButton.SetActive(false);
        closeButton.SetActive(false);
    }

    public void OpenReg()
    {
        aud.PlayOneShot(knopka);
        regPanel.SetActive(true);
        openButton.SetActive(false);
        regButton.SetActive(false);
        closeButton.SetActive(false);
    }

    public void Close()
    {
        aud.PlayOneShot(knopka);
        enterPanel.SetActive(false);
        openButton.SetActive(true);
        regPanel.SetActive(false);
        regButton.SetActive(true);
        closeButton.SetActive(true);
    }

    public void Quit()
    {
        aud.PlayOneShot(knopka);
        Application.Quit();
    }

    public void OpenEnc()
    {
        CipherPanel.SetActive(true);
        ChoosePanel.SetActive(false);
    }

    public void OpenDec()
    {
        DecPanel.SetActive(true);
        ChoosePanel.SetActive(false);
    }

    public void CloseEnc()
    {
        CipherPanel.SetActive(false);
        ChoosePanel.SetActive(true);
    }

    public void CloseDec()
    {
        DecPanel.SetActive(false);
        ChoosePanel.SetActive(true);
    }

    public void CloseSC()
    {
        panelSC.SetActive(false);
    }

    public void CloseSD()
    {
        panelSD.SetActive(false);
    }

    public void OpenSC()
    {
        panelSC.SetActive(true);
    }

    public void OpenSD()
    {
        panelSD.SetActive(true);
    }
}