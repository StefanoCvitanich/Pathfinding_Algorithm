using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

	public Node parent;

	public List<Node> neighboursList;

	//public Queue<Node> visitedNodesQueue;

	//int row, col;

	public bool alreadyVisited = false;

	public Vector3 pos;

	// Use this for initialization
	void Start () {

        pos.x = gameObject.transform.position.x;
        pos.y = gameObject.transform.position.y;
        pos.z = gameObject.transform.position.z;

    }

	// Update is called once per frame
	void Update () {

	}
}
