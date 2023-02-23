using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;


    public static GameAssets i
    {
        get
        {
            // If the instance does not exist, it is instantiated from the "GameAssets" resource and stored in _i.
            if (_i == null) _i = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssets>();
            return _i;
        }
    }
    // This variable holds a reference to the prefab for the chat bubble.
    public Transform pfChatBubble;
}
