﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    private Vector3 mousePosition;

	// Use this for initialization
	void Start()
    {
        mousePosition = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update()
    {
        SetPosition();
	}

    private void SetPosition()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 newPosition = new Vector3(mousePosition.x, mousePosition.y, 0);

        transform.position = newPosition;

        Debug.Log("Jerry's Position: " + transform.position.ToString());
    }
}
