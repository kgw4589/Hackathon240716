using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public CinemachineVirtualCamera[] virCamList;
    
    private int _listSize;
    private int _nowVirCam;

    private void Start()
    {
        _listSize = virCamList.Length;
    }

    private void Update()
    {
        if (GameManager.Instance.cameraTargetIndex != _nowVirCam || Input.anyKeyDown)
        {
            if (_nowVirCam < _listSize)
            {
                virCamList[_nowVirCam].Priority -= 100;

                _nowVirCam = GameManager.Instance.cameraTargetIndex;
                virCamList[_nowVirCam].Priority += 100;
            }
        }
    }
}
