using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class LaneAgent : Agent
{

    public Rigidbody rb;
    public Transform Target;

    public bool enemyHit = false;
    public bool complete = false;

    public float forwardForce = 8000f;
    public float sidewaysForce = 120f;

    public float distance;

    private void FixedUpdate()
    {
        distance = Vector3.Distance(this.transform.position, Target.position);
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
    }
    public override void AgentReset()
    {
        //Reset position to 0,1,0
        //Set velocity to 0

            this.rb.angularVelocity = Vector3.zero;
            this.rb.velocity = Vector3.zero;
            this.transform.position = new Vector3(0, 1f, 0);
            this.transform.rotation = Quaternion.identity;

    }

    public override void CollectObservations()
    {
        //Observations for player position Vector3 - 3
        //Velocity.z - 1
        AddVectorObs(this.transform.position);
        AddVectorObs(this.rb.velocity.z);
        AddVectorObs(distance);
    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {

        float dir = vectorAction[0];

        var direction = 0;
        //Discrete 3 actions, move left right or dont move
        //Done() on out of bounds left or right up or down (find the bounds in scene view)
        switch (dir)
        {
            case 1:
                direction = -1;
                break;
            case 2:
                direction = 1;
                break;
        }

        rb.AddForce(direction * sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        if (this.transform.position.y < 0
        || this.transform.position.x > 10f
        || this.transform.position.x < -10f)
        {
            AddReward(-1f);
            Done();
        }
        else
        {
            AddReward(0.01f);
        }

        if (enemyHit)
        {
            AddReward(-2f);
            Done();
        }

        if (complete)
        {
            AddReward(10f);
            Done();
        }

        }

}

