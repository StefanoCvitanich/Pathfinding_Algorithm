using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum algorithm {

    Breadth_First,

    Dijkstra,

    A_Star
};

public class pathfinder : MonoBehaviour {

    Queue<Node> openedNodes;

    List<Node> closedNodes;

    List<Node> path;

    List<Node> nodeList;

    GameObject[] nodes;

    public Node targetNode;

    public Node startNode;

    public Node currentNode;

    // Use this for initialization
    void Start() {

        nodes = GameObject.FindGameObjectsWithTag("Node");

    }

    // Update is called once per frame
    void Update() {

    }

    private List<Node> findPath(Node start, Node end)
    {
        //openNode(startNode); //falta poner lo del padre
        openNode(start, null);
       // openedNodes.Enqueue(nodeToOpen);

        while (openedNodes.Count != 0)
        {
            currentNode = visitNode();

            currentNode.GetComponent<Node>().alreadyVisited = true;

            if (isTargetNode(nodeToOpen))
                return; //No entendi como es el return

            closedNodes.Add(currentNode);

            openNeighbours(currentNode);
        }

        return path;
    }

    private void openNode(Node nodeToOpen, Node parent) {


        nodeToOpen.parent = parent;
        openedNodes.Enqueue(nodeToOpen);


    }

    private Node visitNode()
    {
        return openedNodes.Dequeue();
    }

    private void openNeighbours(Node nodeToOpenNeighbours) {

        for (int i = 0; i < currentNode.neighboursList.Count; i++) {
            openNode(currentNode.neighboursList[i], nodeToOpenNeighbours);
            //openedNodes.Enqueue(currentNode.neighboursList[i]);
        }

    }

    private bool isTargetNode(Node nodeToCheck) {

        if (nodeToCheck == targetNode)
            return true;

        else
            return false;
    }

    private void fillNodeList() {

        for (int i = 0; i < nodes.Length; i++)
            nodeList.Add(nodes[i].GetComponent<Node>());

    }

    private void findNeighbours() {

        for (int i = 0; i < nodeList.Count; i++) {

            for (int j = 0; j < nodeList.Count; j++) {

                if (Vector3.Distance(nodeList[i].pos, nodeList[j].pos) <= 1)
                    nodeList[i].neighboursList.Add(nodeList[j]);
            }
        }
    }
    /*
	private void gridGenerator(int rows, int columns) {
	
		GameObject[][] grid = new GameObject [rows][];

		for (int i = 0; i < rows; i++) {
		
			grid[i] = new GameObject[columns];   //Quiero hacer que el valor de columns varie
											//Tengo que hacer un switch de i y dependiendo del valor modifico a columns?
		}
	
	}

    private void createNodesInGrid() {

        
    }
    */
}
