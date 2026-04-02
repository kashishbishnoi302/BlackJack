using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

// Shows card images in a row. Loads sprites from Resources by name (suit + rank, e.g. H10).
public class DisplayCards : MonoBehaviour
{
    private List<Sprite> images;

    private List<Sprite> allImages;

    private int cardIndex = 0;
    public float spacing = 120f;

    private Image lastSpawnedImage;
    private Image holeImage;
    private Sprite holeFaceSprite;

    public void Display(Card card)
    {
        // Picture name = suit letter + rank (not the blackjack point value).
        string cardKey = card.suite.ToString() + card.rank;
        Sprite sprite = GetSprite(cardKey);

        Image img = SpawnImage(sprite, gameObject.transform, cardKey);
        lastSpawnedImage = img;
    }

    // After dealing the dealer’s hidden card, swap its picture to the “hidden” back until we reveal it.
    public void CoverHoleCardWithHidden()
    {
        if (lastSpawnedImage == null)
            return;

        Sprite hidden = FindHiddenSprite();
        if (hidden == null)
        {
            Debug.LogError("DisplayCards: could not load sprite 'hidden' from Resources (try Resources/playingCards or Resources/Sprites/playingCards).");
            return;
        }

        holeImage = lastSpawnedImage;
        holeFaceSprite = holeImage.sprite;
        holeImage.sprite = hidden;
    }

    // Turn the hole card back to the real face sprite.
    public void RevealHoleCard()
    {
        if (holeImage == null || holeFaceSprite == null)
            return;

        holeImage.sprite = holeFaceSprite;
        holeImage.SetNativeSize();
        holeImage.gameObject.name = holeFaceSprite.name;

        holeImage = null;
        holeFaceSprite = null;
    }

    private Sprite FindHiddenSprite()
    {
        foreach (var s in Resources.LoadAll<Sprite>("playingCards"))
        {
            if (s.name == "hidden")
                return s;
        }
        foreach (var s in Resources.LoadAll<Sprite>("Sprites/playingCards"))
        {
            if (s.name == "hidden")
                return s;
        }
        return null;
    }

    void EnsureSpritesLoaded()
    {
        if (allImages != null && allImages.Count > 0)
            return;

        allImages = new List<Sprite>();
        foreach (var s in Resources.LoadAll<Sprite>("Sprites/playingCards"))
            allImages.Add(s);
        
    }

    Sprite GetSprite(string name)
    {
        EnsureSpritesLoaded();

        foreach (Sprite sprite in allImages)
        {
            if (sprite.name == name)
            {
                return sprite;
            }
        }

        return null;
    }

    Image SpawnImage(Sprite sprite, Transform transform, string cardKey)
    {
        GameObject imgObj = new GameObject(cardKey);
        imgObj.transform.SetParent(transform, false);

        Image img = imgObj.AddComponent<Image>();
        img.sprite = sprite;
        if (sprite == null)
            Debug.LogWarning("DisplayCards: missing sprite for card image.");

        RectTransform rect = img.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(cardIndex * spacing, -20);
        cardIndex++;
        img.SetNativeSize();

        return img;
    }

    void Start()
    {
        EnsureSpritesLoaded();
        this.images = new List<Sprite>();
    }

    public void ClearCards()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        cardIndex = 0;
        lastSpawnedImage = null;
        holeImage = null;
        holeFaceSprite = null;
    }
}
