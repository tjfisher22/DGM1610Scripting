using UnityEngine.UI;
using UnityEngine;

public class ImageFillSetter : MonoBehaviour {
	public HPListVariable variable;


	public Image image;


	void Update () {
		image.fillAmount = Mathf.Clamp01(variable.listValue[0]/variable.value);
	}
}
