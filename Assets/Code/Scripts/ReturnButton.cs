using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnButton : BaseClass {

	bool canReturn;
	uint sceneReturnTo;
    [SerializeField]
    Sprite[] buttonsSprites = new Sprite[2];
	const int sortingOrderNumber = 6;

	Image buttonImage;

    private void Awake()
    {
    buttonImage = GetComponentInChildren<Image>();
    }
	private void Start()
	{
        buttonImage.sprite = canReturn ? buttonsSprites[0] : buttonsSprites[1];
    }
    private void OnMouseDown()
	{
		SceneManager.LoadScene((int)sceneReturnTo);
	}
}
