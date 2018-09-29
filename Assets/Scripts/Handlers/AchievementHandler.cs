using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class AchievementHandler 
{
    private Dictionary<AchievementType,List<Achievement>> _achievements;
    private Dictionary<AchievementType,int> _achievementKeeper;
    private int counter;
    public event EventHandler AchievementUnlocked;
    protected virtual void RaiseAchievementUnlocked(Achievement ach){
        ach.unlocked =true;
        Helpers.showAchievement(ach);
        var del = AchievementUnlocked  as EventHandler;
        if(del!= null){
            del(this,new AchievementEventArg(ach));
        }
    }
    public AchievementHandler(){
        counter = 0;
        _achievementKeeper = new Dictionary<AchievementType,int>();
        _achievements = new Dictionary<AchievementType,List<Achievement>>();
        //start
        List<Achievement> listStart = new List<Achievement>();
        listStart.Add(new Achievement() { countToUnlock = 1,  achievementName ="Begin",unlocked = false, description = "First Time" });
        listStart.Add(new Achievement() { countToUnlock = 5,  achievementName ="Starter",unlocked = false, description = "Still Hungry?" });
        listStart.Add(new Achievement() { countToUnlock = 10, achievementName ="Novice",unlocked = false, description = "Hello and Welcome Back!" });
        listStart.Add(new Achievement() { countToUnlock = 16, achievementName ="Apprentice",unlocked = false, description = "Feaster" });
        listStart.Add(new Achievement() { countToUnlock = 50, achievementName ="Master",unlocked = false, description = "Hungry" });
        
        List<Achievement> moneyGoal = new List<Achievement>();
        moneyGoal.Add(new Achievement() {  achievementName = "dollar", unlocked = false, description = "Won Me First Dollar" });
        moneyGoal.Add(new Achievement() {  achievementName = "thousand", unlocked = false, description = "I has moneyz" });
        moneyGoal.Add(new Achievement() {  achievementName = "tenthousand", unlocked = false, description = "I can retire" });
        moneyGoal.Add(new Achievement() {  achievementName = "million", unlocked = false, description = "$$$ Millionair $$$" });
        
        List<Achievement> combos = new List <Achievement>();
        combos.Add(new Achievement(){unlocked = false, achievementName = "Yummy",  description = "Great Combo"});
        combos.Add(new Achievement(){unlocked = false, achievementName = "Ew",  description = "Poor Combo"});
        combos.Add(new Achievement(){unlocked = false, achievementName = "Amazing",  description = "Spectacular Combo"});
        _achievements.Add(AchievementType.Start,listStart);
        _achievements.Add(AchievementType.FoodScore, moneyGoal);
        _achievements.Add(AchievementType.Combo,combos);
    }  
    public void RegisterEvent(AchievementType type){
       
        ParseAchievements(type);
    }
    public void RegisterEvent(AchievementType type, string name){
        
        ParseAchievements(type,name);
    }
    public void ParseAchievements(AchievementType type){
      foreach( var kvp in _achievements.Where( a => a.Key == type ) ){
            foreach( var ach in kvp.Value.Where( a => a.unlocked == false ) ) 
            {
                if( type == AchievementType.Start ) {
                        counter++;
                        if(counter > ach.countToUnlock)RaiseAchievementUnlocked(ach);
                }
            }
        }
    }
    public void ParseAchievements(AchievementType type, string name){
      foreach( var kvp in _achievements.Where( a => a.Key == type ) ){
            foreach( var ach in kvp.Value.Where( a => a.unlocked == false ) ) 
            {
                if(ach.achievementName == name){
                    RaiseAchievementUnlocked(ach);
                    return;
                }  
                
            }
        }
    }
    
}
