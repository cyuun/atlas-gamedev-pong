using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballscript : MonoBehaviour
{
  public  float      speed = 200f;
  private Vector3    startPos;
  private Vector3    resetPos;
  private float      rlForce = 200f;
  private float      udForce = 200f;
  private float      resetRand;
  private int        lScore = 0;
  private int        rScore = 0;
  private Rigidbody  rb;
  public AudioSource hit;

  void Start()
  {
    startPos = transform.position;
    rb = GetComponent<Rigidbody>();

    StartCoroutine(methodName:"Launch");
  }

  void Update() {
    //if (Input.GetKeyDown(KeyCode.space)) {
    //  hit.Play();
    //}
  }

  private void OnTriggerEnter(Collider other) {
    Reset(other.tag);
    scorescript.S.UpdateScore(other.tag);
  }

  public void Reset(string bound) {
    transform.position = startPos;
    rb.velocity = Vector3.zero;
    resetRand = Random.Range(-Mathf.PI/3, Mathf.PI/3);
    if (bound ==  "leftBounds") {
      rlForce =  speed * Mathf.Cos(resetRand);
      udForce =  speed * Mathf.Sin(resetRand);
      rScore  += 1;
    }
    if (bound == "rightBounds") {
      rlForce = -speed * Mathf.Cos(resetRand);
      udForce =  speed * Mathf.Sin(resetRand);
      lScore  += 1;
    }
    
    StartCoroutine(methodName:"Launch");
  }

  public IEnumerator Launch() {
    yield return new WaitForSeconds(2);

    rb.AddForce(transform.right * rlForce);
    rb.AddForce(transform.up    * udForce);

    yield return null;
  }

}

