using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public GameObject propeller;
    public GameObject plane;
    public float speed = 50f;
    public float horizontal = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        propeller.transform.Rotate(Vector3.forward * (Time.deltaTime + 20));
        plane.transform.Translate(Vector3.forward * Time.smoothDeltaTime * ((speed)));
        this.transform.Rotate(Vector3.up * Time.smoothDeltaTime * horizontal);
    }
}
