using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollows : MonoBehaviour {
    public GameObject Sphere;
    private Vector3 distance;
    // Use this for initialization
    void Start () {
        distance = transform.position - Sphere.transform.position;
    }

    // Update is called once per frame
    void Update () {
        transform.position = distance + Sphere.transform.position;
    }
}
