using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private Slider _hpSlider;
    public GameObject image;
    
    [SerializeField]private float maxHp;

    private void Awake()
    {
        GameManager.Instance.SetScript(this);
        
        _hpSlider.value = GameManager.Instance.Score / GameManager.Instance.maxScore;
    }

    private void Update()
    {
        _hpSlider.value = Mathf.Lerp(_hpSlider.value ,GameManager.Instance.Score / maxHp, Time.deltaTime * 3f);
        
        var thisPos = image.transform.localPosition;
        image.transform.localPosition = new Vector3((_hpSlider.value * 1000) - 500, thisPos.y,thisPos.z);
    }

    public void Calculate(float count)
    {
        GameManager.Instance.Score = count;
    }

}
