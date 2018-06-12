using UnityEngine;

public class InteractiveSpriteObject : SpriteInteraction
{
	/// <summary>
	/// Additional sprites, that aren't interactive, but still used for animating an interaction
	/// </summary>
	public Sprite[] includedSprites;
	/// <summary>
	/// Array of Items, that this container holds
	/// </summary>
	public uint[] containingItemsIDs;
	private Item[] containingItems;

	/// <summary>
	/// Sprites Renderers for rendering additional sprites
	/// </summary>
	SpriteRenderer[] spriteRenderers;

	protected  override void Awake() 
	{
		base.Awake();
		// Creating array of sprites renderers 
		spriteRenderers = new SpriteRenderer[includedSprites.Length];
		containingItems = new Item[containingItemsIDs.Length];
		for (int i = 0; i < includedSprites.Length; i++)
		{
			spriteRenderers[i].sprite = includedSprites[i];
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
