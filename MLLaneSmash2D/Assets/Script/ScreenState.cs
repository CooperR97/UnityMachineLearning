using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenState : MonoBehaviour
{

    Stack posStack = new Stack();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        posStack.Push(new Vector3(collision.transform.position.x, collision.transform.position.y, collision.transform.position.z));
        Debug.Log(posStack.Count);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        posStack.Pop();
    }
}
