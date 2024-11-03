using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCon : MonoBehaviour
{
    public string[] words;

    private int life = 10;
    private string userInput = "";
    private string guessWord = "";
    private string wordChosen = "";
    void Start()
    {
        wordChosen = words[Random.Range(0, words.Length)];
        guessWord = new string("_"[0], wordChosen.Length);
    }

    private void OnGUI()
    {
        if (life > 0 || guessWord != wordChosen)
        {
            GUILayout.Box(guessWord);
            userInput = GUILayout.TextField(userInput);

            if (GUILayout.Button("Try"))
            {
                if (userInput.Length > 1)
                    print("Please Only Enter One CHaracter");
                else
                    CheckChar(userInput[0]);
            }
        }
    }
    private void CheckChar ( char c)
    {
        bool charExists = false;
        for (int x= 0; x< wordChosen.Length; x++)
        {
            if (wordChosen[x]== c)
            {
                charExists = true;
                string temp = guessWord.Substring(0, x );
                guessWord = temp + c.ToString() + guessWord.Substring(x + 1, guessWord.Length - x - 1);
            }
        }

        if (!charExists)
            life--;
    }
    void Update()
    {
        
    }
}

















/*

chosenWord = abcd

hiddenWord = _ _ _ _

    [ _ , _ , _ ,_ ]


covert abcd to char[]







































*/



