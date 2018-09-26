using System.Collections.Generic;
using UnityEngine;

public class FoodValue : MonoBehaviour {
  
  public string foodName;
  public int scoreValue;
  public int moneyValue;
  public int throwAwayValue;
  public double cookingTime;
  public double cost;
  public string type;
  public List<Sprite> sprites = new List<Sprite>();
  public ParticleSystem particle;
  public ParticleSystem reactionParticle;
  public GameObject reactionResult;
}