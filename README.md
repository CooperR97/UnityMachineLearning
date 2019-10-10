# UnityMachineLearning
## Case Study of ML-Agents
### Study #1 - SquareChar:
<p>Recently I have created a 2D-scene where the agent is a square character and the target is a box relatively close to the agent. The configuration for the environment is the following:</p>
<p>Goal: the agent moves towards the box</p>
<p>Rewards: 1 for reaching the target, -0.1 for going out of bounds, -0.001 for every step where the agent has not reached the target</p>
<p>Observations: The position of the target (Vector3), The position of the agent (Vector3), The x and y velocity of the agent (both floats)</p>
<p>Action Space: Continuous, two points that combine to create a direction vector for the force applied to the Rigidbody2D component of the agent and then multipled by some scalar "speed"</p>
<p>Reset Condition: The agent has gone outside of the bounds set in the agent script</p>
<p align="center">
  <img width="720" src=ScreenShots/environment.png>
</p>
Find the current project and progress at: https://github.com/CooperR97/UnityMachineLearning/tree/master/squareCharML

Adapted and modified from: https://github.com/Unity-Technologies/ml-agents
