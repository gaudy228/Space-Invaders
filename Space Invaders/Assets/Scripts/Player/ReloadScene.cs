using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    private Control _control;
    private void Awake()
    {
        _control = new Control();
        _control.Main.Reload.performed += ctx => Reload();
    }
    private void OnEnable()
    {
        _control.Enable();
    }
    private void OnDisable()
    {
        _control.Disable();
    }
    private void Reload()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
