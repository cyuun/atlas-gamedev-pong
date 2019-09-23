using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddlescript : MonoBehaviour
{
  public AudioSource hit;
  public float paddleSpeed =  10f;
  public float rotatoSpeed = 100f;
  public KeyCode upKey, downKey, leftKey, rightKey;
  // Start is called before the first frame update
  // void Start()
  // {
  //      
  // }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKey(upKey))   {
      Vector3 currPos       = transform.position;
      Vector3 newPos        = new Vector3(currPos.x,
                                          currPos.y + paddleSpeed * Time.deltaTime,
                                          currPos.z);
      transform.position    = newPos;
    }
    if (Input.GetKey(downKey)) {
      Vector3 currPos       = transform.position;
      Vector3 newPos        = new Vector3(currPos.x,
                                          currPos.y - paddleSpeed * Time.deltaTime,
                                          currPos.z);
      transform.position    = newPos;
    }
    if (!(transform.eulerAngles.z > 15 && transform.eulerAngles.z < 345)) {
      if (Input.GetKey(leftKey)) {
        Vector3 oldRot        = transform.eulerAngles;
        Vector3 newRot        = new Vector3(oldRot.x, oldRot.y, oldRot.z + rotatoSpeed * Time.deltaTime);
        transform.eulerAngles = newRot;
      }
      if (Input.GetKey(rightKey)) {
        Vector3 oldRot        = transform.eulerAngles;
        Vector3 newRot        = new Vector3(oldRot.x, oldRot.y, oldRot.z - rotatoSpeed * Time.deltaTime);
        transform.eulerAngles = newRot;
      }
    } else {
      if (transform.eulerAngles.z > 180) {
        Vector3 oldRot        = transform.eulerAngles;
        Vector3 newRot        = new Vector3(oldRot.x, oldRot.y, oldRot.z + 5);
        transform.eulerAngles = newRot;
      } else {
        Vector3 oldRot        = transform.eulerAngles;
        Vector3 newRot        = new Vector3(oldRot.x, oldRot.y, oldRot.z - 5);
        transform.eulerAngles = newRot;
      }
    }
  }

  private void OnCollisionEnter(Collision collision) {
    hit.Play();
  }
}
