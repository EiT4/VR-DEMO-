using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameManager : MonoBehaviour {

    public Text message;

    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }

        _instance = this;
    }

    [SerializeField] private GameObject[] videos;

    private VideoPlayer currentPlayer;

	// Use this for initialization
	void Start () {
        SetActiveVideo("shoe_conv_2");
        StartCoroutine(CheckIfVideoIsDone());
    }

    IEnumerator CheckIfVideoIsDone() {
        while(true) {
            if(currentPlayer != null && !currentPlayer.isPlaying) {// && currentPlayer.frame > 1)
                currentPlayer.transform.GetChild(0).gameObject.SetActive(true);
            } else
            {
                currentPlayer.transform.GetChild(0).gameObject.SetActive(false);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void SetActiveVideo(string id)
    {
        foreach(GameObject videoContainer in videos)
        {
            if(videoContainer.name.Equals(id.Trim())) {
                UnityEngine.Debug.Log("video found!");
                if(currentPlayer != null) currentPlayer.gameObject.SetActive(false);
                videoContainer.SetActive(true);
                VideoPlayer player = videoContainer.GetComponent<VideoPlayer>();

                currentPlayer = player;
                StartCoroutine(PlayVideo());
            }
        }
    }

    IEnumerator PlayVideo()
    {
        currentPlayer.Prepare();

        while(!currentPlayer.isPrepared) {
            yield return null;
        }

        currentPlayer.Play();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Debug(string text)
    {
        UnityEngine.Debug.Log(text);
        message.text = text;
    }

    [SerializeField] public Transform something;
    public void CONFIRM()
    {
        foreach(Transform t in something)
        {
            if (t.GetComponentInChildren<Toggle>().isOn) {
                UnityEngine.Debug.Log("yoloswag!");
            }
        }
    }

}
