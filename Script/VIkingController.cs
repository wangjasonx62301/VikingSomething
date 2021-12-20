using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]


public class VIkingController : MonoBehaviour
{
    public Vector3 MovingDirection;
    MeshRenderer mr;
    float movingSpeed = 10f;
    float jumpingForce = 20000f;
    Rigidbody rb;
    Animator animator;
    NavMeshAgent navmeshagent;
    float leftRotationTarget = -90f;
    float rightRotationTarget = 90f;
    float rotateSpeed = 100f;
    bool run = false;
    public bool onGround = true;
    bool isDead = false;

    private void Awake()
    {
        Debug.Log("awaked");
    }

    // Start is called before the first frame update
    void Start()
    {
        Transform t = GetComponent<Transform>();
        
        // Debug.Log("started");
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -20)
        {
            GetComponent<Score>().onDeath();
            return;
        }
        run = false;
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += movingSpeed * Time.deltaTime * transform.forward;
            run = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += movingSpeed * Time.deltaTime * (-transform.forward);
            run = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += movingSpeed * Time.deltaTime * (-transform.right);
            run = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += movingSpeed * Time.deltaTime * transform.right;
            run = true;
        }

        if (Input.GetKey(KeyCode.M))
        {
            SceneManager.LoadScene("MainMenu");
        }

        animator.SetBool("ifRun", run);
        /*
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            if(Physics.Raycast(ray, out raycastHit))
            {
                if(raycastHit.transform.name == "coins")
                {
                    Debug.Log("hit coin");
                    Destroy(raycastHit.collider.gameObject);
                }
                Debug.Log("Shoot");
            }
        }
        */


        /*
        if (Input.GetKey(KeyCode.Space) && onGround)
        {
            rb.AddForce(jumpingForce * Time.deltaTime * transform.up);
            onGround = false;
        }
        */

        // dead
        if (isDead)
        {

        }

        // rotate
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -90, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Rotate(0, 90, 0);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && onGround)
        {
            rb.AddForce(jumpingForce * Time.deltaTime * transform.up);
            onGround = false;
        }
        Debug.Log("updated");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("entered");
        if(collision.collider.name == "coins")
        {
            Debug.Log("Get coins");
            Destroy(collision.collider.gameObject);
            
        }
        if (collision.collider.name == "Landscape1(Clone)" || collision.collider.name == "landscape2(Clone)")
        {
            print("wow");
            onGround = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.name == "Landscape1(Clone)" || collision.collider.name == "landscape2(Clone)")
        {
            Debug.Log("stay");
            onGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Coin")
        {
            Destroy(collider.gameObject);
            GetComponent<Score>().addCoin();
        }
        if (collider.tag == "Obstacle")
        {
            // death
            isDead = true;
        }
    }

}
