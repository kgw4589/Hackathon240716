using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    private DialogueManager _dialogueManager;
    
    public StoryScene currentScene;

    public bool isAllFinished = false;
    public bool isOnButton = false;

    private void Awake()
    {
        GameManager.Instance.SetScript(this);
        _dialogueManager = FindObjectOfType<DialogueManager>();
    }

    public void StartScene()
    {
        _dialogueManager.PlayStory(currentScene);
    }

    public void PlayScene(StoryScene storyScene)
    {
        _dialogueManager.PlayStory(storyScene);
    }

    private void Update()
    {
        if (!isAllFinished && !isOnButton && Input.anyKey)
        {
            NextSentence();
        }
    }

    private void NextSentence()
    {
        if (!_dialogueManager.IsCompleted())
        {
            return;
        }
        if (_dialogueManager.IsLastSentence())
        {
            if (!currentScene.nextScene)
            {
                EndCurrentStoryScene();
            }
            else
            {
                NextScene();
            }
            
            return;
        }
                
        _dialogueManager.PlayNextSentence();
    }
    
    void NextScene()
    {
        currentScene = currentScene.nextScene;
        _dialogueManager.PlayStory(currentScene);
    }
    
    void EndCurrentStoryScene()
    {
        isAllFinished = true;
        Debug.Log("끝!");
    }
}
