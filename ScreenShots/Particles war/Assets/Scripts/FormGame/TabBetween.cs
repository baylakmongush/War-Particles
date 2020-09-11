using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabBetween : MonoBehaviour
{
	public List<InputField>	inputFields;
	int						fieldIndexer = 0;

	/// <summary>
	/// Tab between InputFields
	/// </summary>

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			fieldIndexer++;
			if (fieldIndexer >= inputFields.Count)
				fieldIndexer = 0;
			else
				inputFields[fieldIndexer].Select();
		}
	}
}
