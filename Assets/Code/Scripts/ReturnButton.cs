using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CircleCollider2D))]

public class ReturnButton : MonoBehaviour {
	[SerializeField]
	bool enabled;
	[SerializeField]
	uint sceneReturnTo;
	const int sortingOrderNumber = 6;
	SpriteRenderer spriteRenderer;
	[SerializeField]
	Sprite[] buttonsSprites = new Sprite[2];
	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = enabled ? buttonsSprites[0] : buttonsSprites[1];
		spriteRenderer.sortingOrder = sortingOrderNumber;
	}
	private void OnMouseDown()
	{
		SceneManager.LoadScene((int)sceneReturnTo);
	}
}
