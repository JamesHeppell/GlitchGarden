using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

	private int currency=100;
	private Text starText;
	public enum Status {SUCCESS, FAILURE};
	
	// Use this for initialization
	void Start () {
		starText= GetComponent<Text>();
		UpdateDisplay();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void AddStars (int amount){
		print (amount + " stars addded to display");
		currency +=amount;
		UpdateDisplay();
	}
	
	public Status UseStars (int amount){
		if (currency >=amount){
			currency -= amount;
			UpdateDisplay();
			return Status.SUCCESS;
		}
		return Status.FAILURE;
	}
	
	private void UpdateDisplay(){
		starText.text = currency.ToString();
	}
	
}
