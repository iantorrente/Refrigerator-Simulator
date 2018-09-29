using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement{
  public string achievementName{get; set;}
  public string description {get;set;}
  public int countToUnlock {get;set;}
  public bool unlocked{get;set;}
  public GameObject Sticker;
  
}

public enum AchievementType
{
    Tap,
    FoodScore,
    Start,
    ItemsBought,
    Combo,
};

public class AchievementEventArg : EventArgs
{
    public Achievement Data;
    public AchievementEventArg( Achievement e )
    {
        Data = e;
    }
}