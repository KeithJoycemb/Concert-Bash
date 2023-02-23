using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    // Declare a private static instance of the TextWriter class and a list of TextWriterSingle objects
    private static TextWriter instance;
    private List<TextWriterSingle> textWriterSingleList;

    // The Awake function is called when the script instance is being loaded
    public void Awake()
    {
        // Set the instance variable to reference this TextWriter object and create an empty list of TextWriterSingle objects
        instance = this;
        textWriterSingleList = new List<TextWriterSingle>();
    }

    // AddWriter_Static is a public static method that can be called from other scripts to add a new TextWriterSingle object to the textWriterSingleList
    // This method returns a TextWriterSingle object which can be used to monitor the progress of the text being written to the UI text element
    public static TextWriterSingle AddWriter_Static(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters, bool removeWriterBeforeAdd, Action onComplete)
    {
        // If the removeWriterBeforeAdd parameter is true, remove any existing TextWriterSingle object that is writing to the same UI text element
        if (removeWriterBeforeAdd)
        {
            instance.RemoveWriter(uiText);
        }
        // Create a new TextWriterSingle object and add it to the textWriterSingleList
        return instance.AddWriter(uiText, textToWrite, timePerCharacter, invisibleCharacters, onComplete);
    }

    // AddWriter is a private method that adds a new TextWriterSingle object to the textWriterSingleList
    private TextWriterSingle AddWriter(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters, Action onComplete)
    {
        // Create a new TextWriterSingle object and add it to the textWriterSingleList
        TextWriterSingle textWriterSingle = new TextWriterSingle(uiText, textToWrite, timePerCharacter, invisibleCharacters, onComplete);
        textWriterSingleList.Add(textWriterSingle);
        return textWriterSingle;
    }

    // RemoveWriter_Static is a public static method that can be called from other scripts to remove a TextWriterSingle object from the textWriterSingleList
    public static void RemoveWriter_Static(Text uiText)
    {
        // Remove the TextWriterSingle object from the textWriterSingleList that is writing to the specified UI text element
        instance.RemoveWriter(uiText);
    }

    // RemoveWriter is a private method that removes a TextWriterSingle object from the textWriterSingleList
    private void RemoveWriter(Text uiText)
    {
        // Iterate through the textWriterSingleList and remove any TextWriterSingle object that is writing to the specified UI text element
        for (int i = 0; i < textWriterSingleList.Count; i++)
        {
            if (textWriterSingleList[i].GetUIText() == uiText)
            {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }

    // The Update function is called every frame
    private void Update()
    {
        // Iterate through the textWriterSingleList and update each TextWriterSingle object
        for (int i = 0; i < textWriterSingleList.Count; i++)
        {
            bool destroyInstance = textWriterSingleList[i].Update();
            // If a TextWriterSingle object has finished writing its text, remove it from the textWriterSingleList
            if (destroyInstance)
            {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }

    // The TextWriterSingle class represents a single instance of text being written to a UI text element
    public class TextWriterSingle
    {
        private Text uiText; // The UI Text component that will display the text.
        private string textToWrite; // The full text that will be displayed.
        private int characterIndex; // The current index of the character being displayed.
        private float timePerCharacter; // The time in seconds it takes to display a single character.
        private float timer; // The timer that keeps track of how much time has passed since the last character was displayed.
        private bool invisibleCharacters; // Whether or not to hide the remaining characters that haven't been displayed yet.
        private Action onComplete; // A callback function that will be called when the entire string has been displayed.

        public TextWriterSingle(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters, Action onComplete)
        {
            // Constructor for creating a new TextWriterSingle instance.
            this.uiText = uiText;
            this.textToWrite = textToWrite;
            this.timePerCharacter = timePerCharacter;
            this.invisibleCharacters = invisibleCharacters;
            this.onComplete = onComplete;
            characterIndex = 0; // Initialize the characterIndex to 0.
        }

        public bool Update()
        {
            // Update function that will display the next character in the text string.
            timer -= Time.deltaTime; // Decrease the timer by the amount of time that has passed since the last frame.
            while (timer <= 0f) // Keep looping as long as there is time remaining.
            {
                // Display the next character.
                timer += timePerCharacter; // Reset the timer to the timePerCharacter.
                characterIndex++; // Move to the next character index.
                string text = textToWrite.Substring(0, characterIndex); // Get the text up to the current character index.
                if (invisibleCharacters) // If invisibleCharacters is true, hide the remaining characters.
                {
                    text += "<color=#00000000>" + textToWrite.Substring(characterIndex) + "</color>";
                }
                uiText.text = text; // Set the UI Text component to display the current text.

                if (characterIndex >= textToWrite.Length) // If the entire string has been displayed, call the onComplete callback.
                {
                    if (onComplete != null) onComplete();
                    return true; // Return true to indicate that the entire string has been displayed.
                }
            }
            return false; // Return false to indicate that the string is still being displayed.
        }

        public Text GetUIText()
        {
            // Getter function for the uiText variable.
            return uiText;
        }

        public bool IsActive()
        {
            // Returns true if there are still characters in the text string that haven't been displayed yet.
            return characterIndex < textToWrite.Length;
        }

        public void WriteAllAndDestroy()
        {
            // Immediately display the entire string and call the onComplete callback.
            uiText.text = textToWrite;
            characterIndex = textToWrite.Length;
            if (onComplete != null) onComplete();
            TextWriter.RemoveWriter_Static(uiText); // Remove this instance from the TextWriter static list.
        }
    }

}
