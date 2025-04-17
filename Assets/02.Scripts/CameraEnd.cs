using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraEnd : MonoBehaviour
{
    public CinemachineDollyCart dollyCart;
    public EndSceneUI endSceneUI;

    void Update()
    {
        if (dollyCart.m_Position >= 121)
        {
            endSceneUI.OnEndPanel();
        }
    }
}
