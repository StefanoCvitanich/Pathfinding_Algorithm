using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum algorithm {

    Breadth_First,

    Dijkstra,

    A_Star
};

public class Pathfinder : MonoBehaviour
{

    List<Node> openedNodes = new List<Node>();

    List<Node> closedNodes = new List<Node>();

    List<Node> path = new List<Node>();

    List<Node> nodeList = new List<Node>();

    GameObject[] nodes;

    Node targetNode;

    Node startNode;

    Node currentNode;

    public algorithm althm;

    // Use this for initialization
    void Start()
    {

        nodes = GameObject.FindGameObjectsWithTag("Node");

        foreach (GameObject go in nodes)
        {
            go.GetComponent<Node>().pos = go.transform.position;
        }

        startNode = GameObject.Find("startNode").GetComponent<Node>();

        targetNode = GameObject.Find("targetNode").GetComponent<Node>();

        fillNodeList();

        findNeighbours();

        findPath(startNode, targetNode, althm);       

    }

    // Update is called once per frame
    void Update()
    {

    }

    private List<Node> findPath(Node start, Node end, algorithm al)
    {
        openNode(start, null);

                while (openedNodes.Count != 0)
                {
                    currentNode = visitNode(al);

                    currentNode.GetComponent<Node>().alreadyVisited = true;

                    if (isTargetNode(currentNode))
                    {

                        while (currentNode != null)
                        {
                            path.Add(currentNode);

                            foreach (GameObject go in nodes)
                            {
                                if (go.GetComponent<Node>() == currentNode)
                                    go.GetComponent<Renderer>().material.color = Color.cyan;
                            }

                            currentNode = currentNode.parent;
                        }

                        for (int i = path.Count - 1; i >= 0; i--)
                        {
                            Debug.Log(path[i].name);
                        }

                        break;
                    }


                    closedNodes.Add(currentNode);

                    openNeighbours(currentNode);
                }

        return path;
    }

    private void openNode(Node nodeToOpen, Node parent)
    {
        nodeToOpen.parent = parent;
        openedNodes.Add(nodeToOpen);
    }

    private Node visitNode(algorithm al)  //Falta hacer return del case por default
    {
        Node nodeToReturn;

        switch (al)
        {
            case algorithm.Breadth_First:

                nodeToReturn = openedNodes[0];

                openedNodes.Remove(nodeToReturn);

                return nodeToReturn;

            case algorithm.Dijkstra:

                float lowestWeight = float.MaxValue;

                nodeToReturn = openedNodes[0];

                for (int i = 0; i < openedNodes.Count; i++)
                {
                    if(openedNodes[i].weight < lowestWeight)
                    {
                        lowestWeight = openedNodes[i].weight;

                        nodeToReturn = openedNodes[i];
                    }
                }

                openedNodes.Remove(nodeToReturn);

                return nodeToReturn;

            //case algorithm.A_Star:
               // return nodeToReturn;

            default:
                return nodeToReturn = null;
        }
            
    }

    private void openNeighbours(Node nodeToOpenNeighbours)
    {
        for (int i = 0; i < nodeToOpenNeighbours.neighboursList.Count; i++)
        {

            if (!nodeToOpenNeighbours.neighboursList[i].alreadyVisited && !closedNodes.Contains(nodeToOpenNeighbours.neighboursList[i]))
            {

                openNode(nodeToOpenNeighbours.neighboursList[i], nodeToOpenNeighbours);
            }
        }
    }

    private bool isTargetNode(Node nodeToCheck)
    {

        if (nodeToCheck == targetNode)
            return true;

        else
            return false;
    }

    private void fillNodeList()
    {

        for (int i = 0; i < nodes.Length; i++)
            nodeList.Add(nodes[i].GetComponent<Node>());

    }

    private void findNeighbours()
    {
        for (int i = 0; i < nodeList.Count; i++)
        {

            for (int j = 0; j < nodeList.Count; j++)
            {

                if (Mathf.Abs(Vector3.Distance(nodeList[i].pos, nodeList[j].pos)) <= 1 && Mathf.Abs(Vector3.Distance(nodeList[i].pos, nodeList[j].pos)) > 0)
                    nodeList[i].neighboursList.Add(nodeList[j]);
            }
        }
    }
}