using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTileBuy : MonoBehaviour
{
    public int requiredCoins;
    public GameObject[] objectsToActivate;
    public GameObject[] objectsToDeactivate;

    public GameObject _particleeffect;

    private void OnMouseDown()
    {
        if (FindObjectOfType<HUD_Coin_Display>().currentCoins >= requiredCoins)
        {
            foreach (GameObject obj in objectsToActivate)
            {
                obj.SetActive(true);
            }

            foreach (GameObject obj in objectsToDeactivate)
            {
                GameObject maybuyeffect =  Instantiate(_particleeffect, _particleeffect.transform.position, this.gameObject.transform.rotation);
                Destroy(maybuyeffect, 2);
                obj.SetActive(false);
            }
            FindObjectOfType<Currency_Manager>().SpendCoins(requiredCoins);
        }
    }
}
