using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
	public Text avgText;

	private SortedDictionary<Slot, int> items = new SortedDictionary<Slot, int>();
	private float averageLevel = 0;

	public Paperdoll () {
		int startingLevel = 100;
		items.Add (Slot.HEAD, startingLevel);
		items.Add (Slot.NECK, startingLevel);
		items.Add (Slot.CHEST, startingLevel);
		items.Add (Slot.BACK, startingLevel);
		items.Add (Slot.WRISTS, startingLevel);
		items.Add (Slot.HANDS, startingLevel);
		items.Add (Slot.WAIST, startingLevel);
		items.Add (Slot.LEGS, startingLevel);
		items.Add (Slot.FEET, startingLevel);
		items.Add (Slot.RING, startingLevel);
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
		UpdateAvg ();
	}

	public int GetItemLevel(Slot slot) {
		return items [slot];
	}

	public void SetItemLevel(Slot slot, int itemLevel) {
		items [slot] = itemLevel;
		UpdateLabels ();
	}

	private void UpdateAvg() {
		int sum = items.Sum (entry => entry.Value);
		averageLevel = (float)sum / items.Count;
		avgText.text = "Average gear level: " + averageLevel;
	}

	public float GetAverageLevel() {
		return averageLevel;
	}

}
