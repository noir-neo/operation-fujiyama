using UnityEngine;
using UnityEngine.SceneManagement;

public class Restarter : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0.0f ||
            Input.GetAxisRaw("Vertical") != 0.0f) {
            SceneManager.LoadScene("Main");
        }
    }
}
