using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private GameController _gameController;
    private UIManager _uiManager;
    private Bar _hpBar;
    private CharacterAnim _characterAnim;
    private CameraEnd _cameraEnd;

    public bool isButtonSelected = false;

    public int cameraTargetIndex;

    private const float _START_STORY_DELAY = 1.0f;

    public float maxScore = 100;
    private float _score;

    private Dictionary<Speaker, CharacterAnim> _characterDic = new Dictionary<Speaker, CharacterAnim>();

    public float Score
    {
        get { return _score; }
        set
        {
            if (_score + value >= 100)
            {
                _score = 100;
            }
            else if (_score + value <= 0)
            {
                _score = 0;
            }
            else
            {
                _score += value;
            }
        }
    }

    public void Reset()
    {
        _score = 0;
        Debug.Log(_characterDic.Count); 
        SceneManager.LoadScene("MenuScene");
    }

    public void AddCharacter(Speaker speaker, CharacterAnim characterAnim)
    {
        if (!_characterDic.ContainsKey(speaker))
        {
            Debug.Log(213213);
            _characterDic.Add(speaker, characterAnim);
        }
    }
    public void ClearCharacter()
    {
        _characterDic.Clear();
    }

    public void SetScript(GameController gameController)
    {
        _gameController = gameController;
    }
    public void SetScript(UIManager uiManager)
    {
        _uiManager = uiManager;
    }
    public void SetScript(Bar bar)
    {
        _hpBar = bar;
    }

    public void StartGame()
    {
        StartCoroutine(StartScene());
    }

    IEnumerator StartScene()
    {
        yield return new WaitUntil(() => _uiManager && _gameController);
        _uiManager.OnDialoguePanel();

        StartCoroutine(StartStory());
    }

    IEnumerator StartStory()
    {
        yield return new WaitForSeconds(_START_STORY_DELAY);
        _gameController.StartScene();
    }

    public void PlayScene(StoryScene storyScene)
    {
        _gameController.PlayScene(storyScene);
    }

    public void PlayCharacterAnimation(Speaker speaker, CharacterAnim.State state)
    {
        _characterDic[speaker].PlayAnim(state);
    }

    public void SetHp(float value)
    { 
        _hpBar.Calculate(value);
    }

    public void OnSelectionPanel()
    {
        if (_uiManager.isOnInformation)
        {
            _uiManager.ChangeInformationPosition();
        }
        
        _uiManager.OnSelectionPanel();
    }

    public void OnInformationImage(Sprite sprite)
    {
        _uiManager.OnInformationImage(sprite);
    }
    
    public void OffInformation()
    {
        _uiManager.OffInformationImage();
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
