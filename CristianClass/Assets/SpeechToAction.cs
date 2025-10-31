using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechToAction : MonoBehaviour
{

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> keywordActions = new Dictionary<string, Action>();
    [SerializeField] private string[] keywords;

    // Start is called once before t q qhe first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }

           
        for (int i = 0; i < keywords.Length; i++)
        {
            string current = keywords[i];
            Debug.Log("Keyword: " + current);

            keywordActions.Add(current, () => ExecuteAction(current));
        }

        keywordRecognizer = new KeywordRecognizer(keywordActions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognized;
        keywordRecognizer.Start();
        
    }
    void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Keyword: " + args.text);
        keywordActions[args.text].Invoke();
    }

    void ExecuteAction(string keywords)
    {

        switch (keywords)
        {
            case "Fireball":
                Debug.Log("Lanzando Bola de Fuego");
                break;
            case "Snowball":
                Debug.Log("Lanzando Bola de Nieve");
                break;
            case "Slushball":
                Debug.Log("Lanzando Bola de Aguanieve");
                break;
            default:
                Debug.Log("Accion no reconocida");
                break;
        }   
    }
}
