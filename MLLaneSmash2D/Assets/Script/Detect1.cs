using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect1 : MonoBehaviour
{
    public int isEnem;

    public LaneAgent Lane;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            isEnem = 1;
            Lane.enemState.x = isEnem;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            isEnem = 0;
            Lane.enemState.x = isEnem;
        }
    }
}
