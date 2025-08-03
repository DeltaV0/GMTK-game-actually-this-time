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
    public void remove(Collectible itemToRemove){
        //duplicate so buttons can access
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

    public static int GetItem(string itemName)
    {
        for (int i = 0; i < playerCollectibles.Count; i++)
        {
            if(playerCollectibles[i].name.Equals(itemName))
            {
                return i;
            }
        }
        return -1;
    }

    public static void AddItem(Collectible newCollectible)
    {
        playerCollectibles.Add(newCollectible);
        GameObject newItem = Instantiate(itemPrefab, inventoryTrans);
        playerItemObjects.Add(newItem);
        newItem.GetComponent<RawImage>().texture = newCollectible.collectibleImage;
        newItem.GetComponent<RawImage>().color = newCollectible.color;
        Vector2 imageDimensions = new Vector2(newCollectible.collectibleImage.width, newCollectible.collectibleImage.height);
        if(imageDimensions.x > imageDimensions.y)
        {
            newItem.GetComponent<RectTransform>().sizeDelta *= new Vector2(1, imageDimensions.y / imageDimensions.x);
        }
        else if (imageDimensions.y > imageDimensions.x)
        {
            newItem.GetComponent<RectTransform>().sizeDelta *= new Vector2(imageDimensions.x / imageDimensions.y, 1);
        }
        Debug.Log(size.y);
        Debug.Log(firstPos);
        newItem.GetComponent<RectTransform>().anchoredPosition = (firstPos + new Vector2((offset + size.y) * (playerItemObjects.Count - 1), 0));
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
