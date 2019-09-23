using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scorescript : MonoBehaviour
{
  public Text lScore;
  public Text rScore;

  private int scoreL = 0;
  private int scoreR = 0;

  public static scorescript S;

  // Start is called before the first frame update
  // void Start() {
  // }

  // Update is called once per frame
  // void Update() {
  //
  // }
  
  public void Awake() {
    scoreL = 0;
    scoreR = 0;

    S = this;
  }
  
  public void UpdateScore(string bound) {
    if (bound == "leftBounds") {
      scoreL++;
      lScore.text = scoreL.ToString();
    }
    if (bound == "rightBounds") {
      scoreR++;
      rScore.text = scoreR.ToString();
    }
  }
}
