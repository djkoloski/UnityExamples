using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MultiLineInput : MonoBehaviour
{
	public InputField input;
	public Text preText;
	public Text postText;

	public void Update()
	{
		string preStr = input.text.Substring(0, input.caretPosition);
		int preStrIndex = preStr.LastIndexOf('\n');
		if (preStrIndex != -1)
			preStr = preStr.Substring(0, preStrIndex);
		else
			preStr = "";

		string postStr = input.text.Substring(input.caretPosition);
		int postStrIndex = postStr.IndexOf('\n');
		if (postStrIndex != -1)
			postStr = postStr.Substring(postStrIndex + 1);
		else
			postStr = "";

		preText.text = preStr;
		postText.text = postStr;
	}
}
