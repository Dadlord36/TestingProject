using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnButton : BaseMonoClass {

	private bool canReturn;
	uint sceneReturnTo;
	[SerializeField]
	Sprite[] buttonsSprites = new Sprite[2];
	const int sortingOrderNumber = 6;

	Image buttonImage;
	private Button actualButton;

	public bool CanReturn
	{
		get
		{
			return canReturn;
		}

		set
		{
			canReturn = value;
			buttonImage.sprite = CanReturn ? buttonsSprites[0] : buttonsSprites[1];
			actualButton.enabled= canReturn;
		}
	}

	private void Awake()
	{
	buttonImage = GetComponentInChildren<Image>();
	actualButton = GetComponent<Button>();
	}
	private void OnMouseDown()
	{
		SceneManager.LoadScene((int)sceneReturnTo);
	}

	public override void Prepere(uint level)
	{
		//throw new System.NotImplementedException();
	}
}
