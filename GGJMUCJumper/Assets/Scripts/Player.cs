using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public float speed;
	public string keyHeart;
	
	// Use this for initialization
	void Start () {
	}
	
	void FixedUpdate(){
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(speed*Time.deltaTime,0,0));
	}
}
