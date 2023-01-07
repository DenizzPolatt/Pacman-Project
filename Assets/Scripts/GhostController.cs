using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    private float speed = 30f;
    private bool direction;

    //public Material Material1;
    
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var step =  speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, GetCurrentTarget(), step);

        if (Vector3.Distance(transform.position, GetCurrentTarget()) < 0.1f)
        {
            direction = !direction;
        }
        
    }

    private Vector3 GetCurrentTarget()
    {
        if (direction)
        {
            return _pointA.position;
        }

        return _pointB.position;
    }
    
    
}
