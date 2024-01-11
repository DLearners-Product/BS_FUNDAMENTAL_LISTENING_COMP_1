using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;




public class Thumbnail3 : MonoBehaviour
{

    public List<GameObject> gameObjectsList1 = new List<GameObject>();
    public List<GameObject> gameObjectsList2 = new List<GameObject>();
    public GameObject reset11to20;
    public GameObject enableThis;
    public Button resetButton;
    public GameObject set1;
    public GameObject set2;
    public GameObject activityCompleted;
    public TextMeshProUGUI counter;

    
   


    #region QA
    private int qIndex;
    private int q1Index;
    public GameObject questionGO;
    public GameObject[] optionsGO;
    public bool isActivityCompleted = false;
    public Dictionary<string, Component> additionalFields;
    Component question;
    Component[] options;
    Component[] answers;
    #endregion

    private int interactableButtonsLeft = 0;

    private void Start()
    {
        #region DataSetter
        Main_Blended.OBJ_main_blended.levelno =3;
        QAManager.instance.UpdateActivityQuestion();
        qIndex = 0;
        q1Index = 0;
        GetData(qIndex);
        GetAdditionalData();
        AssignData();
        #endregion
        set1.SetActive(true);
        interactableButtonsLeft = gameObjectsList1.Count; // Initialize the count
        Button reset11to20Button = reset11to20.GetComponent<Button>();
        if (reset11to20Button != null)
        {
            reset11to20Button.onClick.AddListener(Reset11to20);
        }

        // Loop through the list and set up button clicks
        foreach (GameObject obj in gameObjectsList1)
        {
            Button button = obj.GetComponent<Button>();
            if (button != null)
            {
                button.onClick.AddListener(() => ToggleChild(obj));
            }
        }

        resetButton.onClick.AddListener(ResetAll); // Setup the reset button click listener

        // Initially disable the enableThis GameObject
        //  enableThis.SetActive(false);
    }

    private void ToggleChild(GameObject obj)
    {
        Transform secondChild = obj.transform.GetChild(1);
        if (secondChild != null)
        {
            secondChild.gameObject.SetActive(!secondChild.gameObject.activeSelf);
           
            Button button = obj.GetComponent<Button>();
            if (button != null)
            {
                button.interactable = !secondChild.gameObject.activeSelf;
                if (!button.interactable)
                {
                    interactableButtonsLeft--;
                    if (interactableButtonsLeft == 10)
                    {
                        Debug.Log("Interactable buttons left: " + interactableButtonsLeft);
                        enableThis.SetActive(true); // Enable the target object when all interactable buttons are inactive

                    }
                    if (interactableButtonsLeft == 0)
                    {
                        reset11to20.GetComponent<Button>().interactable = false;
                        StartCoroutine(activityCompletedDelay());
                    }
                }
            }

                  int currentCounterValue = int.Parse(counter.text);
                  currentCounterValue++;
                  counter.text = currentCounterValue.ToString();

            Debug.Log("Interactable buttons left: " + interactableButtonsLeft);

        }
    }

    public void ResetAll()
    {
        counter.text = "0";
        foreach (GameObject obj in gameObjectsList1)
        {
            Transform secondChild = obj.transform.GetChild(1);
            if (secondChild != null)
            {
                secondChild.gameObject.SetActive(false);
                Button button = obj.GetComponent<Button>();
                if (button != null)
                {
                   
                    button.interactable = true;
                    set1.SetActive(false);
                    set1.SetActive(true);
                    interactableButtonsLeft = gameObjectsList1.Count; // Reset the interactable count
                }
            }
        }

        enableThis.SetActive(false);
    }

    public void Reset11to20()
    {
         counter.text = "10";
        // Loop through the gameObjectsList1 from index 10 to 19 (for objects 11 to 20)
        for (int i = 10; i < 20 && i < gameObjectsList1.Count; i++)
        {
            GameObject obj = gameObjectsList1[i];
            Transform secondChild = obj.transform.GetChild(1);
            if (secondChild != null)
            {
                secondChild.gameObject.SetActive(false);
                Button button = obj.GetComponent<Button>();
                if (button != null)
                {
                    button.interactable = true;
                }
            }
        }

        // Reset other relevant variables as needed
      
        set2.SetActive(false);
        set2.SetActive(true);

        // Reset the interactableButtonsLeft count to start from 10
        interactableButtonsLeft = gameObjectsList1.Count - 10;

        enableThis.SetActive(false);
    }

    public void LoadNextSet()
    {
        set1.SetActive(false);
        set2.SetActive(true);
    }
    IEnumerator activityCompletedDelay()
    {
        yield return new WaitForSeconds(1);
        activityCompleted.SetActive(true);
    }

    #region QA

    int GetOptionID(string selectedOption)
    {
        for (int i = 0; i < options.Length; i++)
        {
            if (options[i].text == selectedOption)
            {
                Debug.Log(selectedOption);
                return options[i].id;
            }
        }
        return -1;
    }

    bool CheckOptionIsAns(Component option)
    {
        for (int i = 0; i < answers.Length; i++)
        {
            if (option.text == answers[i].text) { return true; }
        }
        return false;
    }

    void GetData(int questionIndex)
    {
        Debug.Log(qIndex);
        question = QAManager.instance.GetQuestionAt(0, qIndex);
        // if(question != null){
        options = QAManager.instance.GetOption(0, questionIndex);
        answers = QAManager.instance.GetAnswer(0, questionIndex);
        // }
    }

    void GetAdditionalData()
    {
        additionalFields = QAManager.instance.GetAdditionalField(0);
    }

    void AssignData()
    {
        // Custom code
        for (int i = 0; i < optionsGO.Length; i++)
        {
            optionsGO[i].GetComponent<Image>().sprite = options[i]._sprite;
            optionsGO[i].tag = "Untagged";
            Debug.Log(optionsGO[i].name, optionsGO[i]);
            if (CheckOptionIsAns(options[i]))
            {
                optionsGO[i].tag = "answer";
            }
        }
        // answerCount.text = "/"+answers.Length;
    }

    #endregion

}

