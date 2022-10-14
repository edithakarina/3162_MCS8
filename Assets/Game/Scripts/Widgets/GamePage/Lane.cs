﻿
using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.MusicTheory;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class Lane : MonoBehaviour
{
    [SerializeField] public int _id;
    [SerializeField] private List<string> _noteParseRestrictions;
    [SerializeField] private RectTransform _laneObj;
    //[SerializeField] public Canvas _parentCanvas;
    //[SerializeField] public GameManager manager;
    [SerializeField] private GameObject _parentobj;

    public List<Note> noteRestrictions = new List<Note>();
    public KeyCode input;
    public GameObject notePrefab;
    public List<double> timeStamps = new List<double>();
    public float speed;

    private float _posY;
    private GameObject _note;
    private TextMeshProUGUI _noteName;

    int spawnIndex = 0;
    int inputIndex = 0;

    // Start is called before the first frame update
    void Awake()
    {
        // getting the parent canvas
        //_parentCanvas = (Canvas)GameObject.FindObjectOfType(typeof(Canvas));
        //_parentobj = _parentCanvas.gameObject;

        _posY = _laneObj.transform.position.y;
        foreach (string note in _noteParseRestrictions)
        {
            noteRestrictions.Add(Note.Parse(note));
            //Debug.Log("lane " + _id + ": " + Note.Parse(note).NoteName + " no:" + Note.Parse(note).NoteNumber);
        }

        _note = (GameObject)Operations.GetInstance().LoadPrefabFromFile("Prefabs/Note");
        _noteName = _note.transform.Find("note").GetComponent<TextMeshProUGUI>();
    }

    public bool checkNoteRestriction(Melanchall.DryWetMidi.Interaction.Note note)
    {
        foreach (Note currNote in noteRestrictions)
        {
            if (currNote.NoteNumber == note.NoteNumber)
            {
                return true;
            }
        }
        return false;
    }

    public GameObject InstantiateObj(string noteName, string noteOctave, SevenBitNumber noteNumber, float speed, int index, float time, Vector3 distance){
        // instantiate the note object here
        // in the note object's update, we will update the speed according
        // to the tempo
        //Debug.Log("instantiate note: " + noteName + " midiNo: " + noteNumber);
        _noteName.text = noteName + noteOctave;
        GameObject child = Instantiate(_note);
        child.transform.SetParent(_parentobj.transform);
        child.transform.localPosition = new Vector3(-1607, transform.localPosition.y, 0) + distance;
        child.transform.localScale = new Vector3(1, 1, 1);
        child.GetComponent<SingleNote>().speed = speed;
        child.GetComponent<SingleNote>().index = index;
        //child.GetComponent<SingleNote>().manager = manager;
        return child;
        //manager.InstantiatedNotes.Add(child);
    }

    //public void InstantiateObjsDistance(NoteInfo info, float speed, int index, Vector3 distance)
    //{
    //    // instantiate the note object here
    //    // in the note object's update, we will update the speed according
    //    // to the tempo
    //    Debug.Log("instantiate note: " + info.NoteName + " midiNo: " + info.NoteNumber);
    //    Debug.Log("instantiate other note: " + info.Data.getNoteNumber());
    //    Melanchall.DryWetMidi.Interaction.Note expectedNote = new Melanchall.DryWetMidi.Interaction.Note(info.NoteNumber);
    //    _noteName.text = info.NoteName + expectedNote.Octave;

    //    GameObject child = Instantiate(_note);
    //    child.transform.SetParent(_parentobj.transform);
    //    child.transform.localPosition = new Vector3(-1607, transform.localPosition.y, 0);
    //    child.transform.localScale = new Vector3(1, 1, 1);
    //    child.GetComponent<SingleNote>().speed = speed;
    //    child.GetComponent<SingleNote>().index = index;
    //    child.GetComponent<SingleNote>().manager = manager;
    //    manager.InstantiatedNotes.Add(child);

    //    // instantiate the other note
    //    expectedNote = new Melanchall.DryWetMidi.Interaction.Note((SevenBitNumber)info.Data.getNoteNumber());
    //    _noteName.text = info.NoteName + expectedNote.Octave;
    //    GameObject child2 = Instantiate(_note);
    //    child.transform.SetParent(_parentobj.transform);
    //    child.transform.localPosition = new Vector3(-1607, transform.localPosition.y, 0) + distance;
    //    child.transform.localScale = new Vector3(1, 1, 1);
    //    child.GetComponent<SingleNote>().speed = speed;
    //    child.GetComponent<SingleNote>().index = index;
    //    child.GetComponent<SingleNote>().manager = manager;
    //    manager.InstantiatedNotes.Add(child2);
    //}

    //public static UnityEngine.Object LoadPrefabFromFile(string filename)
    //{
    //    Debug.Log("Trying to load LevelPrefab from file (" + filename + ")...");
    //    var loadedObject = Resources.Load("Materials/Prefabs/" + filename);
    //    if (loadedObject == null)
    //    {
    //        throw new FileNotFoundException("...no file found - please check the configuration");
    //    }
    //    return loadedObject;
    //}

    //public void SetTimeStamps(Melanchall.DryWetMidi.Interaction.Note[] array)
    //{
    //    foreach (var note in array)
    //    {
    //        if (note.NoteName == noteRestriction)
    //        {
    //            var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, GameManager.Midi.GetTempoMap());
    //            timeStamps.Add((double)metricTimeSpan.Minutes * 60f + metricTimeSpan.Seconds + (double)metricTimeSpan.Milliseconds / 1000f);
    //        }
    //    }
    //}
    //// Update is called once per frame
    //void Update()
    //{
    //    if (spawnIndex < timeStamps.Count)
    //    {
    //        if (SongManager.GetAudioSourceTime() >= timeStamps[spawnIndex] - SongManager.Instance.noteTime)
    //        {
    //            var note = Instantiate(notePrefab, transform);
    //            notes.Add(note.GetComponent<Note>());
    //            note.GetComponent<Note>().assignedTime = (float)timeStamps[spawnIndex];
    //            spawnIndex++;
    //        }
    //    }

    //    if (inputIndex < timeStamps.Count)
    //    {
    //        double timeStamp = timeStamps[inputIndex];
    //        double marginOfError = SongManager.Instance.marginOfError;
    //        double audioTime = SongManager.GetAudioSourceTime() - (SongManager.Instance.inputDelayInMilliseconds / 1000.0);
    // have 1 observer class and make all the lanes subsribe to it. if a sound is heard, it will distribute the result to all the strings
    // if a m
    //        if (Input.GetKeyDown(input))
    //        {
    //            if (Math.Abs(audioTime - timeStamp) < marginOfError)
    //            {
    //                Hit();
    //                print($"Hit on {inputIndex} note");
    //                Destroy(notes[inputIndex].gameObject);
    //                inputIndex++;
    //            }
    //            else
    //            {
    //                print($"Hit inaccurate on {inputIndex} note with {Math.Abs(audioTime - timeStamp)} delay");
    //            }
    //        }
    //        if (timeStamp + marginOfError <= audioTime)
    //        {
    //            Miss();
    //            print($"Missed {inputIndex} note");
    //            inputIndex++;
    //        }
    //    }       

    //}
    //private void Hit()
    //{
    //    ScoreManager.Hit();
    //}
    //private void Miss()
    //{
    //    ScoreManager.Miss();
    //}
}
