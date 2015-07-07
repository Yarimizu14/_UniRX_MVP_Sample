using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;

public class MonsterListModel
{
	public ReactiveCollection<MonsterModel> monsters;

	public MonsterListModel()
	{
		monsters = new ReactiveCollection<MonsterModel> ();
	}

	public void Initialize()
	{
		for (var i = 0; i < 5; i++)
		{
			monsters.Add (new MonsterModel(i+1));
		}
	}
}
