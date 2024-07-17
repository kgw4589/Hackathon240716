using System;
using UnityEngine;
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

    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.enabled = true;
        
        GameManager.Instance.AddCharacter(mySpeaker, this);
    }

    // private static readonly int SelectMotion = Animator.StringToHash("SelectMotion");

    public void PlayAnim(State state)
    {
        switch (state)
        {
            case State.Idle:
                Debug.Log("1");
                anim.SetTrigger("SetStand");
                // _anim.SetInteger(SelectMotion, 0);
                break;
            case State.BadSelect:
                Debug.Log("2");
                anim.SetTrigger("SetBadSelect");
                // _anim.SetInteger(SelectMotion, 1);
                break;
            case State.Talk:
                Debug.Log("3");
                anim.SetTrigger("SetTalk");
                // _anim.SetInteger(SelectMotion, 2);
                break;
        }
    }

    public void StartIdle()
    {
        PlayAnim(State.Idle);
    }
}
