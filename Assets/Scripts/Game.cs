using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;



    public class Game : MonoBehaviour
    {
        public static Game instance;
        public TMP_Text deathText;
        public int playerDeathCounter = 0;
    public int test;

        private void Awake()
        {
            if (instance != null)
            {

                Destroy(this);
            }
            else
            {
                instance = this;
            }
        }

        public void ChangeDeathCounter(int deathAmount)
        {
        
        playerDeathCounter += deathAmount;
        deathText.text = "Player Deaths: " + playerDeathCounter++.ToString();


    }
    }


