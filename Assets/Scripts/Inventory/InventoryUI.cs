using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

	private float animTime = 0.3f;
	private Image iconHolder;
	IEnumerator co;

	private void Start() {
		iconHolder = GetComponentInChildren<Image>();

		Image[] allImagesFound = GetComponentsInChildren<Image>();
		foreach(Image image in allImagesFound) {
			if(image.transform.parent != null)
				iconHolder = image;
		}
	}

	private void Update() {
		iconHolder.gameObject.SetActive(iconHolder.sprite != null);
	}

	public void UpdateUI(Item item = null) {
		if(co != null)
			StopCoroutine(co);

		iconHolder.sprite = null;

        if(item != null)
        {
            iconHolder.transform.localScale = new Vector3() * 0.5f;
		    iconHolder.sprite = item.icon;

		    co = ScaleAnimation(animTime);
		    StartCoroutine(co);
        }
		
	}

	IEnumerator ScaleAnimation(float time) {
		Vector3 originalScale = iconHolder.transform.localScale;
		Vector3 targetScale = new Vector3(1,1,1);
		float originalTime = time;

		while(time > 0f) {
			time -= Time.deltaTime;
			iconHolder.transform.localScale = Vector3.Lerp(targetScale, originalScale, time / originalTime);
			yield return null;
		}
	}
}
