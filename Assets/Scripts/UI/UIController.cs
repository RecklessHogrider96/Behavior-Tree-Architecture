using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{ }

public class UIController : MonoBehaviour
{
    public UIManager uiManager;

    private void Awake()
    {
        //uiManager = new UIManager();
    }

    private void OnEnable()
    {
        
    }

    private void Start()
    {
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        
    }

    private void UnRegisterEvents()
    {

    }

    private void OnDisable()
    {
        //UnRegisterEvents();
    }




}

