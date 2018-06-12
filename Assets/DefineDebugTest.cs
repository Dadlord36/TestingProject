using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefineDebugTest : MonoBehaviour {

#if DEBUG
	// Use this for initialization
	void Start () {
        var textComp = GetComponent<UnityEngine.UI.Text>();
        textComp.text = "This is debug now";
    }
#endif
	

}
