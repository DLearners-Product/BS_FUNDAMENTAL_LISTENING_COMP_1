    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Thumbnail6 : MonoBehaviour
{
    public GameObject[] questions;
    public GameObject Speaker;
    public Sprite playSprite; // The play sprite
    public Sprite pauseSprite; // The pause sprite
    public AudioClip rhyme;
    
    
    public GameObject[] dots;

    public AudioSource source;
    public AudioSource sources;
    public Animator speakerAnimation;
    public AudioClip[] clips;

    private bool isPlayingAudio = false;
    private bool isPlayingSources = false;
    private float originalSourceVolume;
    private int currentQuestionIndex = 0;

    public GameObject activityCompleted;
    private Image speakerImage; // Reference to the Image component on the UI GameObject
    private int currentDotIndex = -1; // Initialize to -1 to indicate no dot active

    private void Start()
    {
        source = Speaker.GetComponent<AudioSource>();
        source.clip = rhyme;
        originalSourceVolume = source.volume;
        speakerImage = Speaker.GetComponent<Image>(); // Get the Image component
    }

    private void Update()
    {
        if (isPlayingAudio && !source.isPlaying)
        {
            // Audio has finished playing, trigger animation here
            speakerAnimation.SetTrigger("Move");
            isPlayingAudio = false; // Reset the flag

            StartCoroutine(QuestionDelay());
        }

        if (isPlayingSources && !sources.isPlaying)
        {
            // Audio has finished playing, restore the source volume
            source.volume = originalSourceVolume;
            isPlayingSources = false; // Reset the flag
        }
    }

    public void PlayAudioAndAnimate()
    {
        if (source.isPlaying)
        {
            // If the audio is currently playing, pause it and change the speaker sprite to pause
            source.Pause();
            speakerImage.sprite = pauseSprite;
        }
        else
        {
            // If the audio is not playing, play it and change the speaker sprite to play
            source.Play();
            speakerImage.sprite = playSprite;
        }
        isPlayingAudio = !isPlayingAudio; // Toggle the audio playing state
    }

    IEnumerator QuestionDelay()
    {
        yield return new WaitForSeconds(1f);
        // Display the current question
        if (currentQuestionIndex < questions.Length)
        {
            questions[currentQuestionIndex].SetActive(true);

            // Activate the corresponding dot and deactivate the previous dot
            if (currentDotIndex >= 0 && currentDotIndex < dots.Length)
            {
                dots[currentDotIndex].SetActive(false);
            }

            if (currentQuestionIndex < dots.Length)
            {
                dots[currentQuestionIndex].SetActive(true);
                currentDotIndex = currentQuestionIndex;
            }
        }
    }

    public void PlayVO(AudioClip clip)
    {
        sources.clip = clip;
        sources.Play();

        // Reduce the volume of source audio while sources audio is playing
        originalSourceVolume = source.volume;
        source.volume = 0.25f;

        isPlayingSources = true; // Set flag for handling sources audio
    }

    public void OptionClicked(bool isCorrect)
    {
        // Log if the answer is wrong
        if (!isCorrect)
        {
            Debug.Log("Answer is wrong.");
            return; // Don't proceed to the next question
        }

        // Disable the button
        Button clickedButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        if (clickedButton != null)
        {
            clickedButton.interactable = false;
        }

        StartCoroutine(questionDelay());
    }

    IEnumerator questionDelay()
    {
        yield return new WaitForSeconds(2f);
        // Move to the next question
        currentQuestionIndex++;
      
        // Hide the current question
        if (currentQuestionIndex - 1 < questions.Length)
        {
            questions[currentQuestionIndex - 1].SetActive(false);
        }

        // Display the next question
        if (currentQuestionIndex < questions.Length)
        {
            questions[currentQuestionIndex].SetActive(true);

            // Activate the corresponding dot and deactivate the previous dot
            if (currentDotIndex >= 0 && currentDotIndex < dots.Length)
            {
                dots[currentDotIndex].SetActive(false);
            }

            if (currentQuestionIndex < dots.Length)
            {
                dots[currentQuestionIndex].SetActive(true);
                currentDotIndex = currentQuestionIndex;
            }
        }
        else
        {
            Debug.Log("All questions have been answered.");
            activityCompleted.SetActive(true);
        }
    }
}
