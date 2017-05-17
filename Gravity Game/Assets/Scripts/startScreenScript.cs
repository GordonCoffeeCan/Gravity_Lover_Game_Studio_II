using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startScreenScript : MonoBehaviour {

    public Animator BlackCover;
    public Image panel;
	public AudioSource startButton;

    // Use this for initialization
    void Start () {

	}

	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("ShiftButton") || Input.GetButtonDown("GamePad_Shift")) {
            BlackFadeOut();
			startButton.Play ();
            Invoke("startGame", 1);
        }
	}

    private void BlackFadeOut()
    {
        BlackCover.SetTrigger("CoverScene");
        panel.color = new Color(1, 1, 1, Mathf.Lerp(panel.color.a, 0, 13 * Time.deltaTime));

    }

    void startGame()
    {
        SceneManager.LoadScene("tutorialScene");
    }
}
