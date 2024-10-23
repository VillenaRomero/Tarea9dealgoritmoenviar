using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Mapa : MonoBehaviour
{
    public TextAsset txtMap;
    public string[] arrayRowsInformation;
    public string[] arrayColumnsInformation;
    public Sprite[] arrayMapSprites;
    public GameObject objectMapPrefab;
    public Vector2 positionInicialMapParts;
    public Vector2 separationFromMapParts;
    // Start is called before the first frame update
    void Start()
    {
        Drawmap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Drawmap() {
        int index = 0;
        GameObject currentMapPart;
        Vector2 positionToCreateMapPart;
        arrayRowsInformation = txtMap.text.Split('\n');
        for (int i = 0;i< arrayRowsInformation.Length; ++i ) {
            arrayColumnsInformation = arrayRowsInformation[i].Split(';');
            for (int j = 0; j < arrayRowsInformation.Length; ++j) {
                index = int.Parse(arrayRowsInformation[j]);

                positionToCreateMapPart = new Vector2(positionInicialMapParts.x+separationFromMapParts.x*j,positionInicialMapParts.y-separationFromMapParts.y);

                currentMapPart = Instantiate(objectMapPrefab, positionToCreateMapPart, transform.rotation);
                currentMapPart.GetComponent<MapPart>().SetSprite(arrayMapSprites[index]);
                currentMapPart.transform.SetParent(this.transform);
                currentMapPart.transform.SetParent(null);
            }
        }
    }
}
