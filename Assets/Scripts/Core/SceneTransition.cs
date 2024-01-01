using UnityEngine.SceneManagement;

namespace RPG.Core
{
    public static class SceneTransition
    {
        public static void Initiate(int sceneUndex)
        {
            SceneManager.LoadScene(sceneUndex);
        }
    }
}
