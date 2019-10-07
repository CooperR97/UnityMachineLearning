# Unity Machine Learning
Unity has an experimental Machine Learning module that is available to the public. This readme is designed for *Mac* users. 
Its purpose is to provide a quick start guide to get the ml-agents model up and running the pretrained model included with ml-agents and to quickly transition to training your own model.

## Quick Start Guide for *Mac*:
1) Clone the repo found at: https://github.com/Unity-Technologies/ml-agents to a convinient location.
2) Create a virtual environment using Python by running the following command:
```
python3 -m venv envNameHere
```
To activate the environment, run:
```
source ./envNameHere/bin/activate
```
To deactivate the environment run:
```
deactivate
```
3) When you clone the repo, inside of the repo's root folder, ml-agents, there will be two folders that you will need to locate and cd into from the terminal. The two folders are *ml-agents* and *ml-agents-env*. The sequence of commands to install the module from the folders is as follows:
```sh
cd ml-agents-envs
pip3 install -e ./
cd ..
cd ml-agents
pip3 install -e ./
```
Note: Make sure you are running the previous commands from within the virtual environment.
