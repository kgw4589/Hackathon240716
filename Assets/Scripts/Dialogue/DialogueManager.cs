using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI speakerNameText;
    public TextMeshProUGUI dialogueText;
    
    public float typeDelay = 0.05f;
    
    private int _sentenceIndex = -1;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource sentenceAudioSource;
    
    public StoryScene currentScene;

    private bool _isDelayFinish = false;

    private enum State
    {
        Playing, Completed
    }
    private State _state = State.Completed;

    private void Awake()
    {
        
    }
    
    public void PlayStory(StoryScene storyScene)
    {
        currentScene = storyScene;
        
        _sentenceIndex = -1;
        
        audioSource.clip = currentScene?.backgroundMusic;
        audioSource.Play();

        PlayNextSentence();
    }
    
    IEnumerator DelayNextSentence(float delay)
    {
        yield return new WaitForSeconds(delay);
        _isDelayFinish = true;
    }
    
    public bool IsCompleted()
    {
        return _isDelayFinish && _state == State.Completed;
    }
    
    public bool IsLastSentence()
    {
        return _sentenceIndex + 1 ==  currentScene.sentences.Count;
    }
    
    public void PlayNextSentence()
    {
        _isDelayFinish = false;
        
        StartCoroutine(TypeText(currentScene.sentences[++_sentenceIndex].text));
        
        StartCoroutine(DelayNextSentence(currentScene.sentences[_sentenceIndex].nextSentenceDelay));
        
        speakerNameText.text = currentScene.sentences[_sentenceIndex].speaker.speakerName;
        speakerNameText.color = currentScene.sentences[_sentenceIndex].speaker.nameColor;

        sentenceAudioSource.clip = currentScene.sentences[_sentenceIndex].audioClip;
        sentenceAudioSource.Play();
    }


    IEnumerator TypeText(string text)
    {
        dialogueText.text = "";
        text = text.Replace("`", ",");
        _state = State.Playing;
        int wordIndex = 0;

        while (_state != State.Completed)
        {
            dialogueText.text += text[wordIndex];
            yield return new WaitForSeconds(typeDelay);
        
            if (++wordIndex >= text.Length)
            {
                _state = State.Completed;
                break;
            }
        }
    }
}