using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneUI : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void OnEndPanel()
    {
        animator.SetTrigger("OnEndPanel");
    }
}
