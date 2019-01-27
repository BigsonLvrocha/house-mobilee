using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void DEvent();

[System.Serializable]
public class Dialogue {

	public Sentence[] sentences;
	public DEvent endDialog;

	public int length {
		get { return this.sentences.Length; }
	}

	public Dialogue(int n){

		sentences = new Sentence[n];
		for(int i = 0; i < n; i++)
			sentences[i] = new Sentence();
	}

	public Dialogue(Sentence[] sentences){
		this.sentences = sentences;
	}

	public Dialogue(string[] texts){

		sentences = new Sentence[texts.Length];
		for(int i = 0; i < texts.Length; i++){
			sentences[i] = new Sentence(texts[i]);
		}
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
	
	public Sentence(){}
	public Sentence(string text, AudioClip voice=null, DEvent diagEvent=null){
		this.text = text;
		this.voice = voice;
		this.diagEvent = diagEvent;
	}
}
