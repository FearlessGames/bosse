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
		Paperdoll.Slot slot = Paperdoll.Slot.RING;
		if (bossId == "boss1") {
			int slotIndex = Random.Range(0,3);
			switch (slotIndex) {
			case 0:
				slot = Paperdoll.Slot.HEAD;
				break;
			case 1:
				slot = Paperdoll.Slot.LEGS;
				break;
			case 2:
				slot = Paperdoll.Slot.BACK;
				break;
			case 3:
				slot = Paperdoll.Slot.WRISTS;
				break;
			}


		} else if (bossId == "boss2") {
			int slotIndex = Random.Range(0,3);
			switch (slotIndex) {
			case 0:
				slot = Paperdoll.Slot.CHEST;
				break;
			case 1:
				slot = Paperdoll.Slot.FEET;
				break;
			case 2:
				slot = Paperdoll.Slot.HANDS;
				break;
			case 3:
				slot = Paperdoll.Slot.WAIST;
				break;
			}
		}

		int oldLevel = paperdoll.GetItemLevel (slot);
		int newLevel = oldLevel + Random.Range(0, 5);
		paperdoll.SetItemLevel (slot, newLevel);
	}
}
