﻿using System.Collections;
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
		float currentBossLevel = 0;
		if (currentBoss == "boss1") {
			currentBossLevel = 90;
		} else if (currentBoss == "boss2") {
			currentBossLevel = 120;
		}
		bool wonLastFight = GetFightOutcome(currentBossLevel, paperdoll.GetAverageLevel());
		if (wonLastFight) {
			DistributeLoot(currentBoss);
		} else {
			AddMessage("<color=red>You were defeated! Try again</color>");
		}

		EnableButtons();
	}

	private bool GetFightOutcome(float currentBossLevel, float playerLevel) {
		float steepness = 0.09f;
		float chance = GetLogisticValue(10f, currentBossLevel, steepness, playerLevel);
		print("CurrentBossLevel: " + currentBossLevel + ", playerLevel: " + playerLevel + ", steepness: " + steepness);
		print("Fighting boss with chance " + chance);
		return Random.Range(0, 10) < chance;
	}

	private void DistributeLoot(string currentBoss) {
		Paperdoll.Slot slot = Paperdoll.Slot.RING;
		if (currentBoss == "boss1") {
			int slotIndex = (int) Mathf.Round(Random.Range(-0.5f,3.49f));
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
			int slotIndex = (int) Mathf.Round(Random.Range(-0.5f,3.49f));
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

		float averageLevel = paperdoll.GetAverageLevel();
		int newLevel = (int) Mathf.Round(averageLevel + Random.Range(0f, averageLevel * 0.1f));
		int oldLevel = paperdoll.GetItemLevel(slot);
		if (newLevel > oldLevel) {
			paperdoll.SetItemLevel (slot, newLevel);
			AddMessage("Got " + slot.ToString() + " of level " + newLevel);
		} else {
			AddMessage("<color=aqua>Got " + slot.ToString() + " of level " + newLevel + " which is worse than what you have</color>");
		}
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

	private float GetLogisticValue(float maxValue, float midPoint, float steepness, float currentPoint) {
		return maxValue / (1 + Mathf.Exp(-steepness * (currentPoint - midPoint)));
	}


}
