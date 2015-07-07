using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UniRx;
using UniRx.Triggers;

public class SelectDoneButtonView : MonoBehaviour {

	private Button _button;

	void Awake()
	{
		_button = this.GetComponent <Button> ();

		_button.interactable = false;
	}

	public void OnSelectDoneChaged(bool selectDone)
	{
		_button.interactable = selectDone;
	}

	public IObservable<Unit> OnClickAsObservable()
	{
		return this._button.onClick.AsObservable ();
	}
}
