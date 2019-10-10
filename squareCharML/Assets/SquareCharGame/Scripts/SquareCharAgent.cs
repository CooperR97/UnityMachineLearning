using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class SquareCharAgent : Agent
{
    //Rigidbody component for character
    Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    //Target Component that SquareChar is being trained to reach
    public Transform Target;

    public override void AgentReset()
    {
        //If the character is out of the bounding box then reset
        if(this.transform.position.y < 0
            || this.transform.position.y > 8f
            || this.transform.position.x > 30f
            || this.transform.position.x < -30f)
        {
            this.rb2d.angularVelocity = 0f;
            this.rb2d.velocity = Vector2.zero;
            this.transform.position = new Vector3(0, 2f, 0);
        }

        //Move the target to new position
        Target.position = new Vector3(Random.value * 8, Random.value * 6+1, 0);
    }

    public override void CollectObservations()
    {
        // target and agent positions
        AddVectorObs(Target.position);
        AddVectorObs(this.transform.position);

        // Agent velocity
        AddVectorObs(rb2d.velocity.x);
        AddVectorObs(rb2d.velocity.y);  
    }
    //Speed the agent is being moved
    public float speed = 30f;

    public override void AgentAction(float[] vectorAction, string textAction)
    {
        //Actions, size = 2
        Vector2 controlSignal = Vector2.zero;
        controlSignal.x = vectorAction[0];
        controlSignal.y = vectorAction[1];
        rb2d.AddForce(controlSignal * speed);

        //Rewards
        float distanceToTarget = Vector2.Distance(this.transform.position, Target.position);

        //reached the target
        if (distanceToTarget < 1.5f)
        {
            AddReward(1.0f);
            Done();   
        }

        //The agent has gone out of bounds
        if (this.transform.position.y < 0
            || this.transform.position.y > 8f
            || this.transform.position.x > 30f
            || this.transform.position.x < -30f)
        {
            AddReward(-0.1f);
            Done(); 
        }

        // Penalty given each step to encourage agent to finish task quickly.
        AddReward(-0.001f);
    }
}
