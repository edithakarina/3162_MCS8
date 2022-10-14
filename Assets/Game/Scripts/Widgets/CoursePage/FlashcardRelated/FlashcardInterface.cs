using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public interface FlashcardInterface
{
    GameObject setAllData(Dictionary<string, object> flashcard, string title, string subheading, int no);
    GameObject instantiatedObjFunctionality(GameObject flashcardObject, Dictionary<string, object> flashcard);
}
