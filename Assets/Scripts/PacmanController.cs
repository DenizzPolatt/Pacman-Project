using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanController : MonoBehaviour
{
    private float speed = 30f;

    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
            _rigidbody.velocity = new Vector3(0, 0, speed);
        if(Input.GetKey(KeyCode.S))
            _rigidbody.velocity = new Vector3(0, 0, -speed);
        if(Input.GetKey(KeyCode.A))
            _rigidbody.velocity = new Vector3(-speed, 0, 0);
        if(Input.GetKey(KeyCode.D))
            _rigidbody.velocity = new Vector3(speed, 0, 0);
    }
}
