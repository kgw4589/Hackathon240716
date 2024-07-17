using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Animator dialogueAnimator;
    [SerializeField] private Animator informationAnimator;
    
    public GameObject selectionPanel;
    public Image informationImage;

    private StoryScene[] _storyScenes = new StoryScene[3];
    private StoryScene _nextScene;

    private int _trueSelectionIndex;

    public bool isSelected = false;

    private void Awake()
    {
        GameManager.Instance.SetScript(this);
    }

    public void PlayScene()
    {
        isSelected = true;
        selectionPanel.SetActive(false);
        GameManager.Instance.PlayScene(_nextScene);
    }

    public void SetStoryScenes(StoryScene[] storyScenes, int trueSelectionIndex)
    {
        _trueSelectionIndex = trueSelectionIndex;
        
        for (int i = 0; i < 3; i++)
        {
            _storyScenes[i] = storyScenes[i];
        }
    }

    public void OnDialoguePanel()
    {
        dialogueAnimator.SetTrigger("OnDialogue");
    }
    
    public void OnInformationImage(Sprite sprite)
    {
        informationImage.sprite = sprite;
        informationAnimator.SetTrigger("OnInformation");
    }
    
    public void OffInformationImage()
    {
        informationAnimator.SetTrigger("OffInformation");
    }

    public void OnClickSelectionOne()
    {
        _nextScene = _storyScenes[0];
        
        if (_trueSelectionIndex == 0)
        {
            
        }
        else
        {
            
        }
        
        PlayScene();
    }
    
    public void OnClickSelectionTwo()
    {
        _nextScene = _storyScenes[1];
        
        if (_trueSelectionIndex == 1)
        {
            
        }
        else
        {
            
        }
        
        PlayScene();
    }
    
    public void OnClickSelectionThree()
    {
        _nextScene = _storyScenes[2];
        
        if (_trueSelectionIndex == 2)
        {
            
        }
        else
        {
            
        }
        
        PlayScene();
    }
}
