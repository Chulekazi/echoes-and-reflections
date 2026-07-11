using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cupstrigger : MonoBehaviour
{
    public GameObject UIpanel;
    public Button green;
    public Button red;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UIpanel.SetActive(false);
        green.onClick.AddListener(goodending);
        red.onClick.AddListener(badending);
    }

   private void OnTriggerEnter2D(Collider2D other)
   {
       if (other.CompareTag("Player"))
       {
          UIpanel.SetActive(true);
       }
   }

   private void goodending()
   {
     SceneManager.LoadScene("goodending");
   }

   private void badending()
   {
     SceneManager.LoadScene("badending");
   }
}
