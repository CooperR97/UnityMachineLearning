using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MLAgents;

public class LaneAgent : Agent
{
    private Vector2 targetPos = new Vector2(-7.5f, 0f);
    public float yInc;

    public float speed;
    public float maxHeight;
    public float minHeight;

    public int health = 3;

    public int prevHealth = 3;
    

    public Text healthDisplay;

    public Vector3 enemState;

    public override void AgentReset()
    {
        health = 3;
    }

    public override void CollectObservations()
    {
        //player position
        AddVectorObs(this.transform.position);
        //a 3 vector position based on if the enemy is at the start of the screen
        AddVectorObs(enemState);
    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {
        healthDisplay.text = health.ToString();
        float dir = vectorAction[0];
        
        /*if(dir <= -0.8f && transform.position.y < maxHeight)
        {
            targetPos = new Vector2(-7.5f, transform.position.y + yInc);
        }

        if(dir >= 0.8f && transform.position.y > minHeight)
        {
            targetPos = new Vector2(-7.5f, transform.position.y - yInc);
        }*/


        targetPos = new Vector2(-7.5f, transform.position.y);

            if ((int)dir == 2 && transform.position.y < maxHeight)
            {
                transform.position = new Vector2(-7.5f, 3f);
                //targetPos = new Vector2(-7.5f, transform.position.y + yInc);
            }

            if ((int)dir == 1 && transform.position.y > minHeight)
            {
                transform.position = new Vector2(-7.5f, -3f);
                //targetPos = new Vector2(-7.5f, transform.position.y - yInc);
            }

            if ((int)dir == 0)
            {
                transform.position = new Vector2(-7.5f, 0f);
            }
        
        Debug.Log(dir);

        //transform.position = targetPos;

        //transform.position = Vector2.MoveTowards(transform.position,targetPos, speedMult * speed * Time.deltaTime);

        if (health < prevHealth)
        {
            AddReward(-2);
            prevHealth = health;
        }
        if(health <= 0f)
        {
            AddReward(-5f);
            Done();
        }
        else
        {
            AddReward(0.02f);
        }

    }
}
