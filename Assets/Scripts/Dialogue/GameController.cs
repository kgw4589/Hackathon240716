using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogueManager;
    
    public StoryScene currentScene;

    public bool isAllFinished = false;
    public bool isOnButton = false;
    
    private void Start()
    {
        PlayScene(currentScene);
    }

    public void PlayScene(StoryScene storyScene)
    {
        dialogueManager.PlayStory(storyScene);
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
        if (!dialogueManager.IsCompleted())
        {
            return;
        }
        if (dialogueManager.IsLastSentence())
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
                
        dialogueManager.PlayNextSentence();
    }
    
    void NextScene()
    {
        currentScene = currentScene.nextScene;
        dialogueManager.PlayStory(currentScene);
    }
    
    void EndCurrentStoryScene()
    {
        isAllFinished = true;
        Debug.Log("끝!");
    }
}
