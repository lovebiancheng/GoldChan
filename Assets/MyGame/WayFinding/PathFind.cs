using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Analytics;

public class PathFind 
{
    public Node[,] grid;
    private int gridWidth;
    private int gridHeight;

    public PathFind(int width,int height)
    {
        gridWidth = width;
        gridHeight = height;
        grid = new Node[gridWidth, gridHeight];
        for (int i = 0; i < gridWidth; i++) 
        {
            for (int j = 0; j < gridHeight; j++) 
            {
                grid[i,j]=new Node(i,j,true);
            }
        }
    }
    public List<Node> FindPath(int startX,int startY,int tartX,int tartY)
    {
        Node startNode=grid[startX,startY];
        Node targetNode=grid[tartX,tartY];
        List<Node> openSet= new List<Node>();//存储待检查的点
        HashSet<Node> closedSet= new HashSet<Node>();//存储已经检查过的点
        openSet.Add(startNode);
        while (openSet.Count > 0)
        {
            Node currentNode = openSet[0];
            //在开放列表中找到最小的f点
            for (int i = 1; i < openSet.Count; i++) 
            {
                //根据总代价进行判断，每次选择总代价小的
                if (currentNode.fCost > openSet[i].fCost || (currentNode.fCost == openSet[i].fCost && currentNode.hCost > openSet[i].hCost))
                {
                    currentNode=openSet[i];
                }
            }
            openSet.Remove(currentNode);
            closedSet.Add(currentNode);
            //当前点等于目标点则结束
            if (currentNode == targetNode)
            {
                return RetracePath(startNode, targetNode);//找到从尾targetNode到头startNode的路径
            }
            foreach(var neighbour in GetNeighbours(currentNode))
            {
                if (!neighbour.isWalkAble || closedSet.Contains(neighbour))
                {
                    continue;
                }
                int newG=currentNode.gCost+GetDistance(currentNode,neighbour);//这里的g代价是当前节点的g+邻节点的g
                if (newG < currentNode.gCost || !openSet.Contains(currentNode))
                {
                    neighbour.gCost = newG;
                    neighbour.hCost = GetDistance(neighbour,targetNode);
                    neighbour.parent = currentNode;

                    if (!openSet.Contains(neighbour))
                    {
                        openSet.Add(neighbour);
                    }
                }
            }
        }
        return null; 
    }
    //回溯节点，根据尾节点找到开始节点
    private List<Node> RetracePath(Node startNode,Node endNode)
    {
        List<Node> path= new List<Node>();
        Node currentNode=endNode;
        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode=currentNode.parent;
        }
        path.Reverse();//反转路径
        return path;
    }
    private List<Node> GetNeighbours(Node node) 
    {
        List<Node> neighbours= new List<Node>();
        for (int i = -1; i <= 1; i++) 
        {
            for(int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0)
                {
                    continue;
                }
                int checkX = node.x + i;
                int checkY = node.y + j;
                if (checkX >= 0 && checkY >= 0&&checkX<gridWidth&&checkY<gridHeight) 
                {
                    neighbours.Add(grid[checkX,checkY]);
                }
            }
        }
        return neighbours;
    }
    private int GetDistance(Node nodeA, Node nodeB) 
    {
        int xDistance=Mathf.Abs(nodeA.x - nodeB.x);
        int yDistance=Mathf.Abs(nodeA.y - nodeB.y);
        int diagonalSteps=Mathf.Min(xDistance,yDistance);
        int strightSteps=Mathf.Max(xDistance, yDistance)-diagonalSteps;
        return strightSteps * 10 + diagonalSteps * 14;
    }
}
