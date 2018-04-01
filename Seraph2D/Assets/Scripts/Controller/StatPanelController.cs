using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatPanelController : MonoBehaviour 
{
	
	public GameObject targetObject;
	public StatPanel statPanel;

	public void DisplayTargetStats()
	{
		if(statPanel != null)
		{
			if(targetObject != null)
			{
				statPanel.Display(targetObject);
			}
			bool bIsActive = statPanel.gameObject.activeInHierarchy;
			statPanel.gameObject.SetActive(!bIsActive);
		}
	}
}
