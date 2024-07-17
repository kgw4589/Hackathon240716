using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStoryScene", menuName = "Story/New Story Scene")]
[System.Serializable]
public class StoryScene : ScriptableObject
{
    public List<Sentence> sentences;
    public AudioClip backgroundMusic;
    public StoryScene nextScene;
    
    [System.Serializable]
    public struct Sentence
    {
        public AudioClip audioClip;
        
        public string text;
        public Speaker speaker;

        public float nextSentenceDelay;
        
        public StoryScene[] selectionStoryScene;
        public int trueSelectionIndex;

        public Sprite informationImage;
        public bool offInformation;
    }
}