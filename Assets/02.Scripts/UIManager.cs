using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Animator dialogueAnimator;
    [SerializeField] private Animator informationAnimator;
    [SerializeField] private Animator selectionAnimator;
    
    [SerializeField] private GameObject selectionPanel;
    
    public Image informationImage;
    public bool isOnInformation = false;
    private RectTransform _informationTransform;
    private Vector3 _originInformationPosition;

    public TextMeshProUGUI[] buttonText = new TextMeshProUGUI[3];
    
    private StoryScene[] _storyScenes = new StoryScene[3];

    private const float _PLAY_SCENE_DELAY = 0.5f;

    private int _trueSelectionIndex;

    public bool isSelected = false;

    private void Awake()
    {
        GameManager.Instance.SetScript(this);
        _informationTransform = informationImage.GetComponent<RectTransform>();
        _originInformationPosition = _informationTransform.position;
    }

    private void PlayScene(StoryScene storyScene)
    {
        isSelected = true;
        selectionAnimator.SetTrigger("OffSelection");
        StartCoroutine(PlayDelay(storyScene));
    }

    IEnumerator PlayDelay(StoryScene storyScene)
    {
        yield return new WaitForSeconds(_PLAY_SCENE_DELAY);
        GameManager.Instance.PlayScene(storyScene);
        GameManager.Instance.SetHp(storyScene.selectedValue);
    }

    public void OnSelectionPanel()
    {
        selectionAnimator.SetTrigger("OnSelection");
    }

    public void SetStoryScenes(StoryScene[] storyScenes, int trueSelectionIndex)
    {
        _trueSelectionIndex = trueSelectionIndex;
        
        for (int i = 0; i < 3; i++)
        {
            buttonText[i].text = storyScenes[i].selectText;
            _storyScenes[i] = storyScenes[i];
        }
    }

    public void OnDialoguePanel()
    {
        dialogueAnimator.SetTrigger("OnDialogue");
    }

    public void ChangeInformationPosition()
    {
        informationAnimator.SetTrigger("OnMove");
    }
    
    public void OnInformationImage(Sprite sprite)
    {
        isOnInformation = true;
        informationImage.sprite = sprite;
        informationAnimator.SetTrigger("OnInformation");
    }
    
    public void OffInformationImage()
    {
        isOnInformation = false;
        _informationTransform.position = _originInformationPosition;
        informationAnimator.SetTrigger("OffInformation");
    }

    public void OnClickSelectionButton(int index)
    {
        PlayScene(_storyScenes[index]);
    }
}
