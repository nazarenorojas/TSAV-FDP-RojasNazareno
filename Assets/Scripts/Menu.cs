using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    ParticleSystem Humo;
    public GameObject PLAY;
    bool pause;
    public void Start()
    {
        Time.timeScale = 0;
    }
    public void boton()
    {
        Time.timeScale = 1;
    }
    public void Escena()
    {
        SceneManager.LoadScene("Level");
    }
    public void Scene()
    {
        SceneManager.LoadScene("Menu");
    }
}
