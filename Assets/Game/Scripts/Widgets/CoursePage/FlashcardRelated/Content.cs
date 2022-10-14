using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Content : MonoBehaviour, FlashcardInterface
{

    [SerializeField] private GameObject flashcardObject;
    [SerializeField] private TextMeshProUGUI titleObj, subheadingObj, pageNoObj, contentObj;

    public GameObject instantiatedObjFunctionality(GameObject flashcardObject, Dictionary<string, object> flashcard)
    {
        return null;
    }

    //public Content()
    //{
    //    flashcardObject = (GameObject)FlashcardManager.LoadPrefabFromFile("FlashcardContent");
    //    titleObj = flashcardObject.transform.Find("Title").GetComponent<TextMeshProUGUI>();
    //    subheadingObj = flashcardObject.transform.Find("Subheading").GetComponent<TextMeshProUGUI>();
    //    pageNoObj = flashcardObject.transform.Find("Circle").transform.Find("Number").GetComponent<TextMeshProUGUI>();
    //    contentObj = flashcardObject.transform.Find("Content").GetComponent<TextMeshProUGUI>();
    //}

    public GameObject setAllData(Dictionary<string, object> flashcard, string title, string subheading, int no)
    {
        //_title.text = Convert.ToString(flashcard["Content"]);

        //GameObject parent = flashcardObject.transform.Find("FlashcardBasic").gameObject;
        //Debug.Log(parent);

        GameObject parent = flashcardObject;
        Debug.Log(parent);

        //TextMeshProUGUI titleObj = flashcardObject.transform.Find("Title").GetComponent<TextMeshProUGUI>();
        titleObj.text = title;
        Debug.Log(titleObj);

        //TextMeshProUGUI titleObj = flashcardObject.transform.Find("FlashcardBasic").transform.Find("Title").GetComponent<TextMeshProUGUI>();
        //titleObj.text = title;

        //TextMeshProUGUI subheadingObj = flashcardObject.transform.Find("Subheading").GetComponent<TextMeshProUGUI>();
        subheadingObj.text = subheading;

        //TextMeshProUGUI pageNoObj = flashcardObject.transform.Find("Circle").transform.Find("Number").GetComponent<TextMeshProUGUI>();
        pageNoObj.text = no.ToString();

        //TextMeshProUGUI contentObj = flashcardObject.transform.Find("Content").GetComponent<TextMeshProUGUI>();
        contentObj.text = Convert.ToString(flashcard["Content"]);

        return flashcardObject;
    }
}
