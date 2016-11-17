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
		RING
	};

	public Text headText;
	public Text neckText;
	public Text backText;
	public Text chestText;
	public Text wristsText;
	public Text handsText;
	public Text waistText;
	public Text legsText;
	public Text feetText;
	public Text ringText;

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
		items.Add (Slot.RING, 1);
	}

	private void UpdateLabels ()  {
		headText.text = items [Slot.HEAD].ToString ();
		neckText.text = items [Slot.NECK].ToString ();
		backText.text = items [Slot.BACK].ToString ();
		chestText.text = items [Slot.CHEST].ToString ();
		wristsText.text = items [Slot.WRISTS].ToString ();
		handsText.text = items [Slot.HANDS].ToString ();
		waistText.text = items [Slot.WAIST].ToString ();
		legsText.text = items [Slot.LEGS].ToString ();
		feetText.text = items [Slot.FEET].ToString ();
		ringText.text = items [Slot.RING].ToString ();
	}

	public int GetItemLevel(Slot slot) {
		return items [slot];
	}

	public void SetItemLevel(Slot slot, int itemLevel) {
		items [slot] = itemLevel;
		UpdateLabels ();
	}

}
