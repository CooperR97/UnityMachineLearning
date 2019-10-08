using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class SquareCharAgent : Agent
{

    Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public Transform Target;

    public override void AgentReset()
    {
        if(this.transform.position.y < 0)
        {
            //if the agent falls off the platform, 0 the position
            this.rb2d.angularVelocity = 0f;
            this.rb2d.velocity = Vector2.zero;
            this.transform.position = new Vector3(0, 2f, 0);
        }

        // Move the target to a new position(tutorial)
        // For our example we are keeping it real simple and not moving the target
        Target.position = new Vector3(Random.value * 8, Random.value * 8, 0);
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
        //reached the target
        if (distanceToTarget < 5f)
        {
            AddReward(0.1f);
          

        }

        //Fell off the platform
        if (this.transform.position.y < 0)
        {
            AddReward(-0.1f);
            Done();
            
        }
        //Fell off the platform
        if (this.transform.position.y > 8f)
        {
            Done();
            
        }
        //Fell off the platform
        if (this.transform.position.x > 30f)
        {
            Done();
            
        }
        //Fell off the platform
        if (this.transform.position.x < -30f)
        {
            Done();
            
        }

    }

}
