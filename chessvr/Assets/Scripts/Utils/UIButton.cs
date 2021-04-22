using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(UIInputReciever))]
public class UIButton : Button
{
	private InputReceiver receiver;
	protected override void Awake()
	{
		base.Awake();
		receiver = GetComponent<UIInputReciever>();
		onClick.AddListener(() => receiver.OnInputReceived());
	}
}
