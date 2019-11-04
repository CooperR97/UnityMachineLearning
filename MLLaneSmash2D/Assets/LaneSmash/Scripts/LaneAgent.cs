using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class LaneAgent : Agent
{

    public Rigidbody rb;
    public Transform Target;
    RayPerception m_RayPer;

    public bool enemyHit = false;
    public bool complete = false;
    public bool s_Reward1Achieved;
    public bool s_Reward2Achieved;
    public bool s_Reward3Achieved;
    public bool s_Reward4Achieved;

    public float forwardForce = 8000f;
    public float sidewaysForce = 120f;
    float[] m_RayAngles = {90f, 100f, 80f};
    string[] m_DetectableObjects = { "Obstacle" };

    public float distance;

    List<float> list;

    private void Start()
    {
        m_RayPer = GetComponent<RayPerception>();
    }

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

        s_Reward1Achieved = false;
        s_Reward2Achieved = false;
        s_Reward3Achieved = false;
        s_Reward4Achieved = false;

    }

    public override void CollectObservations()
    {
        //Observations for player position Vector3 - 3
        //Velocity.z - 1
        var rayDistance = 12f;

        AddVectorObs(this.transform.position);
        AddVectorObs(m_RayPer.Perceive(rayDistance, m_RayAngles, m_DetectableObjects, 0f, 0f));
        //AddVectorObs(m_RayPer.Perceive(rayDistance, m_RayAngles, m_DetectableObjects, 1.5f, 0f));

        //AddVectorObs(distance);
    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {

        //var rayDistance = 10f;

        //list = m_RayPer.Perceive(rayDistance, m_RayAngles, m_DetectableObjects, 0f, 0f);

        

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
        || this.transform.position.x > 8.5f
        || this.transform.position.x < -8.5f)
        {
            AddReward(-2f);
            Done();
        }
        else
        {
            AddReward(0.1f);
        }

        if (enemyHit)
        {

            AddReward(-1f);
            enemyHit = false;
            Done();
        }

        if (complete)
        {
            AddReward(10f);
            complete = false;
            Done();
        }

        if(distance < 200f && s_Reward1Achieved == false)
        {
            AddReward(5f);
            s_Reward1Achieved = true;
        }

        if (distance < 150f && s_Reward2Achieved == false)
        {
            AddReward(5f);
            s_Reward2Achieved = true;
        }

        if (distance < 100f && s_Reward2Achieved == false)
        {
            AddReward(5f);
            s_Reward3Achieved = true;
        }

        if (distance < 50f && s_Reward2Achieved == false)
        {
            AddReward(5f);
            s_Reward4Achieved = true;
        }

    }

}

