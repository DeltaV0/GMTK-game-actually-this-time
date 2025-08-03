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

    public bool Equals(Collectible c)
    {
        Debug.Log(collectibleImage.ToString() + (collectibleImage.Equals(c.collectibleImage) ? " is equal to " : " is not equal to ") + c.collectibleImage.ToString());
        Debug.Log(name.ToString() + (name.Equals(c.name) ? " is equal to " : " is not equal to ") + c.name.ToString());
        Debug.Log(color.ToString() + (color.Equals(c.color) ? " is equal to " : " is not equal to ") + c.color.ToString());
        return collectibleImage.Equals(c.collectibleImage) && name.Equals(c.name) && color.Equals(c.color);
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
