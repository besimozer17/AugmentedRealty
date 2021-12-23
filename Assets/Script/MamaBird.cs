using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MamaBird : MonoBehaviour
{
    public float speed = 0.4f;
    public float rotation_damping = 4f;
    public Camera ARCamera;
    void Start()
    {
        ARCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()

    {
        // rotation of MamaBird  towards Camera
        var rotation = Quaternion.LookRotation(ARCamera.transform.position - transform.position);
        this.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime*rotation_damping);

        // MamaBird will Fly Up;
        this.transform.position = transform.position + Vector3.up * speed*Time.deltaTime;


    }
}
