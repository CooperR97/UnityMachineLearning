using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{

	public GameManager gameManager;
    public LaneAgent lane;

	void OnTriggerEnter () {
        //gameManager.CompleteLevel();
        lane.complete = true;
	}

}
