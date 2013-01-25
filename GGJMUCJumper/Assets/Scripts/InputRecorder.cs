using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public struct JumpEvent {
	public int frameStart;
	public int frameCount;
}

public class InputRecorder : MonoBehaviour {
	
	public string JumpKey;
	
	bool lastKeyState = false;
	int jumpStartFrame;
	int currentFrame;
	public List<JumpEvent> JumpEvents = new List<JumpEvent>();
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!recording) return;
		
		currentFrame++;
		var keyState = Input.GetKey(JumpKey);
		if (keyState) {
			if (!lastKeyState) 
			{
				// Start a new jump event.
				jumpStartFrame = currentFrame;
			}
		}
		else {
			if (lastKeyState)
			{
				// Jump event ends, store result
				JumpEvents.Add(new JumpEvent{frameStart = jumpStartFrame, frameCount = currentFrame - jumpStartFrame});
				Debug.Log("Num jump events: " + JumpEvents.Count + ". Last event: " + JumpEvents[JumpEvents.Count-1].frameStart + 
					" - " + JumpEvents[JumpEvents.Count-1].frameCount);
			}
		}
		
		lastKeyState = keyState;
	}
	
	bool recording;
	void OnGUI() {
		if (GUI.Button(new Rect(5, 10, 120, 20), recording ? "Stop Recording": "Start Recording")) {
			recording = !recording;
			if (recording) {
				JumpEvents.Clear();
				currentFrame = 0;
			}
		}
	}
}
