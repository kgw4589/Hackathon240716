using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Animator dialogueAnimator;
    [SerializeField] private Animator informationAnimator;
    
    public GameObject selectionPanel;
    public Image informationImage;
    
    public TextMeshProUGUI[] buttonText = new TextMeshProUGUI[3];
    
    private StoryScene[] _storyScenes = new StoryScene[3];

    private int _trueSelectionIndex;

    public bool isSelected = false;

    private void Awake()
    {
        GameManager.Instance.SetScript(this);
    }

    private void PlayScene(StoryScene storyScene)
    {
        isSelected = true;
        selectionPanel.SetActive(false);
        GameManager.Instance.PlayScene(storyScene);
        GameManager.Instance.SetHp(storyScene.selectedValue);
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
    
    public void OnInformationImage(Sprite sprite)
    {
        informationImage.sprite = sprite;
        informationAnimator.SetTrigger("OnInformation");
    }
    
    public void OffInformationImage()
    {
        informationAnimator.SetTrigger("OffInformation");
    }

    public void OnClickSelectionButton(int index)
    {
        PlayScene(_storyScenes[index]);
    }
}
