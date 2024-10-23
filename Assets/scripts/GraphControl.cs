using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphControl : MonoBehaviour
{
    public List<NodeControl> listAllNodes;
    public TextAsset textNodesPosition;
    public string[] arrayNodeRowsPosition;
    public string[] arrayNodeColumnsPosition;
    public GameObject objectNodePrefab;

    public TextAsset textNodesConnections;
    public string[] arrayNodeRowsConnections;
    public string[] arrayNodeColumnsConnections;
    // Start is called before the first frame update
    void Start()
    {
        DrawNodes();
        ConnectNodes();
        SetInitialNode();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DrawNodes()
    {
        GameObject currentNode;
        arrayNodeRowsPosition = textNodesPosition.text.Split('\n');
        for (int i = 0; i <arrayNodeRowsPosition.Length;++i) {
            arrayNodeColumnsPosition = arrayNodeRowsPosition[i].Split(';');
            Vector2 positionToCreate = new Vector2(float.Parse(arrayNodeColumnsPosition[0]), float.Parse(arrayNodeColumnsPosition[1]));
            currentNode = Instantiate(objectNodePrefab,transform);
            currentNode.name = "NODE" + i.ToString();
            listAllNodes.Add(currentNode.GetComponent<NodeControl>());
        }
    }
    void ConnectNodes() {

        arrayNodeRowsConnections = textNodesConnections.text.Split('\n');
        for (int i = 0; i < listAllNodes.Count; ++i) {
            arrayNodeColumnsConnections = arrayNodeColumnsConnections[i].Split(';');
            for (int j = 0; j < arrayNodeColumnsConnections.Length; ++j) {
                listAllNodes[i].AddAdjacentNode(listAllNodes[j]);
            }   
        }
    }
    void SetInitialNode() {
        int position = Random.RandomRange(0, listAllNodes.Count);
        //currentEnemy.SetNewPosition(listAllNodes[0].gameObject.transform.position);
    }
}
