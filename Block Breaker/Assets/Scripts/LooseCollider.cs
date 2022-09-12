using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseCollider : MonoBehaviour
{
    // Start is called before the first frame update

    public LevelManager levelManager;
  
      void OnTriggerEnter2D(Collider2D collision)
    {
        print("Trigger");
        Brick.breakableCount = 0;
        levelManager.LoadLevel("Loose Screen");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
    }


}
