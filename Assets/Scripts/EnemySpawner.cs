﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float timeBetweenSpawns;
    private int count;
    public int armySize;

    private Vector3 initialPoint;
    public float xRange;
    public float xSpeed;
    private bool moveUp;
    public float yRange;
    public float ySpeed;
    private bool moveRight;

    public Color[] colors;

    void Start()
    {
        count = 0;

        initialPoint = transform.position;
        moveUp = true;
        moveRight = true;

        StartCoroutine("Spawn");
	}
	
	void Update()
    {
        // Move spawner
        TranslateX();
        TranslateY();
	}

    private void TranslateX()
    {
        // Right
        if(moveRight)
        {
            transform.Translate(Vector3.right * xSpeed);

            if(transform.position.x >= initialPoint.x + xRange)
            {
                moveRight = false;
            }
        }
        // Left
        else
        {
            transform.Translate(-Vector3.right * xSpeed);

            if(transform.position.x <= initialPoint.x - xRange)
            {
                moveRight = true;
            }
        }
    }

    private void TranslateY()
    {
        // Up
        if(moveUp)
        {
            transform.Translate(Vector3.up * ySpeed);

            if(transform.position.y >= initialPoint.y + yRange)
            {
                moveUp = false;
            }
        }
        // Down
        else
        {
            transform.Translate(-Vector3.up * ySpeed);

            if(transform.position.y <= initialPoint.y - yRange)
            {
                moveUp = true;
            }
        }
    }

    IEnumerator Spawn()
    {
        int colorSelect = 0;

        while(count < armySize)
        {
            GameObject newEnemy = (GameObject) Instantiate(enemy, transform.position, transform.rotation);
            newEnemy.GetComponent<SpriteRenderer>().color = colors[colorSelect];

            count++;
            colorSelect = (colorSelect + 1) % colors.Length;

            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }
}
