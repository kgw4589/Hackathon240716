using System.Collections;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private GameController _gameController;
    private UIManager _uiManager;
    private Bar _hpBar;
    private CharacterAnim _characterAnim;

    public bool isButtonSelected = false;

    public int cameraTargetIndex;

    private const float _START_STORY_DELAY = 1.0f;
    
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
    public void SetScript(Bar bar)
    {
        _hpBar = bar;
    }
    public void SetScript(CharacterAnim characterAnim)
    {
        _characterAnim = characterAnim;
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

    public void PlayCharacterAnimation(CharacterAnim.State state)
    {
        _characterAnim.PlayAnim(state);
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
