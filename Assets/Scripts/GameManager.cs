using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private GameController _gameController;
    private UIManager _uiManager;

    public bool isButtonSelected = false;

    public int cameraTargetIndex;
    
    protected override void Init()
    {
        
    }

    public void SetScript(GameController gameController)
    {
        _gameController = gameController;
    }
    
    public void SetScript(UIManager uiManager)
    {
        _uiManager = uiManager;
    }

    public void StartGame()
    {
        StartCoroutine(StartScene());
    }

    IEnumerator StartScene()
    {
        yield return new WaitUntil(() => _gameController);
        _gameController.StartScene();
    }

    public void PlayScene(StoryScene storyScene)
    {
        _gameController.PlayScene(storyScene);
    }

    public void OnSelectionPanel()
    {
        _uiManager.selectionPanel.SetActive(true);
    }

    public void SetStoryScenes(StoryScene[] storyScenes, int trueSelectionIndex)
    {
        _uiManager.SetStoryScenes(storyScenes, trueSelectionIndex);
    }

    public void ChangeCameraTarget(int index)
    {
        cameraTargetIndex = index;
    }
}
