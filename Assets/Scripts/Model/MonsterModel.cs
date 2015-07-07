using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;

public class MonsterModel
{
	public int monsterId;

	public Color materialColor;

	public ReactiveProperty<bool> isSelected;

	public MonsterModel(int id)
	{
		this.monsterId = id;

		isSelected = new ReactiveProperty<bool> (false);

		switch (monsterId)
		{
		case 1:
			this.materialColor = Color.red;
			break;
		case 2:
			this.materialColor = Color.green;
			break;
		case 3:
			this.materialColor = Color.blue;
			break;
		case 4:
			this.materialColor = Color.yellow;
			break;
		default:
			this.materialColor = Color.black;
			break;
		}
	}
}
