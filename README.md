# UnityMachineLearning
## Case Study of ML-Agents
### Study #1 - SquareChar (work in progress):
<p>Recently I have created a 2D-scene where the agent is a square character and the target is a box relatively close to the agent. The configuration for the environment is the following:</p>
<p>Goal: the agent moves towards the box</p>
<p>Rewards: 1 for reaching the target, -0.1 for going out of bounds, -0.001 for every step where the agent has not reached the target</p>
<p>Observations: The position of the target (Vector3), The position of the agent (Vector3), The x and y velocity of the agent (both floats)</p>
<p>Action Space: Continuous, two points that serve as components to create a direction vector for the force applied to the Rigidbody2D component of the agent and then multipled by some scalar "speed"</p>
<p>Reset Condition: The agent has gone outside of the bounds set in the agent script</p>
<p>Orange box: Agent, Green box: Target, Red box: Agent boundaries, Blue box: Target respawn area</p>
<p align="center">
  <img width="720" src=ScreenShots/environment.png>
</p>
<p>After getting multiple failing results for a short period, I changed the default number of steps to 200,000 and started to see a trend upwards in reward. The trend was small, but it was enough to see that it was in fact trending upwards.</p>
<p align="center">
  <img width="360" src=ScreenShots/longTrain1.png>
</p>
<p align="center">HyperParameters for the first train:</p>
<p align="center">
  <img width="180" src=ScreenShots/HPLongTrain1.png>
</p>
<p>After the successful first train, I decided to turn the batch_size down to 10 and the buffer_size down to 100 after reading about PPO parameters from: https://github.com/Unity-Technologies/ml-agents/blob/master/docs/Training-PPO.md. I also decreased the number of hidden layers to 1. This resulted in increased performance.</p>
<p align="center">
  <img width="360" src=ScreenShots/longTrain2.png>
</p>
<p align="center">HyperParameters for the first train:</p>
<p align="center">
  <img width="180" src=ScreenShots/HPLongTrain2.png>
</p>
<p>The resulting value function gives the agent the following behvior:</p>

![](result.gif)

Agent script can be found at: https://github.com/CooperR97/UnityMachineLearning/blob/master/squareCharML/Assets/SquareCharGame/Scripts/SquareCharAgent.cs
### Study #2 - MLLaneSmash (work in progress):
<p>The goal of this game is to get to the end of the level without hitting an obstacle.</p>
<p>The grey blocks: obstacles</p>
<p>Orange square: the player char</p>
<p>Red outline: level boundaries</p>
<p>Observations: The player position (Vector3), RayPerceptions (For more on this visit: https://github.com/Unity-Technologies/ml-agents/blob/3d7c4b8d3c1ad17070308b4e06bb57d4a80f9a0c/UnitySDK/Assets/ML-Agents/Examples/SharedAssets/Scripts/RayPerception3D.cs</p>
<p>Action Space: -1 or 1 corresponding to move left or right</p>
<p align="center">
  <img width="360" src=LaneSmash.png>
</p>
![](cubeTrain. gif)
<p>Still working to have a general model that makes decisions based on obstacles rather than memorizing a path on a certain level</p>

### Study #3 - MLLaneSmash2D (work in progress):
<p>I have created another 2D-scene where the agent is circular character and the targets are enemy boxes that are coming towards the agent in random patterns. The configuration of the environment is the following:</p>
<p>Goal: survive the environment without gitting hit by an enemy</p>
<p>Rewards: 0.02 for every step where the agent does not hit an enemy, -2 for every step that the agent collides with an enemy, -5 for every time that the agent dies</p>
<p>Observations: The position of the agent (Vector3), a vector containing 1's and 0's representing the pattern of the enemies in the x position of the agent</p>
<p>Action Space: Discrete, which of the 3 positions is the agent going to snap to, determined by the discrete value of either 0, 1, or 2</p>
<p>Reset Condition: The agents health has reached 0. The agent is initialized with a health of 3 and is penalized one health point everytime it hits an enemy.</p>
<p>Orange Box: Agent, Arrows: represent the way elements in the environment can move</p>
<p align="center">
  <img width="720" src=ScreenShots/enivornment2.png>
</p>
Agent script can be found at: https://github.com/CooperR97/UnityMachineLearning/blob/master/MLLaneSmash2D/Assets/Script/LaneAgent.cs


Adapted and modified from: https://github.com/Unity-Technologies/ml-agents
