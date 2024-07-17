using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneUI : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Start()
    {
        OnEndPanel();
    }

    public void OnEndPanel()
    {
        animator.SetTrigger("OnEndPanel");
    }

    public void GoMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    } 
}
