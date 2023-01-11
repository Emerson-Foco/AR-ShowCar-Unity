using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingIcon : MonoBehaviour
{
    private GameObject _camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_camera.transform);
    }
    private void OnEnable()
    {
        _camera = GameObject.FindWithTag("MainCamera");
    }
}
