using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Retur;
using UnityEngine.SceneManagement;
using System.Linq;

public class  GameCOntroller : MonoBehaviour
{


    UiScript UScript;
    public Text GU;
    public Text TimeField;
    public GameObject[] hangMan;
    public GameObject winText;
    public GameObject loseText;
    public Text wordToFindField;
    private float time;
    private string[] AnimalLocal = { "HIPPOPOTAMUS", "GIRAFFE", "ELEPHANT", "CHIMPANZEE", "DEAR", "TIGER" };
    private string[] wordLocal = {"APPLE", "GRAPES", "CHERRY", "MANGO", "BANANA", "WATERMELON"};
    private string chosenWord;
    private string hiddenWord;
    private int fails;
    private bool gameEnd = false;
    private string check;
    private char[] naam;
    public GameObject LosePanel;
    public GameObject winPanel;
    int length;
    char letter;
    [SerializeField]private Text clue;
    public bool option = false;
    public AudioClip scream;
    public AudioClip neck;
    public AudioClip die;
    public AudioClip[] clips;
    public AudioSource Source;
    public AudioClip click;
    public AudioClip winn;
    private int cl = 0;
    public void Op()
    {
        Debug.Log("Preeeeeee");
        option = true;
    }
    void Start()
    {
        if (option == true)
        {
            chosenWord = AnimalLocal[Random.Range(0, AnimalLocal.Length)];
            naam = chosenWord.ToCharArray();
            GU.text = ("Guess the Animals");
         
        }
        else if (option == false)
        {
            chosenWord = wordLocal[Random.Range(0, wordLocal.Length)];
            naam = chosenWord.ToCharArray();
            GU.text = ("Guess the fruits");
        }
        //Random Word Selection
        //chosenWord = wordLocal[Random.Range(0, wordLocal.Length)];
        //naam = chosenWord.ToCharArray();

        // CLue
        if (chosenWord == "MANGO" )
        {
            clue.text = "I am the king , both sour and sweet";
        }
        else if(chosenWord == "WATERMELON")
        {
            clue.text = "I am full of water, summer ";
        }
        else if (chosenWord == "APPLE")
        {
            clue.text = "I am winter king, Doctors afraid of me";
        }
        else if (chosenWord == "BANANA")
        {
            clue.text = "I wear a yellow cloth";
        }
        else if( chosenWord == "CHERRY")
        {
            clue.text = "I am red , sweet and small";
        }
        else if( chosenWord == "GRAPES")
        {
            clue.text = "No Drinking!! ";
        }
        else if (chosenWord == "TIGER")
        {
            clue.text = "You can never catch me by running";
        }
        else if (chosenWord == "GIRAFFE")
        {
            clue.text = "Everyone in Jungle is tiny, ha ha ha";
        }
        else if (chosenWord == "ELEPHANT")
        {
            clue.text = "In relationship with ant, ;) ";
        }
        else if (chosenWord == "CHIMPANZEE")
        {
            clue.text = "We are very much same Bro";
        }
        else if (chosenWord == "DEAR")
        {
            clue.text = "I love my legs, because they save me everytimes";
        }
        else if (chosenWord == "HIPPOPOTAMUS")
        {
            clue.text = "I can kill anyone but I don't like meat";
        }
        Debug.Log(chosenWord);
        
        length = chosenWord.Length;

        //Showing Hidden Word to Gamer
        for (int i=0; i< chosenWord.Length; i++)
        {
            
            
            letter = chosenWord[i];
            if (char.IsWhiteSpace(letter)) 
            {
                hiddenWord += "";
            }
            else
            {
                hiddenWord += "_";
            }
            
        }
        wordToFindField.text = hiddenWord;
    }


    void Update()
    {
        //Timer
        if(gameEnd == false)
        {
            time += Time.deltaTime;
            TimeField.text = time.ToString();
        }
        
    }

    private void OnGUI ()
    {
        Event e = Event.current; 
        if(e.type == EventType.KeyDown && e.keyCode.ToString().Length == 1 && !gameEnd)
        {
            string pressedLetter = e.keyCode.ToString();
            Debug.Log("Keydown event was triggered " + pressedLetter);
            string sentence = pressedLetter;
            char[] charArr = sentence.ToCharArray();
            char c = charArr[0];
            int i = chosenWord.IndexOf(pressedLetter);
            if (chosenWord.Contains(pressedLetter))
            {
                if(chosenWord.Count(f => (f == c)) > 1)
                    for(int n = 0; n< chosenWord.Length; n++)
                    {
                        if (naam[n] == c)
                        {
                            hiddenWord = Bcd.ReplaceAt(hiddenWord, n, c);
                        }
                    }
                else
                {
                    hiddenWord = Bcd.ReplaceAt(hiddenWord, i, c);
                }
                Debug.Log(Bcd.ReplaceAt(hiddenWord, i, c));        
                wordToFindField.text = hiddenWord;
                check = hiddenWord;
            }

            else
            {
                hangMan[fails].SetActive(true);
                fails++;
                Source.clip = scream;
                Source.Play();
            }

            //Game lose
            if(fails == hangMan.Length )
            {
                loseText.SetActive(true);
                LosePanel.SetActive(true);
                gameEnd = true;
                cl++;
                Source.clip = clips[cl];
                Source.Play();


            }

            //Game win
            if (check == chosenWord)
            {
                winPanel.SetActive(true);
                winText.SetActive(true);
                gameEnd = true;
                Source.clip = winn;
                Source.Play();
            }
            //if (!hiddenWord.Contains("_"))
            //{
            //    winText.SetActive(true);
            //    gameEnd = true;
            //}
        }

    }

    public void Replay ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Source.clip = click;
        Source.Play();
    }

    public void Back ()
    {
        // UScript.OptionPanel.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2 );
       
        Source.clip = click;
        Source.Play();
        
    }


}
