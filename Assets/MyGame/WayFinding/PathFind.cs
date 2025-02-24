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
        List<Node> openSet= new List<Node>();//�洢�����ĵ�
        HashSet<Node> closedSet= new HashSet<Node>();//�洢�Ѿ������ĵ�
        openSet.Add(startNode);
        while (openSet.Count > 0)
        {
            Node currentNode = openSet[0];
            //�ڿ����б����ҵ���С��f��
            for (int i = 1; i < openSet.Count; i++) 
            {
                //�����ܴ��۽����жϣ�ÿ��ѡ���ܴ���С��
                if (currentNode.fCost > openSet[i].fCost || (currentNode.fCost == openSet[i].fCost && currentNode.hCost > openSet[i].hCost))
                {
                    currentNode=openSet[i];
                }
            }
            openSet.Remove(currentNode);
            closedSet.Add(currentNode);
            //��ǰ�����Ŀ��������
            if (currentNode == targetNode)
            {
                return RetracePath(startNode, targetNode);//�ҵ���βtargetNode��ͷstartNode��·��
            }
            foreach(var neighbour in GetNeighbours(currentNode))
            {
                if (!neighbour.isWalkAble || closedSet.Contains(neighbour))
                {
                    continue;
                }
                int newG=currentNode.gCost+GetDistance(currentNode,neighbour);//�����g�����ǵ�ǰ�ڵ��g+�ڽڵ��g
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
    //���ݽڵ㣬����β�ڵ��ҵ���ʼ�ڵ�
    private List<Node> RetracePath(Node startNode,Node endNode)
    {
        List<Node> path= new List<Node>();
        Node currentNode=endNode;
        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode=currentNode.parent;
        }
        path.Reverse();//��ת·��
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
