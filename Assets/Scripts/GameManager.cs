using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] GameObject nameField;
    [SerializeField] GameObject afterNameEntered;
    [SerializeField] Text enteredNameText;
    [SerializeField] Text thanksText;

    public string enteredName;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);        
    }

  public void OnNameEntered()
    {
        enteredName = enteredNameText.text;
        nameField.SetActive(false);
        afterNameEntered.SetActive(true);
        thanksText.text = "Thank you, " + enteredName + "! Lets play?";
    }

  public void GameStart()
    {
        SceneManager.LoadScene(1);
    }
}
