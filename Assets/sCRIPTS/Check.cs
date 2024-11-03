using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

namespace Retur
{
    public class  Bcd 
    {
        public static string ReplaceAt(string input, int index, char newChar)
        {

            char[] chars = input.ToCharArray();  
            chars[index] = newChar;
            return new string(chars);
        }
    }
}
public class Check : MonoBehaviour
{
    void Start()
    {

        //string[] letters = new string[naam.Length];
        //for (int i =0; i < naam.Length; i++ )
        //{
        //    letters[i] = naam.Substring(i, 1);
        //    Debug.Log(letters[i]);
        //}
        //string sentence = "Mahesh Chand" + naam;
        //char[] charArr = sentence.ToCharArray();
        //Debug.Log(charArr[0]);



    }

    
   
}
