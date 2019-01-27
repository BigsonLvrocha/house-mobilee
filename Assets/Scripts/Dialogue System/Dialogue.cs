using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void DEvent();

[System.Serializable]
public class Dialogue {

	public List<Sentence> sentences;
	public DEvent endDialog;

	public int length {
		get { return this.sentences.Count; }
	}

	public Dialogue(int n){

		sentences = new List<Sentence>();
		for(int i = 0; i < n; i++)
			sentences[i] = new Sentence();
	}

	public Dialogue(Sentence[] sentences){
		this.sentences = new List<Sentence>(sentences);
	}

	public Dialogue(List<Sentence> sentences){
		this.sentences = sentences;
	}

	public Dialogue(string[] texts){

		sentences = new List<Sentence>();
		for(int i = 0; i < texts.Length; i++){
			sentences[i] = new Sentence(texts[i]);
		}
	}

	public void AddSentence(string text, string name=""){
		sentences.Add(new Sentence(text, name));
	}
}

[System.Serializable]
public class Sentence {

	[TextArea(3, 5)]
	public string text;
	public string name = "";
	
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
	public Sentence(string text, string name="", AudioClip voice=null, DEvent diagEvent=null){
		this.text = text;
		this.name = name;
		this.voice = voice;
		this.diagEvent = diagEvent;
	}
}
