using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Title :MonoBehaviour, FlashcardInterface
{
    //[SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private GameObject flashcardObject;
    [SerializeField] private TextMeshProUGUI titleObj;

    public GameObject instantiatedObjFunctionality(GameObject flashcardObject, Dictionary<string, object> flashcard)
    {
        return null;
    }

    //public Title() { 
    //    flashcardObject = (GameObject)FlashcardManager.LoadPrefabFromFile("FlashcardTitle");
    //    titleObj = flashcardObject.transform.Find("Title").GetComponent<TextMeshProUGUI>();
    //}

    public GameObject setAllData(Dictionary<string, object> flashcard, string title, string subheading, int no)
    {
        //_title.text = Convert.ToString(flashcard["Content"]);

        //instantiate the game object here to the scene
        
        //Debug.Log("reached here");
        //Debug.Log(flashcardObject);
        //TextMeshProUGUI titleObj = flashcardObject.transform.Find("Title").GetComponent<TextMeshProUGUI>();
        titleObj.text = Convert.ToString(flashcard["Content"]);
        //Debug.Log("finished here");
        return flashcardObject;
    }
}
