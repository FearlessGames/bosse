using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paperdoll : MonoBehaviour {


	// Use this for initialization
	void Start() {
		UpdateLabels ();
	}

	// Update is called once per frame
	void Update() {

	}

	public enum Slot {
		HEAD,
		NECK,
		CHEST,
		BACK,
		WRISTS,
		HANDS,
		WAIST,
		LEGS,
		FEET,
		RING1,
		RING2
	};

	public Text headText;
	private SortedDictionary<Slot, int> items = new SortedDictionary<Slot, int>();

	public Paperdoll () {
		items.Add (Slot.HEAD, 1);
		items.Add (Slot.NECK, 1);
		items.Add (Slot.CHEST, 1);
		items.Add (Slot.BACK, 1);
		items.Add (Slot.WRISTS, 1);
		items.Add (Slot.HANDS, 1);
		items.Add (Slot.WAIST, 1);
		items.Add (Slot.LEGS, 1);
		items.Add (Slot.FEET, 1);
		items.Add (Slot.RING1, 1);
		items.Add (Slot.RING2, 1);


	}

	private void UpdateLabels ()  {
		headText.text = items [Slot.HEAD].ToString ();
	}

	public int GetItemLevel(Slot slot) {
		return items [slot];
	}

	public void SetItemLevel(Slot slot, int itemLevel) {
		items [slot] = itemLevel;
	}

}
