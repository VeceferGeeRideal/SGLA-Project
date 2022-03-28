﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager instance; //MARKER SINGLETON PATTERN
   public bool isPaused;

   private void Awake() {
       if (instance == null){
           instance = this;
       } else {
           if (instance != this){
               Destroy(gameObject);
           }
       }
       DontDestroyOnLoad(gameObject);
   }
}