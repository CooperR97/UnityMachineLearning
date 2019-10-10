# UnityMachineLearning
## Case Study of ML-Agents
### Study #1 - SquareChar:
Recently I have created a 2D-scene where the agent is a square character and the target is a box relatively close to the agent. The configuration for the environment is the following:
Goal: the agent moves towards the box
Rewards: 1 for reaching the target, -0.1 for going out of bounds, -0.001 for every step where the agent has not reached the target
Observations: The position of the target (Vector3), The position of the agent (Vector3), The x and y velocity of the agent (both floats)
Action Space: Continuous, two points that combine to create a direction vector for the force applied to the Rigidbody2D component of the agent and then multipled by some scalar "speed"
Reset Condition: The agent has gone outside of the bounds set in the agent script


Find the current project and progress at: https://github.com/CooperR97/UnityMachineLearning/tree/master/squareCharML

Adapted and modified from: https://github.com/Unity-Technologies/ml-agents
