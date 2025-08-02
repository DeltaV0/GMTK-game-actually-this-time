using UnityEngine;
using System;

[Serializable]
public class Collectible
{
    public Texture2D collectibleImage;
    public string name;
    public Color color;
    public Collectible(Texture2D collectibleImage, string name, Color color)
    {
        this.collectibleImage = collectibleImage;
        this.name = name;
        this.color = color;
    }
}

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class CollectibleObject : MonoBehaviour
{
    public Collectible collectible;

    private void Awake()
    {
        if(collectible.collectibleImage == null)
        {
            collectible.collectibleImage = GetComponent<SpriteRenderer>().sprite.texture;
            collectible.color = GetComponent<SpriteRenderer>().color;
        }
        if(collectible.name == null || collectible.name == "")
        {
            collectible.name = name;
        }
        GetComponent<Collider2D>().isTrigger = true;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Me rn :3")
        {
            Inventory.AddItem(collectible);
            Destroy(gameObject);
        }
    }
}
