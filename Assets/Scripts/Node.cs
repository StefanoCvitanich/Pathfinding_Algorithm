using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

	//[HideInInspector]
	public Node parent;

	public List<Node> neighboursList;

	//[HideInInspector]
	public bool alreadyVisited = false;

	public Vector3 pos;

	public float weight;

	//[HideInInspector]
	public float distanceToTarget;

	public float movementCost;

    GameObject targetNode;

	// Use this for initialization
	void Start () {

        targetNode = GameObject.Find("targetNode");

        pos.x = gameObject.transform.position.x;
        pos.y = gameObject.transform.position.y;
        pos.z = gameObject.transform.position.z;

        distanceToTarget = Mathf.Abs(Vector3.Distance(pos, targetNode.GetComponent<Node>().pos));

		weight = Random.Range (1, 6);

		movementCost = distanceToTarget + weight;

    }

	// Update is called once per frame
	void Update () {

	}
}
