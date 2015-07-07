using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UniRx;
using UniRx.Triggers;

public class MonsterThumbView : MonoBehaviour, IPointerClickHandler {

	/// <summary>
	/// The text.
	/// </summary>
	private Text _text;

	/// <summary>
	/// The text.
	/// </summary>
	private Image _img;

	/// <summary>
	/// The image.
	/// </summary>
	private Color _initialColor;

	/// <summary>
	/// The click.
	/// </summary>
	public UnityEvent click;

	void Awake()
	{
		_img = this.GetComponent<Image> ();

		_initialColor = _img.color;
	}

	/// <summary>
	/// Initializes the view.
	/// </summary>
	/// <param name="mosnter">Mosnter.</param>
	public void InitializeView(MonsterModel mosnter)
	{
		_text = this.transform.FindChild ("Text").GetComponent<Text>();

		_text.text = "000" + mosnter.monsterId;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		click.Invoke ();
	}

	public void OnMonsterSelecteStateChanged(bool isSelected)
	{
		if (isSelected) {
			_img.color = Color.gray;
		} else {
			_img.color = _initialColor;
		}
	}
}
