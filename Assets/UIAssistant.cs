using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAssistant : MonoBehaviour
{
    private Text messageText;
    private TextWriter.TextWriterSingle textWriterSingle;
    private AudioSource talkingAudioSource;

    // This function is called when the script instance is being loaded.
    // It is used to initialize variables and perform any necessary setup.
    private void Awake()
    {
        // Get the messageText object from the scene and assign it to the messageText variable.
        //messageText = transform.Find("message").Find("messageText").GetComponent<TextWriter>();

        // Get the talkingSound object from the scene and assign its audio source to the talkingAudioSource variable.
        talkingAudioSource = transform.Find("talkingSound").GetComponent<AudioSource>();

        // Set a callback function for when the message button is clicked.
        // This function will randomly select a message from an array and display it in the messageText object.
        //transform.Find("message").GetComponent<Button_UI>().ClickFunc = () =>
        {
            // If there is a text writer currently active, stop it and display the full message.
            if (textWriterSingle != null && textWriterSingle.IsActive())
            {
                // Currently active TextWriter, stop it and display the full message.
                textWriterSingle.WriteAllAndDestroy();
            }
            else
            {
                // If there is no text writer currently active, choose a random message and start displaying it.
                string[] messageArray = new string[]
                {
                    "this is amazing!",
                    "I'm having such a great time!",
                };
                string message = messageArray[Random.Range(0, messageArray.Length)];
                // Play the talking sound effect.
                talkingAudioSource.Play();
                // Add a text writer to the messageText object and start displaying the message.
                textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .0f, true, true, StopTalkingSound);
            }
        };
    }

    // This function starts playing the talking sound effect.
    private void StartTalkingSound()
    {
        talkingAudioSource.Play();
    }

    // This function stops playing the talking sound effect.
    private void StopTalkingSound()
    {
        talkingAudioSource.Stop();
    }
}
