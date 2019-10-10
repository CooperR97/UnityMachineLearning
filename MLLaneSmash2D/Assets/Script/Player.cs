using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Vector2 targetPos = new Vector2(-7.5f, 0f);
    public float yInc;

    public float speed;
    public float maxHeight;
    public float minHeight;

    public int health = 3;

    public Text healthDisplay;

    // Update is called once per frame
    void Update()
    {
        healthDisplay.text = health.ToString();

        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
        {
            targetPos = new Vector2(-7.5f, transform.position.y + yInc);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
        {
            targetPos = new Vector2(-7.5f, transform.position.y - yInc);
        }
    }
}
