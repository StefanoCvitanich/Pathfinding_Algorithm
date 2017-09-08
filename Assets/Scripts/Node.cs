using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

	public Node parent;

	public List<Node> neighboursList;

	public bool alreadyVisited = false;

	public Vector3 pos;

    public float weight, distanceToTarget;

    public GameObject targetNode;

	// Use this for initialization
	void Start () {

        pos.x = gameObject.transform.position.x;
        pos.y = gameObject.transform.position.y;
        pos.z = gameObject.transform.position.z;

        distanceToTarget = Mathf.Abs(Vector3.Distance(pos, targetNode.GetComponent<Node>().pos));

    }

	// Update is called once per frame
	void Update () {

	}
}
