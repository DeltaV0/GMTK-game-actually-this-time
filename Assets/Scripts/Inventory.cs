using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class Inventory : MonoBehaviour
{
    public GameObject itemPrefabPlease;

    public static Transform inventoryTrans;
    public static List<Collectible> playerCollectibles = new List<Collectible>();
    private static List<GameObject> playerItemObjects = new List<GameObject>();
    public static GameObject itemPrefab;
    public static float offset = 50;
    public static Vector2 size = Vector2.one * 100;
    public static Vector2 firstPos = Vector2.one * 50;

    private void Awake()
    {
        inventoryTrans = transform;
        itemPrefab = itemPrefabPlease;
    }

    public static void AddItem(Collectible newCollectible)
    {
        playerCollectibles.Add(newCollectible);
        playerItemObjects.Add(Instantiate(itemPrefab, inventoryTrans));
        playerItemObjects[playerItemObjects.Count - 1].GetComponent<RawImage>().texture = newCollectible.collectibleImage;
        playerItemObjects[playerItemObjects.Count - 1].GetComponent<RectTransform>().sizeDelta = size;
        playerItemObjects[playerItemObjects.Count - 1].GetComponent<RectTransform>().position = firstPos + new Vector2((offset + size.y) * (playerItemObjects.Count - 1), 0);
    }

    public static void RemoveItem(Collectible itemToRemove)
    {
        bool foundIt = false;
        for(int i = 0; i < playerCollectibles.Count; i++)
        {
            if(foundIt)
            {
                Vector3 pos = playerItemObjects[i].GetComponent<RectTransform>().localPosition;
                playerItemObjects[i].GetComponent<RectTransform>().localPosition = new Vector3(pos.x, pos.y - size.y - offset, pos.z);
            }
            else if(playerCollectibles[i] == itemToRemove)
            {
                foundIt = true;
                Destroy(playerItemObjects[i]);
                playerItemObjects.RemoveAt(i);
                playerCollectibles.RemoveAt(i);
                i--;
            }
        }
    }
}
