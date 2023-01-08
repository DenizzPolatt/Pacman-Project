using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PacmanController : MonoBehaviour
{
    private float speed = 30f;
    private Rigidbody _rigidbody;
    public int KilledGhosts = 0;
    private bool _isPoweredUp;
    private float _boosterTimer;
    
    public Material GhostBoostBlueMaterial;
    public Material GhostDefaultMaterial;
    public GameObject[] ghosts;
    public Material PacmanDefaultMaterial;
    public Material PacmanBoostMaterial;
    
    
    
    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKey(KeyCode.W))
            _rigidbody.velocity = new Vector3(0, 0, speed);
        if(Input.GetKey(KeyCode.S))
            _rigidbody.velocity = new Vector3(0, 0, -speed);
        if(Input.GetKey(KeyCode.A))
            _rigidbody.velocity = new Vector3(-speed, 0, 0);
        if(Input.GetKey(KeyCode.D))
            _rigidbody.velocity = new Vector3(speed, 0, 0);

        if (KilledGhosts == ghosts.Length)
        {
            SceneManager.LoadScene(0);
        }
        
        if (gameObject.transform.position.x < -50f)
        {
            _rigidbody.transform.position = new Vector3(50, 0, 0);
            _rigidbody.velocity = new Vector3(-speed, 0, 0);
        }
        
        if (gameObject.transform.position.x > 50f)
        {
            _rigidbody.transform.position = new Vector3(-50, 0, 0);
            _rigidbody.velocity = new Vector3(speed, 0, 0);
        }

        BoosterUpdate();
    }

    private void BoosterUpdate()
    {
        if (_isPoweredUp)
        {
            _boosterTimer -= Time.deltaTime;
            if (_boosterTimer < 0)
            {
                PowerDown();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ghost") && _isPoweredUp)
        {
            KilledGhosts++;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Ghost") && !_isPoweredUp)
        {
            SceneManager.LoadScene(0);
        }
    }
    
    public void PowerUp()
    {
        _boosterTimer += 5;
        _isPoweredUp = true;
        speed = 60;
        PaintToBoosted();
    }
    
    private void PowerDown()
    {
        _isPoweredUp = false;
        speed = 30;
        PaintToDefault();
    }

    private void PaintToDefault()
    {
        for (int i = 0; i < ghosts.Length; i++)
        {
            if (ghosts[i] != null)
                ghosts[i].GetComponent<MeshRenderer>().material = GhostDefaultMaterial;
        }
        gameObject.GetComponent<MeshRenderer>().material = PacmanDefaultMaterial;
    }
    
    private void PaintToBoosted()
    {
        for (int i = 0; i < ghosts.Length; i++)
        {
            if (ghosts[i] != null)
                ghosts[i].GetComponent<MeshRenderer>().material = GhostBoostBlueMaterial;
        }
        gameObject.GetComponent<MeshRenderer>().material = PacmanBoostMaterial;
    }
}
