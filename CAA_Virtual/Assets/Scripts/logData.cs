using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logData : MonoBehaviour {

	// Use this for initialization
	void Start () {
        string[] lines = { "First line", "Second line", "Third line" };
        // WriteAllLines creates a file, writes a collection of strings to the file,
        // and then closes the file.  You do NOT need to call Flush() or Close().
        System.IO.File.WriteAllLines(@"C:\Users\Jake\Documents\test", lines);
    }
}
