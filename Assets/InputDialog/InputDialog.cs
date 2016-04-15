using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InputDialog : MonoBehaviour
{
	// Set these in the inspector by dragging each UI input
	// game object into its public fields on this component
	public InputField nameInput;
	public InputField descriptionInput;
	public Slider amountInput;
	public Dropdown choiceInput;

	// This is called when the Submit button is clicked
	// It is bound to the submit button in the inspector -
	// look for Submit > Button component > OnClick
	public void OnSubmit()
	{
		// Log the input values
		Debug.Log("Name: " + nameInput.text);
		Debug.Log("Description: " + descriptionInput.text);
		Debug.Log("Amount: " + amountInput.value);
		Debug.Log("Choice: " + choiceInput.value);

		// Destroy the input dialog
		Destroy(gameObject);
	}
}