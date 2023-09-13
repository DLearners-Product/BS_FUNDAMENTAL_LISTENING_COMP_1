using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ColourGame : MonoBehaviour
{
    [System.Serializable]
    public class ButtonSet
    {
        public Button button1;
        public Button button2;
        public GameObject objectToActivate;
        public AudioClip questionAudio;
        public AudioSource source;
        public Button[] unwantedButtons;
    }

    public List<ButtonSet> buttonSets = new List<ButtonSet>();

    private List<ButtonSet> remainingQuestions;
    private int currentQuestionIndex = 0;
    public GameObject RiverBed;
    public GameObject Moutain;
    public Button ReplaytheQuestion;
    public AudioClip clap;
    public AudioSource sources;
    public ParticleSystem confette;
    public AudioSource ohohSource;
    public AudioClip ohoh;

    public GameObject activityCompleted;
    private bool firstSetButtonClicked = false;
    private bool firstSetWithMatchButtonClicked = false;

    private void Start()
    {
        remainingQuestions = buttonSets.ToList();
      //  ReplaytheQuestion.onClick.AddListener(ReplayQuestionAudio);
        ShowRandomQuestion();
    }

    private void ShowRandomQuestion()
    {
        if (remainingQuestions.Count > 0)
        {
            // Reset all button1 elements to be interactable
            foreach (var buttonSet in buttonSets)
            {
                buttonSet.button1.interactable = true;
            }

            currentQuestionIndex = Random.Range(0, remainingQuestions.Count);
            ButtonSet currentQuestion = remainingQuestions[currentQuestionIndex];
            currentQuestion.source.clip = currentQuestion.questionAudio;
         //   currentQuestion.source.Play();

            // Deactivate unwanted buttons
            foreach (Button unwantedButton in currentQuestion.unwantedButtons)
            {
               // unwantedButton.gameObject.SetActive(false);
                unwantedButton.onClick.AddListener(() => LogUnwantedButtonClick(unwantedButton));
            }

            currentQuestion.button1.onClick.RemoveAllListeners();
            currentQuestion.button1.onClick.AddListener(() => OnClickButton1(currentQuestion));

            currentQuestion.button2.onClick.RemoveAllListeners();
            currentQuestion.button2.onClick.AddListener(() => OnClickButton2(currentQuestion));
        }
        else
        {
            Debug.Log("All questions answered!");
            StartCoroutine(FinalReveal());
        }
    }

    private void OnClickButton1(ButtonSet buttonSet)
    {
        if (buttonSet == remainingQuestions[currentQuestionIndex]) // Check if it's the correct button1
        {
            buttonSet.button1.interactable = false;
            buttonSet.button2.interactable = true;
            Debug.Log("You chose the correct color: " + buttonSet.button1.name); // Print the matching button's name
        }
    }

    private void OnClickButton2(ButtonSet buttonSet)
    {
        if (buttonSet.button1.interactable)
        {
            Debug.Log("You chose the wrong color: " + buttonSet.button1.name);
            return;
        }

        if (buttonSet.button2 != null)
        {
            // Debug.Log("You chose the wrong color");
            buttonSet.objectToActivate.SetActive(true);
            buttonSet.button2.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("You chose the wrong button: " + buttonSet.button1.name);
        }

        // Reset button states
        buttonSet.button1.interactable = true;
        buttonSet.button2.interactable = false;

        remainingQuestions.RemoveAt(currentQuestionIndex);
        ShowRandomQuestion();
    }

    // private void ReplayQuestionAudio()
    // {
    //     if (currentQuestionIndex >= 0 && currentQuestionIndex < buttonSets.Count)
    //     {
    //         ButtonSet currentQuestion = buttonSets[currentQuestionIndex];
    //         currentQuestion.source.Play();
    //     }
    // }

    IEnumerator FinalReveal()
    {
        yield return new WaitForSeconds(1.5f);
        RiverBed.SetActive(true);
        yield return new WaitForSeconds(1f);
        Moutain.SetActive(true);
        sources.clip = clap;
        sources.Play();
        confette.Play();
        StartCoroutine(ActivityCompDelay());
    }

    IEnumerator ActivityCompDelay()
    {
        yield return new WaitForSeconds(1f);
        activityCompleted.SetActive(true);
    }
    public void PlayCurrentQuestionAudio()
{
    // This method will be called when you want to play the current question's audio
    if (currentQuestionIndex >= 0 && currentQuestionIndex < buttonSets.Count)
    {
        ButtonSet currentQuestion = buttonSets[currentQuestionIndex];
        currentQuestion.source.Play();
    }
}

    private void LogUnwantedButtonClick(Button unwantedButton)
    {
           ohohSource.clip = ohoh;
        ohohSource.Play();
        Debug.Log("ohoh " + unwantedButton.name);
    }
}
