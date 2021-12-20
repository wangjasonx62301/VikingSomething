using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTrigger : MonoBehaviour
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
        if(collider.tag == "ground")
        {
            print("yeah");
            FindObjectOfType<VIkingController>().onGround = true;
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "ground")
        {
            print("yeah");
            FindObjectOfType<VIkingController>().onGround = true;
            
        }
    }

}
