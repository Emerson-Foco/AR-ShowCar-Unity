using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterInteraction : MonoBehaviour
{
    public int idContent = 0;
    
    private bool _mouseEnter = false;
    private ShowManager _showManager;

    public void Awake()
    {
        _showManager = GameObject.Find("Manager").GetComponent<ShowManager>();
    }

    public void Update()
    {
        if (_mouseEnter && Input.GetKeyUp(KeyCode.Mouse0))
        {
            ShowAction();
            _mouseEnter = false;
        }
    }

    public void ShowAction()
    {
        _showManager.ActiveContent(idContent);
    }
    
    public void OnMouseEnter()
    {
        _mouseEnter = true;
    }

    public void OnMouseExit()
    {
        _mouseEnter = false;
    }
}
