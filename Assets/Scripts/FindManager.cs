using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class FindManager : MonoBehaviour
{
    [SerializeField]
    private EnemyUIProfile enemy;

    [SerializeField]
    private LoadingScreen loadingScreen;

    public void Init()
    {
        enemy.Init();
        FindEnemy();
    }

    public void FindEnemy()
    {
        loadingScreen.ShowScreen();
        StartCoroutine(GetRequest(StaticData.charLink));
    }

    private IEnumerator GetRequest(string uri)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
            //noInternet.SetActive(true);
        }
        else
        {
            string json = uwr.downloadHandler.text;

            //json = json.TrimStart('[');
            //json = json.TrimEnd(']');
            //json = "{\"Items\":" + json + "}";
            RootObject data = JsonUtility.FromJson<RootObject>(json);
            string firstName = data.results[0].name.first;
            string lastName = data.results[0].name.last;
            string mediumPhotoUrl = data.results[0].picture.medium;

            string fullName = $"{firstName}\n{lastName}";
            CrossSceneInfo.EnemyName = fullName;
            enemy.SetName(fullName);
            StartCoroutine(DownloadImage(mediumPhotoUrl));
        }
    }

    IEnumerator DownloadImage(string mediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(mediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            enemy.SetPhoto(((DownloadHandlerTexture)request.downloadHandler).texture);
            loadingScreen.HideScreen();
        }
    }
}
