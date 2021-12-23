using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyBird : MonoBehaviour
{
    public float speed = 0.4f;
    public float rotation_damping = 4f;
    public Transform MamaBird;
    void Start()
    {
        // only works well with MamaBird
        // MamaBird = GameObject.FindGameObjectWithTag("MamaBird").GetComponent<Transform>();
        GameObject[] MamaBirds = GameObject.FindGameObjectsWithTag("MamaBird");

        int ChoosenMamaBird =  Random.Range(0,MamaBirds.Length);
        MamaBird = MamaBirds[ChoosenMamaBird].GetComponent<Transform>();
    }

    void Update()

    {
        // rotate  towards MamaBird
        var rotation = Quaternion.LookRotation(MamaBird.transform.position - transform.position);
        this.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotation_damping);

        // BabyBird will follow Mamma;
        float step = speed* Time.deltaTime;
        this.transform.position =  Vector3.MoveTowards(transform.position, MamaBird.position, step);

    }
}
