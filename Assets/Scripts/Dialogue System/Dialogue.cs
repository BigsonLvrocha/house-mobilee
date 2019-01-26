using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void DEvent();

[System.Serializable]
public class Dialogue {
	public Sentence[] sentences;
	public DEvent endDialog;

	public Dialogue(int n){
		sentences = new Sentence[n];

		for(int i = 0; i < n; i++)
			sentences[i] = new Sentence();
	}
}

[System.Serializable]
public class Sentence {
	
	[TextArea(3, 5)]
	public string text;
	
	private float _delay; 
	private float TIME_PER_CHAR = 0.05f; // In seconds
	private float TIME_PER_WORD = 0.3f; // In seconds
	public float delay { // Delay for auto advance 
		get { return text.Length*TIME_PER_CHAR; } // By character
		// get { return text.Split(' ').Length*TIME_PER_WORD; } // By word
	}
	
	public AudioClip voice;

	// Dialogue event
	public DEvent diagEvent;
}
