﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect3 : MonoBehaviour
{
    public int isEnem;

    public Lane2DAgent Lane;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            isEnem = 1;
            Lane.enemPos.z = isEnem;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            isEnem = 0;
            Lane.enemPos.z = isEnem;
        }
    }
}