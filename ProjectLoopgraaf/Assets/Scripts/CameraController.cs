using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private Vector3 origin;
    private Plane plane = new Plane(Vector3.up, Vector3.zero);

    void Update() {

        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float distance;
            plane.Raycast(ray, out distance);
            origin = ray.GetPoint(distance);
        } else if (Input.GetMouseButton(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float distance;
            plane.Raycast(ray, out distance);
            Vector3 newPosition = ray.GetPoint(distance);
            transform.position -= (newPosition - origin);
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0) {
            Camera.main.transform.Translate(Vector3.back);
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0) {
            Camera.main.transform.Translate(Vector3.forward);
        }
    }
}

