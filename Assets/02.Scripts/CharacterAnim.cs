using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class CharacterAnim : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Speaker mySpeaker;

    public enum State
    {
        Idle,
        Talk,
        BadSelect
    }
    
    private void OnEnable()
    {
        GameManager.Instance.AddCharacter(mySpeaker, this);
    }

    public void PlayAnim(State state)
    {
        switch (state)
        {
            case State.Idle:
                anim.SetTrigger("SetStand");
                break;
            case State.BadSelect:
                anim.SetTrigger("SetBadSelect");
                break;
            case State.Talk:
                anim.SetTrigger("SetTalk");
                break;
        }
    }

    public void StartIdle()
    {
        PlayAnim(State.Idle);
    }

    private void OnDisable()
    {
        GameManager.Instance.ClearCharacter();
    }
}
