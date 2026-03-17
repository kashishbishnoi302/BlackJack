using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class DisplayCards : MonoBehaviour
{
    private List<Sprite> images;

    private Sprite[] allImages; 
    // get cards from Player and Dealer -> then display them

    private int cardIndex = 0;
    public float spacing = 120f;
    public void Display(Card card)
    {
        char suite = card.suite;
        char value = card.value;
        
        string name = suite.ToString() + value.ToString();
        
        // get the specific sprite from allImages using suite and value:
        Sprite sprite = GetSprite(name);
        
        // create image gameobject and attach sprite, position etc to it
        Image img = SpawnImage(sprite, gameObject.transform);
        
    }

    Sprite GetSprite(string name)
    {
        foreach (Sprite sprite in allImages)
        {
            if (sprite.name == name)
            {
                return sprite;
            }
        }

        return null;
    }

    Image SpawnImage(Sprite sprite, Transform transform)
    {
        GameObject imgObj = new GameObject(sprite.name);
        imgObj.transform.SetParent(transform, false); // set image's transform parent as parent's transform-> false -> avoids the world's position
        
        // add image component to the gameobject
        Image img = imgObj.AddComponent<Image>();
        img.sprite = sprite;
        
        RectTransform rect = img.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(cardIndex*spacing, -20);
        cardIndex++;
        img.SetNativeSize(); // image size is sprite ka real size

        return img;
    }
    
    void Start()
    {
        this.allImages = Resources.LoadAll<Sprite>("Sprites/playingCards");
        this.images = new List<Sprite>();
    }

    public void ClearCards()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        cardIndex = 0;
    }
}
