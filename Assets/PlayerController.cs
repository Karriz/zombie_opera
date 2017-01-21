using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.D)) {
            gameObject.transform.localScale = new Vector3(1,1,1);
            gameObject.transform.Translate (new Vector3(1, 0, 0));
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            gameObject.transform.Translate(new Vector3(-1, 0, 0));
        }
    }
}
