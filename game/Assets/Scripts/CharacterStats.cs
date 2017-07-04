using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour {
	public Slider enduranceSlider;
	public Slider healthSlider;

	public bool visible;

	public int healthValue=100;
	public int maxhealth=100;
	public float enduranceValue=100f;
	public int maxendurance = 100;
	public GameObject stats;
	public Text MaxHealth;
	public Text MaxEndurance;
	public Text Health;
	public Text Endurance;

	// Use this for initialization
	void Start () {
		enduranceSlider.maxValue = maxendurance;
		enduranceSlider.value = enduranceValue;
		healthSlider.maxValue = maxhealth; 
		healthSlider.value = healthValue;
		stats.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		enduranceValue += 5f*Time.deltaTime;
		if(maxendurance<enduranceValue)
		{
			enduranceValue=maxendurance ;
		}
		if(enduranceValue<0)
		{
			enduranceValue=0;
		}
		if (healthValue > maxhealth) {
			healthValue = maxhealth;
		}
		if (healthValue < 0) {
			healthValue = 0;
		}
		enduranceSlider.value=enduranceValue;
		if (maxhealth > healthSlider.maxValue)
			UpdateStats (healthSlider, maxhealth);
		if (maxendurance > enduranceSlider.maxValue)
			UpdateStats (enduranceSlider, maxendurance);
		if(Input.GetKeyUp(KeyCode.C))
		{
			visible = !visible;		
		}

	}
	public void UpdateStats(Slider sl,int st){
		sl.maxValue = st;
	}
	public void delStats(int st,int delSt){
		st -= delSt;
	}
	public void AddStats(int st, int addSt){
		st += addSt;
	}
	public void AddStats(float st, float addSt){
		st += addSt;
	}
	void OnGUI(){
		if (visible) {
			stats.SetActive (visible);
		} else {
			stats.SetActive (visible);
		}
		MaxHealth.text = maxhealth.ToString();
		MaxEndurance.text = maxendurance.ToString();
		Health.text = healthValue.ToString();
		Endurance.text = enduranceValue.ToString();
	}
}
