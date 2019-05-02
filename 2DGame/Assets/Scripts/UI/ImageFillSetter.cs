using UnityEngine.UI;
using UnityEngine;

public class ImageFillSetter : MonoBehaviour {
	//used across various scripts to create sliding bars
	public FloatListVariable variable;


	public Image image;


	void Update () {
		image.fillAmount = Mathf.Clamp01(variable.listValue[0]/variable.value);
	}
}
