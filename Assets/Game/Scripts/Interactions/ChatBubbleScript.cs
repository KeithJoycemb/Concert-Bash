using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatBubbleScript : MonoBehaviour
{
    public static void Create(Transform parent, Vector3 localPosition, IconType iconType, string text)
    {
        // Instantiate a new chat bubble prefab
        Transform chatBubbleTransform = Instantiate(GameAssets.i.pfChatBubble, parent);
        // Set the position of chat bubble
        chatBubbleTransform.localPosition = localPosition;
        // Setup the chat bubble
        chatBubbleTransform.GetComponent<ChatBubble>().Setup(iconType, text);
        // Destroy the chat bubble after 4 seconds
        Destroy(chatBubbleTransform.gameObject, 4f);
    }
    // Define an enum to store different icon types
    public enum IconType
    {
        Happy,
        Neutral,
        Angry,
    }

    // Serialized fields to store icon sprites
    [SerializeField] private Sprite happyIconSprite;
    [SerializeField] private Sprite neutralIconSprite;
    [SerializeField] private Sprite angryIconSprite;

    // References to components
    private SpriteRenderer backgroundSpriteRenderer;
    private SpriteRenderer iconSpriteRenderer;
    private TextMeshPro textMeshPro;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Find references to components by name
        backgroundSpriteRenderer = transform.Find("Background").GetComponent<SpriteRenderer>();
        iconSpriteRenderer = transform.Find("Icon").GetComponent<SpriteRenderer>();
        textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        // Setup the chat bubble with default values
        Setup(IconType.Angry, "WOW, this is amazing! The Lights, the music the atmosphere. I'm having such a great time!");
    }

    // Setup method to setup chat bubble with given values
    private void Setup(IconType iconType, string text)
    {
        // Set the text of chat bubble
        textMeshPro.SetText(text);
        // Update the text mesh
        textMeshPro.ForceMeshUpdate();
        // Get the size of text
        Vector2 textSize = textMeshPro.GetRenderedValues(false);

        // Set padding of background
        Vector2 padding = new Vector2(7f, 2f);
        // Set size of background
        backgroundSpriteRenderer.size = textSize + padding;

        // Set offset of background
        Vector2 offset = new Vector2(-2f, 0f);
        // Set position of background
        backgroundSpriteRenderer.transform.localPosition = new Vector3(backgroundSpriteRenderer.size.x / 2f, 0f);

        // Get the icon sprite based on the icon type
        iconSpriteRenderer.sprite = GetIconSprite(iconType);

        // Add text writer to text mesh to animate text
        TextWriter.AddWriter_Static(textMeshPro, text, .0f, true, true, () => { });
    }

    // Get icon sprite based on the icon type
    private Sprite GetIconSprite(IconType iconType)
    {
        switch (iconType)
        {
            default:
            case IconType.Happy: return happyIconSprite;
            case IconType.Neutral: return neutralIconSprite;
            case IconType.Angry: return angryIconSprite;
        }
    }
}
