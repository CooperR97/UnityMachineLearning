using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour {


    public LaneAgent lane;

	
	void OnCollisionEnter (Collision collisionInfo) {
		
		if(collisionInfo.collider.tag == "Obstacle"){
            lane.enemyHit = true;
		}


	}
}
