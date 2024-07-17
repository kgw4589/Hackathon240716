using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneUI : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private TextMeshProUGUI scoreText;

    private bool _isPanelOn = false;

    public void OnEndPanel()
    {
        if (_isPanelOn)
        {
            return;
        }
        
        animator.SetTrigger("OnEndPanel");
        _isPanelOn = true;
        scoreText.text = GameManager.Instance.Score.ToString() + "%";
    }

    public void GoMenuScene()
    {
        _isPanelOn = false;
        GameManager.Instance.Reset();
    } 
}
