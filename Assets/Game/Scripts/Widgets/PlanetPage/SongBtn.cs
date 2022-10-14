using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SongBtn : MonoBehaviour
{
    [SerializeField] Button thisBtn;
    [SerializeField] Song song;
    [SerializeField] TextMeshProUGUI titleText;
    [SerializeField] List<GameObject> activeStars;
    [SerializeField] List<GameObject> deactiveStars;

    private string songId, title, wavLocation, midiLocation;
    private int difficulty;

    public string SongId { get => songId; set => songId = value; }
    public string Title { get => title; set => title = value; }
    public string WavLocation { get => wavLocation; set => wavLocation = value; }
    public string MidiLocation { get => midiLocation; set => midiLocation = value; }
    public int Difficulty { get => difficulty; set => difficulty = value; }

    // Start is called before the first frame update
    void Start()
    {
        thisBtn.onClick.AddListener(GoToGamePage);
    }

    public void SetUI()
    {
        titleText.text = title;
        for(int i = 0; i < difficulty; i++)
        {
            activeStars[i].SetActive(true);
            deactiveStars[i].SetActive(false);
        }


    }

    public void toggle(bool quizPass)
    {
        if (quizPass)
        {
            thisBtn.interactable = true;
        }
        else
        {
            thisBtn.interactable = false;
        }
    }

    private void GoToGamePage()
    {
        song.Title = title;
        song.MidiLocation = midiLocation;
        song.SongId = songId;
        song.WavLocation = wavLocation;
        Debug.Log("Song title: " + title + " midilocation: " + midiLocation);
        SceneManager.LoadScene("GamePage");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
