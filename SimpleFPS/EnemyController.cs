using UnityEngine;
using UnityEngine.AI;
using System.Collections;



public class EnemyController : MonoBehaviour {

	NavMeshAgent enemyAgent;

	Transform player;

	void Start () {

		enemyAgent = GetComponent<NavMeshAgent>();
		player = GameObject.FindGameObjectWithTag("Player").transform;

	}

	void Update () {
		
		// if(player != null){

		// 	enemyAgent.transform.LookAt(player.position);
		// 	enemyAgent.SetDestination(player.position);

		// }
		if(player != null){
			enemyAgent.transform.LookAt(player.position);
			enemyAgent.SetDestination(player.position);


			Vector3 location = transform.position-player.position;


			if(location.magnitude <= 2.0){
				//enemyAgent.Stop();
			}else if(location.magnitude <= 5.0){
				//enemyAgent.Stop();
				enemyAgent.speed = 20.0f;
			}else if(location.magnitude <= 15.0){
				enemyAgent.speed = 1.0f;
			}else{
				enemyAgent.speed = 10.0f;
			}
		}


	}
}



/*
		if(player != null){
			enemyAgent.transform.LookAt(player.position);
			enemyAgent.SetDestination(player.position);


			Vector3 location = transform.position-player.position;


			if(location.magnitude <= 2.0){
				//enemyAgent.Stop();
			}else if(location.magnitude <= 5.0){
				//enemyAgent.Stop();
				enemyAgent.speed = 20.0f;
			}else if(location.magnitude <= 15.0){
				enemyAgent.speed = 1.0f;
			}else{
				enemyAgent.speed = 10.0f;
			}
		}
		*/
