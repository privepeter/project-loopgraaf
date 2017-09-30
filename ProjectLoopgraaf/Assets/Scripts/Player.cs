using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Player : MonoBehaviour {

    NavMeshAgent pathfinder;
    Transform target;
    Vector3 targetPos;

	void Start () {
        pathfinder = GetComponent<NavMeshAgent>();
        target = transform;
        targetPos = new Vector3(target.position.x +10, 0, target.position.z + 5);
        pathfinder.SetDestination(targetPos);
        pathfinder.acceleration = 60f;
    }
	
	void Update () {
        if (Input.GetMouseButtonDown(1)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float distance;
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            groundPlane.Raycast(ray, out distance);
            pathfinder.SetDestination(ray.GetPoint(distance));
        }
    }
}
