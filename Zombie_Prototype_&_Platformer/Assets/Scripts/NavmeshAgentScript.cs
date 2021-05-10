using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavmeshAgentScript : MonoBehaviour {

    private Transform target;
    public float speed;
    NavMeshAgent agent; 

    // Use this for initialization
	void Start () 
    {
       // agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;       
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.LookAt(target);
        transform.Translate(new Vector3(0, 0, transform.localPosition.z) * speed * Time.deltaTime);
        //agent.SetDestination(target.position);        
    }
}
