using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        var pacman = collider.GetComponent<PacmanController>();
        if (pacman != null)
        {
            pacman.PowerUp();
            Destroy(gameObject);
        }
    }
}
