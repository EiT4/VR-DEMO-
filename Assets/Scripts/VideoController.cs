using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoController : MonoBehaviour {

	private string baseURL = "jar:file://${Application.dataPath}!/assets/";

	private string oneVideo = "one.mp4";
	private string twoVideo = "two.mp4";
	private string threeVideo = "three.mp4";

	public void StartVideo(string hola) {
		GvrVideoPlayerTexture videoPlayerTexture = GetComponent<GvrVideoPlayerTexture> ();

		videoPlayerTexture.SetOnVideoEventCallback (id => {
			videoPlayerTexture.Play ();
			Debug.Log("hah");
		});

		videoPlayerTexture.videoURL = baseURL + hola + ".mp4";
		videoPlayerTexture.CleanupVideo ();
		videoPlayerTexture.ReInitializeVideo ();
	}

	void Update() {
	}
}
