using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    public void OpenScene()
    {
        SceneManager.LoadScene("Space");
    }
    public void OnPointerEnter()
    {
        gameObject.GetComponentInChildren<TextMeshProUGUI>().fontStyle = FontStyles.Underline;
    }
    
    public void OnPointerExit()
    {
        gameObject.GetComponentInChildren<TextMeshProUGUI>().fontStyle = FontStyles.Normal;
    }

}
