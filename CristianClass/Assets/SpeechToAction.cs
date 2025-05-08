using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechToAction : MonoBehaviour
{

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> keywordActions = new Dictionary<string, Action>();

    public Animator animator;

    public GameObject Image;

    public AudioSource Sound;

    public AudioClip Thunder;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var device in Microphone.devices)
        {
            Debug.Log("Name: "+ device);
        }

        keywordActions.Add("I cast Testicular Torsion", TesticularTorsion);
        keywordActions.Add("I cast Mend Buttcrack", MendButtcrack);

        keywordRecognizer = new KeywordRecognizer(keywordActions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognized;
        keywordRecognizer.Start();
        
    }
    void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Keyword: " + args.text);
        keywordActions[args.text].Invoke();
    }

    void TesticularTorsion()
    {
        animator.SetTrigger("TesticularTorsion");
        Image.SetActive(true);
        Sound.PlayOneShot(Thunder);
        Debug.Log("Se le torcieron las bolas");
    }

    void MendButtcrack()
    {
        Debug.Log("Le sanaron la raya del anuel");
        animator.SetTrigger("MendButtcrack");
    }
}
