using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Builds the graph
/// </summary>
public class GraphBuilder : MonoBehaviour
{
    static Graph<Country> graph;

    /// <summary>
    /// Awake is called before Start
    /// </summary>
    void Awake()
    {
        GameObject[] countries = GameObject.FindGameObjectsWithTag("Country");

        // add nodes (all Countries) to graph
        graph = new Graph<Country>();
        foreach (GameObject country in countries)
        {
            graph.AddNode(country.GetComponent<Country>());
        }

        // add edges to graph
        foreach (GraphNode<Country> firstNode in graph.Nodes)
        {
            //Debug.Log(firstNode.Value.CountryName + " Neighbors = " + firstNode.Value.neighbours.Count);
            if (firstNode.Value.neighbours.Count > 0)
            {
                foreach (GraphNode<Country> secondNode in graph.Nodes)
                {
                    // if country has other country like a neighbours add that country like adge
                    foreach (Country country in firstNode.Value.neighbours)
                    {
                        if (country == secondNode.Value)
                        {
                            Vector2 positionDelta1 = firstNode.Value.Position -
                                                    secondNode.Value.Position;

                            firstNode.AddNeighbor(secondNode, positionDelta1.magnitude);

                            Vector2 positionDelta2 = secondNode.Value.Position - firstNode.Value.Position;

                            secondNode.AddNeighbor(firstNode, positionDelta2.magnitude);

                        }
                    }
                }
            }

        }
    }

    /// <summary>
    /// Gets the graph
    /// </summary>
    /// <value>graph</value>
    public static Graph<Country> Graph
    {
        get { return graph; }
    }
}
