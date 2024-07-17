using System;
using UnityEngine;

public class CharacterAnim : MonoBehaviour
{
    private Animator _anim;


    public enum State
    {
        Idle,
        Talk,
        BadSelect
    }

    public State motion;

    private static readonly int SelectMotion = Animator.StringToHash("SelectMotion");
    
    void Awake()
    {
        GameManager.Instance.SetScript(this);
        _anim = GetComponent<Animator>();
    }

    public void PlayAnim(State state)
    {
        switch (state)
        {
            case State.Idle:
                _anim.SetInteger(SelectMotion, 0);
                break;
            case State.BadSelect:
                _anim.SetInteger(SelectMotion, 1);
                break;
            case State.Talk:
                _anim.SetInteger(SelectMotion, 2);
                break;
        }
    }

    public void StartIdle()
    {
        PlayAnim(State.Idle);
    }
}
