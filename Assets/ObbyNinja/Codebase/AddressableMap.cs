using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableMap : MonoBehaviour
{
    [SerializeField] private string _key;

    private GameObject _map;

    private void Awake()
    {
        InstantiateMap(_key);
    }

    private void InstantiateMap(string key) => Addressables.InstantiateAsync(key).Completed += OnLoadDone;

    private void OnLoadDone(AsyncOperationHandle<GameObject> @object) => _map = @object.Result;
}