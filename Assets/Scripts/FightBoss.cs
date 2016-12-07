using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightBoss : MonoBehaviour {
	public Paperdoll paperdoll;
	public Text message;
	public Button fight1;
	public Button fight2;
	private string currentBoss;
	private bool wonLastFight;
	public int secondsToWaitForFight;


	// Use this for initialization
	void Start() {
		message.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update() {
		
	}

	public void Fight(string bossId) {
		print("Fight " + bossId + "!");
		currentBoss = bossId;
		DisableButtons();
		Invoke ("PerformFight", secondsToWaitForFight);

	}

	private void PerformFight() {
		bool wonLastFight = GetFightOutcome();
		if (wonLastFight) {
			DistributeLoot(currentBoss);
		} else {
			AddMessage("You were defeated! Try again");
		}

		EnableButtons();
	}

	private bool GetFightOutcome() {
		return Random.Range(1, 10) > 3;
	}

	private void DistributeLoot(string currentBoss) {
		Paperdoll.Slot slot = Paperdoll.Slot.RING;
		if (currentBoss == "boss1") {
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


		} else if (currentBoss == "boss2") {
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

		AddMessage("Got " + slot.ToString () + " of level " + newLevel);

		paperdoll.SetItemLevel (slot, newLevel);

	}

	private void AddMessage(string messageToAdd) {
		if (message.text == "Here be text") {
			message.text = "";
		}
		message.text = messageToAdd + "\n" + message.text;
		message.enabled = true;
	}

	public void EnableButtons() {
		fight1.interactable = true;
		fight2.interactable = true;
	}

	public void DisableButtons() {
		fight1.interactable = false;
		fight2.interactable = false;
	}


}
