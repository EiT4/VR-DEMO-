using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoManager : MonoBehaviour {

	[SerializeField] public string[] videoNames;
	public GameObject videoQuadPrefab;

	public void StartVideo(string videoName) {
		GameObject oldQuad = GameObject.FindWithTag ("Video");

		if (oldQuad != null) {
			Destroy (oldQuad);
		}

		GameObject quad = Instantiate (videoQuadPrefab, Vector3.zero, Quaternion.identity);
		GvrVideoPlayerTexture player = quad.GetComponent<GvrVideoPlayerTexture> ();

		player.videoURL = "jar:file://${Application.dataPath}!/assets/" + videoName + ".mp4";
		player.videoType = GvrVideoPlayerTexture.VideoType.Other;

		/*player.SetOnVideoEventCallback (id => {
			player.Play();
		});*/


	}
}
