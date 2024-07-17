using System;
using UnityEngine;

public class CharacterAnim : MonoBehaviour
{
    public Animator _anim;
    
    public enum State
    {
        Idle,
        Talk,
        BadSelect
    }
    
    private static readonly int SelectMotion = Animator.StringToHash("SelectMotion");

    public void PlayAnim(State state)
    {
        switch (state)
        {
            case State.Idle:
                Debug.Log("1");
                _anim.SetInteger(SelectMotion, 0);
                break;
            case State.BadSelect:
                Debug.Log("2");
                _anim.SetInteger(SelectMotion, 1);
                break;
            case State.Talk:
                Debug.Log("3");
                _anim.SetInteger(SelectMotion, 2);
                break;
        }
    }

    public void StartIdle()
    {
        PlayAnim(State.Idle);
    }
}
