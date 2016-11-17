using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightBoss : MonoBehaviour {
	public Paperdoll paperdoll;

	// Use this for initialization
	void Start() {
		
	}
	
	// Update is called once per frame
	void Update() {
		
	}

	public void Fight(string bossId) {
		print("Fight " + bossId + "!");
		int oldLevel = paperdoll.GetItemLevel (Paperdoll.Slot.HEAD);
		int newLevel = oldLevel + 1;
		paperdoll.SetItemLevel (Paperdoll.Slot.HEAD, newLevel);
	}
}
