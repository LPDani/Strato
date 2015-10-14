using UnityEngine;
using System.Collections.Generic;

public class Node {

    public enum eTileColor
    {
        Black = 0,
        Red = 1,
        Green = 2
    };

    eTileColor[] tileColors = new eTileColor[3];
    public Vector3 nodePosition { get; set; }

    bool isFree = true;

    public Node() { 
        
    }

    public Node(Vector3 nodePosition, bool isFree = true) {
        this.nodePosition = nodePosition;
        this.isFree = isFree;
    }
}
