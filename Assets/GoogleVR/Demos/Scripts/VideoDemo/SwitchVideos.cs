// Copyright (C) 2016 Google Inc. All Rights Reserved.
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//    limitations under the License.
using UnityEngine.Video;

namespace GoogleVR.VideoDemo {
  using System;
  using UnityEngine;
  using UnityEngine.UI;

  public class SwitchVideos : MonoBehaviour {
    public GameObject localVideoSample;
    public GameObject dashVideoSample;
    public GameObject panoVideoSample;

    private GameObject[] videoSamples;

    public Text missingLibText;

    public void Awake() {
      videoSamples = new GameObject[3];
      videoSamples[0] = localVideoSample;
      videoSamples[1] = dashVideoSample;
      videoSamples[2] = panoVideoSample;

      string NATIVE_LIBS_MISSING_MESSAGE = "Video Support libraries not found or could not be loaded!\n" +
            "Please add the <b>GVRVideoPlayer.unitypackage</b>\n to this project";

      if (missingLibText != null) {
        try {
          IntPtr ptr = GvrVideoPlayerTexture.CreateVideoPlayer();
          if (ptr != IntPtr.Zero) {
            GvrVideoPlayerTexture.DestroyVideoPlayer(ptr);
            missingLibText.enabled = false;
          } else {
            missingLibText.text = NATIVE_LIBS_MISSING_MESSAGE;
            missingLibText.enabled = true;
          }
        } catch (Exception e) {
          Debug.LogError(e);
          missingLibText.text = NATIVE_LIBS_MISSING_MESSAGE;
          missingLibText.enabled = true;
        }
      }
    }
			
    public void OnFlatLocal() {
			localVideoSample.SetActive (true);
			dashVideoSample.SetActive (false);
			panoVideoSample.SetActive (false);
			localVideoSample.GetComponent<VideoPlayer> ().frame = 0;

			localVideoSample.GetComponent<VideoPlayer> ().Play ();


    }

    public void OnDash() {
			localVideoSample.SetActive (false);
			dashVideoSample.SetActive (true);
			panoVideoSample.SetActive (false);

			dashVideoSample.GetComponent<VideoPlayer> ().frame = 0;

			dashVideoSample.GetComponent<VideoPlayer> ().Play ();

    }

    public void On360Video() {
			localVideoSample.SetActive (false);
			dashVideoSample.SetActive (false);
			panoVideoSample.SetActive (true);

			panoVideoSample.GetComponent<VideoPlayer> ().frame = 0;

			panoVideoSample.GetComponent<VideoPlayer> ().Play ();

    }
	}
}
