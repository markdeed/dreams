using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeCheck : MonoBehaviour
{
    private Transform gaze;
    // Will contain the information of which object the raycast hit
    private RaycastHit hit;
    private float maxDistance = 10.0f;

    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GazeCheck Start");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("GazeChecking onupdate");
        // if raycast hits, it checks if it hit an object with the tag conversationable

        dir = gaze.TransformDirection(0, 0,1);
       
        Debug.DrawRay(gaze.position, dir, Color.green);

        //  if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, maxDistance) && hit.collider.gameObject.CompareTag("conversationable"))
        if (Physics.Raycast(gaze.position, gaze.forward, out hit, maxDistance) && hit.collider.gameObject.CompareTag("conversationable"))
            {
            //Physics.Raycast(child.transform.position, child.transform.forward, out hit, 25.0f);
            Debug.Log("you lookin at me");
        }
        else
        {
            Debug.Log("you not lookin at me");
        }

   



    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("GazeChecking enable"+ other.gameObject.tag);
        if(other.gameObject.tag == "Player")
        {
            // this.player = other.gameObject;
            this.gaze = other.gameObject.transform.Find("aj/h_Geo").transform;
           // Debug.Log(this.player.name);
            this.enabled = true;
        }
       
        //if other is player enable other 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("GazeChecking disable");
            this.enabled = false;
        }
    }
}
