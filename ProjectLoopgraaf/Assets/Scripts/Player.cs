using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Player : MonoBehaviour {

    // Finds route in the trenches:
    NavMeshAgent pathfinder;
    Plane groundPlane;

	void Start () {
        pathfinder = GetComponent<NavMeshAgent>();
        pathfinder.acceleration = 60f;

        groundPlane = new Plane(Vector3.up, Vector3.zero);
    }
	
	void Update () {
        // Click on point in level to move there. 
        // Or at least as close as possible.
        if (Input.GetMouseButtonDown(1)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            float distance;
            groundPlane.Raycast(ray, out distance);
            pathfinder.SetDestination(ray.GetPoint(distance));
        }
    }
}
