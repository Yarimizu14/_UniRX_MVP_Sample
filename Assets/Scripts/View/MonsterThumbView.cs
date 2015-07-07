using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MonsterThumbView : MonoBehaviour {

	/// <summary>
	/// The text.
	/// </summary>
	private Text _text;

	/// <summary>
	/// Initializes the view.
	/// </summary>
	/// <param name="mosnter">Mosnter.</param>
	public void InitializeView(MonsterModel mosnter)
	{
		_text = this.transform.FindChild ("Text").GetComponent<Text>();

		_text.text = "000" + mosnter.monsterId;
	}
}
