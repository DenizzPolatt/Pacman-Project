using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PacmanController : MonoBehaviour
{
    private float speed = 30f;
    public bool _isPoweredUp;
    public Material Material1;
    public Material DefaultMaterial;
    public GameObject[] ghosts;

    private Rigidbody _rigidbody;
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

        if (_isPoweredUp)
        {
            PowerUp();
        }

        if (ghosts.Length == 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ghost") && _isPoweredUp)
        {
            Destroy(collision.gameObject);
            PowerUp();
        }

        if (collision.gameObject.CompareTag("Ghost") && !_isPoweredUp)
        {
            SceneManager.LoadScene(0);
        }
    }

    private IEnumerator BoosterCountdown()
    {
        yield return new WaitForSeconds(5);
        _isPoweredUp = false;
        speed = 30;
        
        for (int i = 0; i < ghosts.Length; i++)
        {
            if(ghosts[i] != null)
                ghosts[i].GetComponent<MeshRenderer>().material = DefaultMaterial;
        }
    }
    
    private void PowerUp()
    {
        Debug.Log("boosted");
        
        for (int i = 0; i < ghosts.Length; i++)
        {
            if(ghosts[i] != null)
                ghosts[i].GetComponent<MeshRenderer>().material = Material1;
        }
        
        speed = 60;
        StartCoroutine(BoosterCountdown());
    }
}
