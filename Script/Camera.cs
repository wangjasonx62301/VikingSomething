using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public Transform target;
    private Vector3 offset;
    public Quaternion rotation;
    public int x = 0;
    // Start is called before the first frame update
    void Start()
    {
        rotation = Quaternion.Euler(x, 0, 0);
        offset = target.position - this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = target.position - rotation * offset;
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            x += 90;
            rotation = Quaternion.Euler(0, x, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            x -= 90;
            rotation = Quaternion.Euler(0, x, 0);
        }
        transform.LookAt(target);
    }

    
}
