using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathfinder : MonoBehaviour {

	Queue<Node> openedNodes;

	List <Node> closedNodes;

	List<Node> path;

	Node targetNode;

	Node startNode;

	Node currentNode;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	private List<Node> findPath()
	{
		openNode(startNode); //falta poner lo del padre

		return path;
	}

	private void openNode(Node nodeToOpen, Node parent) {

		openedNodes.Enqueue(nodeToOpen);

		while (openedNodes.Count != 0)
		{
			currentNode = visitNode();

			currentNode.GetComponent<Node>().alreadyVisited = true;

			if (isTargetNode(nodeToOpen))
				return; //No entendi como es el return

			closedNodes.Add(currentNode);

			openNeighbours(currentNode);
		}
	}

	private Node visitNode()
	{
		return openedNodes.Dequeue();
	}

	private void openNeighbours(Node nodeToOpenNeighbours){



	}

	private bool isTargetNode(Node nodeToCheck) {

		if (nodeToCheck == targetNode)
			return true;
		
		else
			return false;
	}

	private void gridGenerator(int rows, int columns) {
	
		GameObject[][] grid = new GameObject [rows][];

		for (int i = 0; i < rows; i++) {
		
			grid[i] = new GameObject[columns];   //Quiero hacer que el valor de columns varie
											//Tengo que hacer un switch de i y dependiendo del valor modifico a columns?
		}
	
	}
}
