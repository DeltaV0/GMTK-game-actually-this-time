using UnityEngine;
using System;

[Serializable]
public class Collectible
{
    public Texture2D collectibleImage;
    public string name;
    public Collectible(Texture2D collectibleImage, string name)
    {
        this.collectibleImage = collectibleImage;
        this.name = name;
    }
}

[RequireComponent(typeof(SpriteRenderer))]
public class CollectibleObject : MonoBehaviour
{
    public Collectible collectible;

    private void Awake()
    {
        if(collectible.collectibleImage == null)
        {
            collectible.collectibleImage = GetComponent<SpriteRenderer>().sprite.texture;
        }
        if(collectible.name == null || collectible.name == "")
        {
            collectible.name = name;
        }
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
