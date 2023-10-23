using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLink : MonoBehaviour
{
	public void Link(string LinkID)
	{
		Application.OpenURL(LinkID);
	}
}
