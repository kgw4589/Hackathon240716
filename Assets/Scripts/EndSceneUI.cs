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

    private void Start()
    {
        // OnEndPanel();
    }

    public void OnEndPanel()
    {
        animator.SetTrigger("OnEndPanel");

        scoreText.text = GameManager.Instance.Score.ToString() + "%";
    }

    public void GoMenuScene()
    {
        GameManager.Instance.Reset();
    } 
}
