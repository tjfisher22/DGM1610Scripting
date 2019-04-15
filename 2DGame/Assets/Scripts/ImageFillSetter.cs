using UnityEngine.UI;
using UnityEngine;

public class ImageFillSetter : MonoBehaviour {
	public FloatVariable variable;
	public FloatVariable max; //see if there is a way to get this value from playerUnit


	public Image image;


	void Update () {

		image.fillAmount = Mathf.Clamp01(variable.value/max.value);
	}
}
