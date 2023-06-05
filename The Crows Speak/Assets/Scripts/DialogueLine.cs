using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueLine : DialogueBaseClass
    {
        private Text textHolder;
        [Header("Text Options")]
        [SerializeField] private string input;
        [SerializeField] private Color textColor;
        [SerializeField] private Font textFont;
        [SerializeField] private int textSize;

        [Header("Time Parameters")]
        [SerializeField] private float delay;
        [SerializeField] private float delayBetweenLines;


        [Header("Sound Parameters")]
        [SerializeField] private AudioClip sound;

        private void Start()
        {
            textHolder = GetComponent<Text>();
            StartCoroutine(WriteText(input, textHolder, textColor, textFont, delay, sound, delayBetweenLines, textSize));
        }
    }
}
