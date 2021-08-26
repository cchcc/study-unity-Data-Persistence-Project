using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScreen : MonoBehaviour
{
    public TMP_InputField inputName;

    private void Start()
    {
        inputName.text = GameManager.instance.data.playerName;
    }

    public void ClickedStart()
    {
        GameManager.instance.data.playerName = inputName.text;
        GameManager.instance.SaveData();
        SceneManager.LoadScene(1);
    }

    public void ClickedClearData()
    {
        GameManager.instance.ClearData();
        inputName.text = "";
    }
}
